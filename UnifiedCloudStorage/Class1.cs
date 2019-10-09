using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedCloudStorage
{
    class Class1
    {

        public Class1()
        {
            
        }

        public async void Test()
        {
            GoogleDriveWrapper.GDriveDirectory gDriveDirectory = new GoogleDriveWrapper.GDriveDirectory();

            await gDriveDirectory.Create("Dir1");

        }

    }

    public class Program
    {
        public static void Main()
        {
            Class1 class1 = new Class1();
            class1.Test();
        }
    }

}
