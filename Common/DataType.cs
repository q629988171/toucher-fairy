using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class DataType
    {

        public static Int32 ToInt32(string str) {
            Int32 result = 0;
            try { 
               result =    Int32.Parse(str);
            }catch(Exception e){
            
            }

            return result;
        
        }
    }
}
