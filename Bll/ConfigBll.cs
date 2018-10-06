using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace Bll
{
    public class ConfigBll
    {

         


        //通过id获取panel
        public DataTable getById(int id)
        {
            String sql = "select * from config where id=@id";
            SQLiteParameter[] parameters = {
                       new SQLiteParameter("@id", DbType.Int32,4) 
                      };
            parameters[0].Value = id;
           
            DataTable dt = Common.SQLiteHelper.ExecuteQuery(sql, parameters);
            
           
            return dt;
        }

        //插入一条记录
        //int screenWidth, int screenHeight, string startupPath,int editWidth,int editHeight
        public int insert(Config config)
        {
            int id = 1;
            String sql = "insert into config(id,screenWidth,screenHeight,url) values(@id,@screenWidth,@screenHeight,@url);select last_insert_rowid();";
            SQLiteParameter[] parameters = {
                       new SQLiteParameter("@id", DbType.Int32,4),
                       new SQLiteParameter("@screenWidth", DbType.Int32,4),
                       new SQLiteParameter("@screenHeight", DbType.Int32,4),   
                       new SQLiteParameter("@url", DbType.String,100)
                      }; 
            parameters[0].Value = id;
            parameters[1].Value = config.screenWidth;
            parameters[2].Value = config.screenHeight;           
            parameters[3].Value = config.url;
            
            DataTable dt = Common.SQLiteHelper.ExecuteQuery(sql, parameters);
            int result = DataType.ToInt32(dt.Rows[0]["last_insert_rowid()"].ToString());
            return result;
        }

        //更新一条记录
        public int update(Config config)
        {
           int id = 1;
           string sql ="update config set screenWidth=@screenWidth,screenHeight=@screenHeight,url=@url where id=@id";

            SQLiteParameter[] parameters = {
                       new SQLiteParameter("@screenWidth", DbType.Int32,4),
                       new SQLiteParameter("@screenHeight", DbType.Int32,4),
                       new SQLiteParameter("@url", DbType.String,100),
                       new SQLiteParameter("@id", DbType.Int32,4)
                      };
            parameters[0].Value = config.screenWidth;
            parameters[1].Value = config.screenHeight;
         
            parameters[2].Value = config.url;
            parameters[3].Value = id;
            

            int result = Common.SQLiteHelper.ExecuteNonQuery(sql, parameters);
            return result;
        }

      
 
    }
}
