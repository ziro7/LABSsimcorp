using LABSsimcorp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MobileClassLibrary.UnitTest {
    [TestClass]
    public class MobilPhoneTest {
        [TestMethod]
        public void CreatePhone_Headphones_OutputValidate() {

            //arrange
            var output = new FakeOutput();
            var smsStorage = new MessageStorage();
            var mobile = new MobilePhone(Model.Iphone8,output,smsStorage);
            
            //act
            mobile.InsertEquipmentInJackStick(new Headphones(output));
            mobile.AudioInJackStik.Play(new object());

            //assert
            string outputFromMobile = output.WriteLineText;
            Assert.AreEqual(outputFromMobile, "Plays on the " + typeof(Headphones));
        }
    }
}
