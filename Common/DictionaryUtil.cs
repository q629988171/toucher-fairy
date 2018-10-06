using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class DictionaryUtil
    {

       public static string toString(Dictionary<string,string> d) {
           string str = "";
           foreach (var item in d) {
               str = str + item.Key.ToString() + "：" + item.Value.ToString() + "\n";
           }
           return str;
       }
    }
}
