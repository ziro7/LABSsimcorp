﻿using System;
using System.Threading;

namespace LABSsimcorp {
    public class ThreadBattery : Battery {

        Thread dischargeThread;
        Thread chargeThread;

        public ThreadBattery(double size) 
            : base (size){
            dischargeThread = new Thread(new ThreadStart(Discharge));
            dischargeThread.Start();
            chargeThread = new Thread(new ThreadStart(Charge));
            chargeThread.Start();
        }

        public override void Charge() {

            if (Thread.CurrentThread == chargeThread) {
                
                lock (charging) {
                    while (IsCharging) {
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
                    while (!IsCharging) {
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