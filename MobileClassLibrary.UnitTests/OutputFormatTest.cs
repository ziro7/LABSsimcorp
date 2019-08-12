using LABSsimcorp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MobileClassLibrary.UnitTest {

    [TestClass]
    public class OutputFormatTest {

        //setup
        FakeOutput output = new FakeOutput();

        [TestMethod]
        public void SMSReceived_FormatDelegateCapitalize_OutputIsCapitalized() {

            //arrange
            var mobile = new MobilePhone(Model.Iphone8, output);

            //act
            mobile.ChangeFormat(OutputFormat.FormatToUpper);
            mobile.SMSReceivedHandler("testMessage");

            //assert
            string outputFromMobile = output.WriteLineText;
            Assert.AreEqual(outputFromMobile, "TESTMESSAGE");
        }

        [TestMethod]
        public void SMSReceived_FormatDelegateReverseCapitalize_OutputIsReverseCapitalized() {
            
            //arrange
            var mobile = new MobilePhone(Model.Iphone8, output);

            //act
            mobile.ChangeFormat(OutputFormat.FormatToLower);
            mobile.SMSReceivedHandler("testMessage");

            //assert
            string outputFromMobile = output.WriteLineText;
            Assert.AreEqual(outputFromMobile, "testmessage");
        }

        [TestMethod]
        public void SMSReceived_FormatDelegateSort_OutputIsSorted() {
            
            //arrange
            var mobile = new MobilePhone(Model.Iphone8, output);
            
            //act
            mobile.ChangeFormat(OutputFormat.FormatFunish);
            mobile.SMSReceivedHandler("testMessage");

            //assert
            string outputFromMobile = output.WriteLineText;
            Assert.AreEqual(outputFromMobile, "Maeeegssstt");
        }
    }
}