using System;
using LABSsimcorp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MobileClassLibrary.UnitTest {

    [TestClass]
    public class OutputFormatTest {

        //setup
        FakeOutput output = new FakeOutput();
        Contact jacob = new Contact(1, "Jacob", 12341234);

        [TestMethod]
        [Ignore] // SMS received no longer automaticly gets printed.
        public void SMSReceived_FormatDelegateCapitalize_OutputIsCapitalized() {

            //arrange
            var smsStorage = new MessageStorage();
            var mobile = new MobilePhone(Model.Iphone8, output, smsStorage);
            var inisiator = new ThreadMessageInisiator(mobile);

            //act
            mobile.ChangeFormat(OutputFormat.FormatToUpper);
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(jacob,"testMessage",DateTime.Now)));

            //assert
            string outputFromMobile = output.WriteLineText;
            Assert.AreEqual(outputFromMobile, "TESTMESSAGE");
        }

        [TestMethod]
        [Ignore] // SMS received no longer automaticly gets printed.
        public void SMSReceived_FormatDelegateReverseCapitalize_OutputIsReverseCapitalized() {

            //arrange
            var smsStorage = new MessageStorage();
            var mobile = new MobilePhone(Model.Iphone8, output, smsStorage);
            var inisiator = new ThreadMessageInisiator(mobile);

            //act
            mobile.ChangeFormat(OutputFormat.FormatToLower);
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(jacob, "testMessage", DateTime.Now)));

            //assert
            string outputFromMobile = output.WriteLineText;
            Assert.AreEqual(outputFromMobile, "testmessage");
        }

        [TestMethod]
        [Ignore] // SMS received no longer automaticly gets printed.
        public void SMSReceived_FormatDelegateSort_OutputIsSorted() {

            //arrange
            var smsStorage = new MessageStorage();
            var mobile = new MobilePhone(Model.Iphone8, output, smsStorage);
            var inisiator = new ThreadMessageInisiator(mobile);

            //act
            mobile.ChangeFormat(OutputFormat.FormatFunish);
            inisiator.OnElapsedHandler(this, new MessageEventArgs(new Message(jacob, "testMessage", DateTime.Now)));

            //assert
            string outputFromMobile = output.WriteLineText;
            Assert.AreEqual(outputFromMobile, "Maeeegssstt");
        }
    }
}