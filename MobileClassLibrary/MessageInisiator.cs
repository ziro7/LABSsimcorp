using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace LABSsimcorp {
    public static class MessageInisiator {

        public static Timer myTimer = new Timer(1000);

        public static void GenerateMessages() {
            using (var myTimer = new Timer {
                Interval = 1000,
                Enabled = true
            }) {
                myTimer.Start();
            }
        }

        public static void StopMessages() {
            myTimer.Close();
        }
    }
}
