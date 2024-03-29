﻿using System;
using System.Threading;

namespace LABSsimcorp {
    public abstract class Battery : IBattery {

        protected static object charging = new object();

        public double Size { get; set; }
        public bool IsCharging { get; set; }
        public int PercentageCharged { get; set; }

        protected Battery(double size, int percentageCharged = 90) {
            Size = size;
            IsCharging = false;
            PercentageCharged = percentageCharged;
        }

        public abstract void Charge();

        public abstract void Discharge();

        protected virtual void OnBatteryChanged(int valueIsChangedWith) {
            OnBatteryIsChanging?.Invoke(valueIsChangedWith);
        }

        public event Action<int> OnBatteryIsChanging;

    }
}
