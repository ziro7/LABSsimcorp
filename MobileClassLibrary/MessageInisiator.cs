using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace LABSsimcorp {
    public static class MessageInisiator {

        public static Timer myTimer = new Timer {
            Interval = 1000,
            Enabled = true
        };

        public static void GenerateMessages() {
            if (myTimer != null) {
                myTimer.Start();
            }
        }

        public static void StopMessages() {
            if(myTimer != null) {
                myTimer.Close();
            }
        }
    }
}
