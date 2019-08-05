using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABSsimcorp {
    class Program {
        static void Main(string[] args) {

            var mobilePhone = new MobilePhone(Model.Iphone10);
            Console.WriteLine(mobilePhone.GetDescription());
            Console.ReadLine();
        }
    }
}
