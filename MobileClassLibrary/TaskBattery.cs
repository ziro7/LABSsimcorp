using System;
using System.Threading.Tasks;

namespace LABSsimcorp {
    public class TaskBattery : Battery {

        Task dischargeTask;
        Task chargeTask;

        public TaskBattery(double size) 
            : base (size){
            dischargeTask = new Task(() => {
                Discharge();
            });
            dischargeTask.Start();
            chargeTask = new Task(() => {
                Charge();
            });
            chargeTask.Start();
        }

        public override void Charge() {

            if (Task.CurrentId == chargeTask.Id) {
                // Lock the charging as long as IsCharing is true - checks every sec.
                lock (charging) {
                    while (IsCharging) {
                        PercentageCharged = PercentageCharged + 1;
                        OnBatteryChanged(1);
                        chargeTask.Wait(1000);
                    }
                }
            } else {
                chargeTask = new Task(() => {
                    Charge();
                });
                chargeTask.Start();
            }
        }

        public override void Discharge() {

            if (Task.CurrentId == dischargeTask.Id) {
                // Locking the thread while not charging.
                lock (charging) {
                    while (!IsCharging) {
                        PercentageCharged = PercentageCharged - 1;
                        OnBatteryChanged(-1);
                        dischargeTask.Wait(1000);
                    }
                }
            } else {
                dischargeTask = new Task(() => {
                    Discharge();
                });
                dischargeTask.Start();
            }
        }

        protected override void OnBatteryChanged(int valueIsChangedWith) {
            base.OnBatteryChanged(valueIsChangedWith);
        }
    }
}
