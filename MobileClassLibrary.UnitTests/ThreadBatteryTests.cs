using System;
using System.Threading;
using System.Threading.Tasks;
using LABSsimcorp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MobileClassLibrary.UnitTests {
    [TestClass]
    public class ThreadBatteryTests {

        //Setup
        [TestMethod]
        public void ThreadBattery_Charge_CanNotHavePercentageChargedAbove100() {

            //Arrange
            ThreadBattery battery = new ThreadBattery(2000, 98);

            //Act
            int startValue = battery.PercentageCharged;
            battery.IsCharging = true;
            Thread chargingBattery = new Thread(new ThreadStart(battery.Charge));
            Thread.Sleep(4000); // Battery starts at 98 and after 4 sec should be 100 if capped or 102 if not.
            int endValue = battery.PercentageCharged;
            battery.IsCharging = false;
            Thread.Sleep(1500); // Give Battery Task time to end while loop.
            chargingBattery.Abort(); //Disposing extra thread

            //Assert
            Assert.AreEqual(100, endValue);
        }

        [TestMethod]
        public void ThreadBattery_Charge_CanNotHavePercentageChargedBelow0() {

            //Arrange
            ThreadBattery battery = new ThreadBattery(2000, 2);

            //Act
            int startValue = battery.PercentageCharged;
            battery.IsCharging = false;
            Thread chargingBattery = new Thread(new ThreadStart(battery.Discharge));
            Thread.Sleep(4000); // Battery starts at 2 and after 4 sec should be 0 if capped or -2 if not.
            int endValue = battery.PercentageCharged;
            battery.IsCharging = true;
            Thread.Sleep(1500); // Give Battery Task time to end while loop.
            chargingBattery.Abort(); //Disposing extra thread

            //Assert
            Assert.AreEqual(0 , endValue);
        }

        [TestMethod]
        public void ThreadBattery_ChargeTask_DischargingIfChargeTaskIsTurnedOff() {

            //Arrange
            ThreadBattery battery = new ThreadBattery(2000, 50) {
                IsCharging = true
            };
            // Constructor starts both tasks and hence treads
            // As it isCharging the Charge task will lock and stop discharge thread 
            Thread.Sleep(1500); // Wait 1 cycle 
            battery.IsCharging = false; // This will make the Charge Thread terminate
            Thread.Sleep(1500); // Give time for the Discharge thread to lock 
            var chargeStatus = battery.ChargeThread.ThreadState;
            Assert.AreEqual(ThreadState.Stopped, chargeStatus); //Charge is Off. I know i violates 1 assert pr test - but don't know how else to show it :s

            //Act
            battery.Discharge(); // making sure the battery is in discharge mode.
            int startValue = battery.PercentageCharged; // save the start level
            Thread.Sleep(3000); //Sleep for 3 sec to let the percentage charge drop.
            int endValue = battery.PercentageCharged; // save end level
            battery.IsCharging = true; //closing discharge thread
            Thread.Sleep(1500);

            //Assert
            Assert.IsTrue(endValue < startValue);
        }

        [TestMethod]
        public void ThreadBattery_ChargeTask_ChargingIfChargeTaskIsTurnedOn() {

            //Arrange
            ThreadBattery battery = new ThreadBattery(2000, 50) {
                IsCharging = true
            };
            // Constructor starts both tasks and hence treads
            // As it isCharging the Charge task will lock and stop discharge thread 
            Thread.Sleep(1500); // Give time for locking hence stopping discharge
            var chargeStatus = battery.ChargeThread.ThreadState;
            Assert.AreEqual(ThreadState.WaitSleepJoin, chargeStatus); 

            //Act
            int startValue = battery.PercentageCharged; // save the start level
            Thread.Sleep(3000); //Sleep for 3 sec to let the percentage charge drop.
            int endValue = battery.PercentageCharged; // save end level
            battery.IsCharging = false; //closing charge thread
            Thread.Sleep(1500);

            //Assert
            Assert.IsTrue(endValue > startValue);
        }

        //Teardown
    }
}
