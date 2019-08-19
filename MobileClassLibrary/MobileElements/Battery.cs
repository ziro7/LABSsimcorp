using System;
using System.Threading;

namespace LabsSimcorp {
    public class Battery {

        private static object charging = new object();
        Thread dischargeThread;
        Thread chargeThread;

        public double Size { get; set; }
        public bool IsCharging { get; set; }
        public int PercentageCharged { get; set; }

        public Battery(double size) {
            Size = size;
            IsCharging = false;
            PercentageCharged = 90;
            dischargeThread = new Thread(new ThreadStart(Discharge));
            dischargeThread.Start();
            chargeThread = new Thread(new ThreadStart(Charge));
            chargeThread.Start();

        }

        public void Charge() {

            if (Thread.CurrentThread == chargeThread) {
                // Lock the charging as long as IsCharing is true - checks every sec.
                lock (charging) {
                    while (IsCharging) {
                        PercentageCharged = PercentageCharged + 1;
                        OnBatteryIsChanging?.Invoke(1);
                        Thread.Sleep(1000);
                    }
                }
            } else {
                chargeThread = new Thread(new ThreadStart(Charge));
                chargeThread.Start();
            }
        }

        public void Discharge() {

            if (Thread.CurrentThread == dischargeThread) {
                // Locking the thread while not charging.
                lock (charging) {
                    while (!IsCharging) {
                        PercentageCharged = PercentageCharged - 1;
                        OnBatteryIsChanging?.Invoke(-1);
                        Thread.Sleep(1000);
                    }
                }
            } else {
                dischargeThread = new Thread(new ThreadStart(Discharge));
                dischargeThread.Start();
            }
        }

        public event Action<int> OnBatteryIsChanging;
    }
}
