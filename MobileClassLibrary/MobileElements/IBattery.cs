using System;

namespace LABSsimcorp {
    public interface IBattery {
        bool IsCharging { get; set; }
        int PercentageCharged { get; set; }
        double Size { get; set; }

        event Action<int> OnBatteryIsChanging;

        void Charge();
        void Discharge();
    }
}