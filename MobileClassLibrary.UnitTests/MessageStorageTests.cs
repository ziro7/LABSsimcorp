using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LABSsimcorp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileClassLibrary.UnitTest;

namespace MobileClassLibrary.UnitTests {
    [TestClass]
    public class MessageStorageTests {

        [TestMethod]
        public void CreateMessageStorage_SMSReceived_EventTriggered() {

            //arrange
            List<string> receivedEvents = new List<string>();
            var jacob = new User(1, "Jacob", 12345678);
            var messageStorage = new MessageStorage(new List<User>() { jacob });

            //act
            messageStorage.OnMessageReceived += delegate (object sender, MessageEventArgs e) {
                receivedEvents.Add(e.Message.Text);
            };

            messageStorage.Add(new Message(jacob, "message", DateTime.Now));

            //assert
            Assert.AreEqual(1, receivedEvents.Count);
        }

        [TestMethod]
        public void CreateMessageStorage_SMSRemoved_EventTriggered() {

            //arrange
            List<string> receivedEvents = new List<string>();
            var jacob = new User(1, "Jacob", 12345678);
            var messageStorage = new MessageStorage(new List<User>() { jacob });
            var message = new Message(jacob, "message", DateTime.Now);
            messageStorage.Add(message);

            //act
            messageStorage.OnMessageRemoved += delegate (object sender, MessageEventArgs e) {
                receivedEvents.Add(e.Message.Text);
            };

            messageStorage.Remove(message);

            //assert
            Assert.AreEqual(1, receivedEvents.Count);
        }
    }
}
