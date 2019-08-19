using System;
using System.Threading;

namespace LabsSimcorp {
    public class Battery {

        public double Size { get; set; }
        public bool IsCharging { get; set; }
        public double PercentageCharged { get; set; }

        Thread dischargeThread;
        Thread chargeThread;

        private static object charging = new object();

        public Battery(double size) {
            Size = size;
            IsCharging = false;
            PercentageCharged = 1.00;
            dischargeThread = new Thread(new ThreadStart(Discharge));
            dischargeThread.Start();
            chargeThread = new Thread(new ThreadStart(Charge));
            chargeThread.Start();

        }

        private void Charge() {

            // Lock the charging as long as IsCharing is true - checks every sec.
            lock (charging) {
                while (IsCharging) {
                    PercentageCharged += PercentageCharged + 0.01;
                    Thread.Sleep(1000);
                }
            }
        }

        private void Discharge() {

            // Locking the thread while not charging.
            lock (charging) {
                while (!IsCharging) {
                    PercentageCharged -= PercentageCharged - 0.01;
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
