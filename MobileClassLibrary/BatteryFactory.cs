using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABSsimcorp {
    public class BatteryFactory : IBatteryFactory {

        public IBattery CreateTaskBattery() => new TaskBattery(1200);

        public IBattery CreateThreadBattery() => new ThreadBattery(1150);
    }
}
