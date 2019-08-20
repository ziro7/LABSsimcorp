namespace LABSsimcorp {
    interface IBatteryFactory {
        IBattery CreateTaskBattery();
        IBattery CreateThreadBattery();
    }
}