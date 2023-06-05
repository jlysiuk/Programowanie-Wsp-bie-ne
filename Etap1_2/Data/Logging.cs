using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data {
    public class Logging {
        public static void saveData() {
            string data = $"{DateTime.Now}";
            try {
                StreamWriter fs = new StreamWriter($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}/logging.txt", append: true);
                fs.WriteLine(data);
                fs.Close();
            }
            catch { 
            }
        }
    }
}
