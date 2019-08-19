using System;
using System.Collections.Generic;
using LABSsimcorp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileClassLibrary.UnitTest;

namespace MobileClassLibrary.UnitTests {

    [TestClass]
    public class MobilePhoneTests {

        //Setup
        FakeOutput output = new FakeOutput();
        FakeDelegateMessageForm fakeForm = new FakeDelegateMessageForm(new Dictionary<FilterCheckBox, bool>());
        Contact jacob = new Contact(1, "Jacob", 12341234);
        Contact thomas = new Contact(2, "Thomas", 12341235);
        
        [TestMethod]
        public void PrintWithFilter_UserFilterEnabled_OnlySelectedUser() {

            //arrange
            FilterValueDTO filterValueDTO = new FilterValueDTO("Jacob", "message", DateTime.Now, DateTime.Now.Add(new TimeSpan(1, 0, 0)));
            MessageStorage smsStorage= new MessageStorage();
            MobilePhone mobile = new MobilePhone(Model.Iphone8, output, smsStorage);
            MessageInisiator inisiator = new ThreadMessageInisiator(mobile);
            fakeForm.FilterDict.Add(FilterCheckBox.User, true);
            fakeForm.FilterDict.Add(FilterCheckBox.Message, false);
            fakeForm.FilterDict.Add(FilterCheckBox.Date, false);

            //act
            mobile.ChangeFormat(OutputFormat.FormatToUpper);

            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(jacob, "testMessage from Jacob", DateTime.Now)));
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(thomas, "testMessage from Thomas", DateTime.Now)));
            mobile.ViewMessages(fakeForm.FilterDict, filterValueDTO);

            //assert
            string outputFromMobile = output.WriteLineText;
            string jacobString = "";
            string thomasString= "";

            if (outputFromMobile.IndexOf("JACOB") > 0) {
                jacobString = outputFromMobile.Substring(outputFromMobile.IndexOf("JACOB"), 5);
            }

            if (outputFromMobile.IndexOf("THOMAS") > 0) {
                thomasString = outputFromMobile.Substring(outputFromMobile.IndexOf("THOMAS"), 6);
            }
            Assert.AreEqual(jacobString, "JACOB");
            Assert.AreEqual(thomasString, "");
        }

        [TestMethod]
        public void PrintWithFilter_UserFilterEnabled_OnlySelectedMessage() {

            //arrange
            FilterValueDTO filterValueDTO = new FilterValueDTO("Jacob", "Jacob", DateTime.Now, DateTime.Now.Add(new TimeSpan(1, 0, 0)));
            MessageStorage smsStorage = new MessageStorage();
            MobilePhone mobile = new MobilePhone(Model.Iphone8, output, smsStorage);
            MessageInisiator inisiator = new ThreadMessageInisiator(mobile);
            fakeForm.FilterDict.Add(FilterCheckBox.User, false);
            fakeForm.FilterDict.Add(FilterCheckBox.Message, true);
            fakeForm.FilterDict.Add(FilterCheckBox.Date, false);

            //act
            mobile.ChangeFormat(OutputFormat.FormatToUpper);
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(jacob, "testMessage from Jacob", DateTime.Now)));
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(thomas, "testMessage from Thomas", DateTime.Now)));
            mobile.ViewMessages(fakeForm.FilterDict, filterValueDTO);

            //assert
            string outputFromMobile = output.WriteLineText;
            string jacobString = "";
            string thomasString = "";

            if (outputFromMobile.IndexOf("MESSAGE FROM JACOB") > 0) {
                jacobString = outputFromMobile.Substring(outputFromMobile.IndexOf("MESSAGE FROM JACOB"), 18);
            }

            if (outputFromMobile.IndexOf("MESSAGE FROM THOMAS") > 0) {
                thomasString = outputFromMobile.Substring(outputFromMobile.IndexOf("MESSAGE FROM THOMAS"), 19);
            }
            Assert.AreEqual(jacobString, "MESSAGE FROM JACOB");
            Assert.AreEqual(thomasString, "");
        }


        [TestMethod]
        public void PrintWithFilter_UserFilterEnabled_OnlySelectedDate() {

            //arrange
            FilterValueDTO filterValueDTO = new FilterValueDTO("Jacob", "MESSAGE", DateTime.Now, DateTime.Now.Add(new TimeSpan(1, 0, 0)));
            MessageStorage smsStorage = new MessageStorage();
            MobilePhone mobile = new MobilePhone(Model.Iphone8, output, smsStorage);
            MessageInisiator inisiator = new ThreadMessageInisiator(mobile);
            fakeForm.FilterDict.Add(FilterCheckBox.User, false);
            fakeForm.FilterDict.Add(FilterCheckBox.Message, false);
            fakeForm.FilterDict.Add(FilterCheckBox.Date, true);

            //act
            mobile.ChangeFormat(OutputFormat.FormatToUpper);
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(jacob, "testMessage from Jacob", DateTime.Now)));
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(thomas, "testMessage from Thomas", DateTime.Now.Add(new TimeSpan ( 3,0,0)))));
            mobile.ViewMessages(fakeForm.FilterDict, filterValueDTO);

            //assert
            string outputFromMobile = output.WriteLineText;
            string jacobString = "";
            string thomasString = "";

            if (outputFromMobile.IndexOf("JACOB") > 0) {
                jacobString = outputFromMobile.Substring(outputFromMobile.IndexOf("JACOB"), 5);
            }

            if (outputFromMobile.IndexOf("THOMAS") > 0) {
                thomasString = outputFromMobile.Substring(outputFromMobile.IndexOf("THOMAS"), 6);
            }
            Assert.AreEqual(jacobString, "JACOB");
            Assert.AreEqual(thomasString, "");
        }

        [TestMethod]
        public void PrintWithFilter_UserFilterEnabled_AllSelected() {

            //arrange
            FilterValueDTO filterValueDTO = new FilterValueDTO("Jacob", "Message3", DateTime.Now, DateTime.Now.Add(new TimeSpan(1, 0, 0)));
            MessageStorage smsStorage = new MessageStorage();
            MobilePhone mobile = new MobilePhone(Model.Iphone8, output, smsStorage);
            MessageInisiator inisiator = new ThreadMessageInisiator(mobile);
            fakeForm.FilterDict.Add(FilterCheckBox.User, true);
            fakeForm.FilterDict.Add(FilterCheckBox.Message, true);
            fakeForm.FilterDict.Add(FilterCheckBox.Date, true);

            //act
            mobile.ChangeFormat(OutputFormat.FormatToUpper);
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(jacob, "testMessage3 from Jacob", DateTime.Now)));
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(thomas, "testMessage3 from Thomas", DateTime.Now.Add(new TimeSpan(0, 1, 0)))));
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(jacob, "testMessage from Jacob", DateTime.Now.Add(new TimeSpan(0, 2, 0)))));
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(thomas, "testMessage from Thomas", DateTime.Now.Add(new TimeSpan(0, 3, 0)))));
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(thomas, "testMessage from Thomas", DateTime.Now.Add(new TimeSpan(0, 4, 0)))));
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(thomas, "testMessage from Thomas", DateTime.Now.Add(new TimeSpan(1, 1, 0)))));
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(jacob, "testMessage3 from Jacob", DateTime.Now.Add(new TimeSpan(1, 1, 0)))));
            mobile.ViewMessages(fakeForm.FilterDict, filterValueDTO);

            //assert
            string outputFromMobile = output.WriteLineText;
            string jacobString = "";
            string thomasString = "";

            if (outputFromMobile.IndexOf("JACOB") > 0) {
                jacobString = outputFromMobile.Substring(outputFromMobile.IndexOf("JACOB"), 5);
            }

            if (outputFromMobile.IndexOf("THOMAS") > 0) {
                thomasString = outputFromMobile.Substring(outputFromMobile.IndexOf("THOMAS"), 6);
            }
            Assert.AreEqual(jacobString, "JACOB");
            Assert.AreEqual(thomasString, "");
        }
    }
}
