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
            var jacob = new Contact(1, "Jacob", 12345678);
            var messageStorage = new MessageStorage();

            //act
            messageStorage.OnMessageStored += delegate (object sender, MessageEventArgs e) {
                receivedEvents.Add(e.Message.Text);
            };

            messageStorage.Add(new Message(jacob, "message", DateTime.Now));

            //assert
            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual(1, messageStorage.MessagesList.Count);
        }

        [TestMethod]
        public void CreateMessageStorage_SMSRemoved_EventTriggered() {

            //arrange
            List<string> receivedEvents = new List<string>();
            var jacob = new Contact(1, "Jacob", 12345678);
            var messageStorage = new MessageStorage();
            var message = new Message(jacob, "message", DateTime.Now);
            messageStorage.Add(message);

            //act
            messageStorage.OnMessageRemoved += delegate (object sender, MessageEventArgs e) {
                receivedEvents.Add(e.Message.Text);
            };

            messageStorage.Remove(message);

            //assert
            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual(0, messageStorage.MessagesList.Count);
        }
    }
}
