using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YX.Entity;
namespace YX.DAL
{
    public static class System_Dal
    {
        
        /// <summary>
        /// 获取数据库所有表名
        /// </summary>
        /// <returns></returns>
        public static List<string > GetTableName()
        {
            List<string>list=new List<string>();
            try
            {
                using (Sam_DBEntities db=new Sam_DBEntities())
                {
                    string sql = @"select Name as TABLE_NAME from sysobjects where xtype = 'u' and status >= 0 and Name != 'sysdiagrams'";

                    DataTable dt= SqlHelper.ExecuteDataset(db.Database.Connection.ConnectionString, CommandType.Text, sql).Tables[0];
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            list.Add(dr["TABLE_NAME"].ToString());
                        }
                    }

                    return list;
                }

       
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
                using (Sam_DBEntities db=new Sam_DBEntities())
                {
                    string strSql = "";
                    if (!string.IsNullOrEmpty(object_id) && object_id != "未选择")
                    {
                        strSql = @"SELECT
                                     [列名]=a.name,
                                     [数据类型]=b.name,
                                     [长度]=COLUMNPROPERTY(a.id,a.name,'PRECISION'),
                                     [是否为空]=case when a.isnullable=1 then '√'else '' end,
                                     [默认值]=isnull(e.text,''),
                                     [说明]=isnull(g.[value],'未填说明')
                                     FROM syscolumns a
                                     left join systypes b on a.xusertype=b.xusertype
                                     inner join sysobjects d on a.id=d.id  and d.xtype='U' and  d.name<>'dtproperties'
                                     left join syscomments e on a.cdefault=e.id
                                     left join sys.extended_properties g on a.id=g.major_id and a.colid=g.minor_id 
                                     left join sys.extended_properties f on d.id=f.major_id and f.minor_id=0
                        where d.name='" + object_id + "' order by a.id,a.colorder";
                        return SqlHelper.ExecuteDataset(db.Database.Connection.ConnectionString, CommandType.Text, strSql).Tables[0];
                    }
                }
                    
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        public static int DbBackup(string FilePath)
        {
            try
            {
                using (Sam_DBEntities db=new Sam_DBEntities())
                {
                    string sql = string.Format(@"BACKUP DATABASE Sam_DB
                      TO  DISK = N'{0}'
                      WITH NOFORMAT
                      , NOINIT
                      , NAME = N'Sam_DB'
                      , SKIP
                      , REWIND
                      , NOUNLOAD
                      , STATS = 10", FilePath);

                    int i = SqlHelper.ExecuteNonQuery(db.Database.Connection.ConnectionString, CommandType.Text, sql);
                    return i;
                }
    
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 日志写数据库中
        /// </summary>
        /// <param name="loginfo"></param>
        /// <returns></returns>
        public static int WriteLogToDB(Base_Log loginfo)
        {
            try
            {
                using (Sam_DBEntities db=new Sam_DBEntities())
                {
                    loginfo.CreateTime = DateTime.Now;
                    loginfo.LogID = Guid.NewGuid().ToString();
                    db.Base_Log.Add(loginfo);
                    return db.SaveChanges(); ;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
