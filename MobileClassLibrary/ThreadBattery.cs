using System;
using System.Threading;

namespace LABSsimcorp {
    public class ThreadBattery : Battery {

        Thread dischargeThread;
        Thread chargeThread;

        public Thread DischargeThread
        {
            get {return dischargeThread;}
            set {dischargeThread = value;}
        }

        public Thread ChargeThread
        {
            get {return chargeThread;}
            set {chargeThread = value;}
        }

        public ThreadBattery(double size,int percentageCharged = 90) 
            : base (size, percentageCharged){
            dischargeThread = new Thread(new ThreadStart(Discharge));
            dischargeThread.Start();
            chargeThread = new Thread(new ThreadStart(Charge));
            chargeThread.Start();
        }

        public override void Charge() {

            if (Thread.CurrentThread == chargeThread) {
                
                lock (charging) {
                    while (IsCharging && PercentageCharged < 100) {
                        PercentageCharged = PercentageCharged + 1;
                        OnBatteryChanged(1);
                        Thread.Sleep(1000);
                    }
                }
            } else {
                chargeThread = new Thread(new ThreadStart(Charge));
                chargeThread.Start();
            }
        }

        public override void Discharge() {

            if (Thread.CurrentThread == dischargeThread) {
                
                lock (charging) {
                    while (!IsCharging && PercentageCharged > 0) {
                        PercentageCharged = PercentageCharged - 1;
                        OnBatteryChanged(-1);
                        Thread.Sleep(1000);
                    }
                }
            } else {
                dischargeThread = new Thread(new ThreadStart(Discharge));
                dischargeThread.Start();
            }
        }

        protected override void OnBatteryChanged(int valueIsChangedWith) {
            base.OnBatteryChanged(valueIsChangedWith);
        }
    }
}
