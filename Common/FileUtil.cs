using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
   public class FileUtil
    {

        
       //获取 年月日 + "\" + Guid
        public static string getDateFolderGuidFileName() {
            string str = DateTime.Now.ToString("yyyyMMdd") + @"\" + System.Guid.NewGuid().ToString().Replace("-", "");
            return str;
        }
        //如果文件所在的文件夹不存在，则创建
        public static void createDirectoryIfNotExits(string file) {          
            file = file.Replace(@"/",@"\");
            int pos = file.LastIndexOf(@"\");
            string dir  = file.Substring(0, pos + 1);

            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                 
            }
            catch (Exception ex)
            {
                throw new ArgumentException("文件路径异常:"+ex.Message);
            }
        }

        //复制上传的文件到安装目录下
        public static string copyFileToStartupFolder(string filename, string startupPath, string rootPath)
        {
                string imageForDB = "";
                if (File.Exists(filename))
                {
                    int pos = filename.LastIndexOf(@".");
                    string fileExt = filename.Substring(pos + 1);
                    string file = FileUtil.getDateFolderGuidFileName() + "." + fileExt;
                    imageForDB = rootPath + @"\" + file;


                    string copyTo = startupPath + imageForDB;
                    FileUtil.createDirectoryIfNotExits(copyTo);
                    File.Copy(filename, copyTo, true);
                }
                else
                {     
                  throw new ArgumentException("文件不存在："+filename);
                }

                return imageForDB;
        }
    }
}
