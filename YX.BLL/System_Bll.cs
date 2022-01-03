using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YX.DAL;
using YX.Entity;

namespace YX.BLL
{
   public static class System_Bll
    {
        
        /// <summary>
        /// 获取数据库所有表名
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTableName()
        {
         
            try
            {
                return System_Dal. GetTableName(); ;              
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 获取某一个表的所有字段
        /// </summary>
        /// <param name="object_id">表名</param>
        /// <returns></returns>
        public static DataTable GetSyscolumns(string object_id)
        {
            DataTable dt = new DataTable();
            try
            {
                return System_Dal.GetSyscolumns(object_id);

            }
            catch (Exception)
            {

                throw;
            }
           
        }
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static int DbBackup(string FilePath)
        {
            try
            {
                return System_Dal.DbBackup(FilePath);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //写日志
        public static int WriteLogToDB(Base_Log loginfo)
        {
            try
            {
                return System_Dal.WriteLogToDB(loginfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
