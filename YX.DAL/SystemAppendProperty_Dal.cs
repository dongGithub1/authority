using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using YX.Entity;

namespace YX.DAL
{
    public class SystemAppendProperty_Dal
    {
        //static string _connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();
        /// 业务附加属性列表
        /// </summary>
        /// <param name="Function">业务功能</param>
        /// <returns></returns>
//        public DataTable AppendProperty_List(string Function)
//        {

//            try
//            {
//                string sql = @"SELECT  [Property_ID] as '编号'
//              ,[Property_Function]                   as '业务分类'
//              ,[Property_Control_ID]                 as '控件ID'
//              ,[Property_Name]                       as '控件名称'
//              ,[Property_Control_DataSource]         as '数据源'
//              ,[Property_Control_Length]             as '控件长度'
//              ,case [Property_Control_Style]
//              when 'txt' then '文本框' 
//	          when 'select' then '下拉框' 
//              when 'richText' then '大文本框'
//              when 'label' then '标签框'
//	          when 'date' then '日期框' end       as '控件类型'
//              ,[SortCode]                           as '排序' 
//                FROM Base_AppendProperty 
//                WHERE DeleteMark = 1         
//                AND Property_Function=@Property_Function 
//                ORDER BY SortCode ASC";
//                SqlParameter[] par = new SqlParameter[]
//                {
//                   new SqlParameter("@Property_Function", Function)
//                };

//                return SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, sql,par).Tables[0];
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }
             //业务功能列表
        public List<string> GetAppendPropertys()
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    return db.Base_AppendProperty.Select(o => o.Property_Function).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
  

        }
        //具体业务功能属性列表
        public List<Base_AppendProperty> AppendProperty_List(string Property_Function)
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                  return   db.Base_AppendProperty.Where(o=>o.DeleteMark==1 && o.Property_Function== Property_Function).OrderBy(o=>o.SortCode).ToList();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// 根据业务名称获取附加属性值
        /// </summary>
        /// <param name="Property_Function">所属功能</param>
        /// <param name="Obj_ID">业务主键</param>
        /// <returns></returns>
        public List<Base_AppendPropertyInstance> GetPropertyInstancepk(string Property_Function, string Obj_ID)
        {
            try
            {
                StringBuilder item_value = new StringBuilder();
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    var query = from I in db.Base_AppendPropertyInstance
                                join A in db.Base_AppendProperty
                                on I.Property_Control_ID equals A.Property_Control_ID
                                where I.Base_UserInfo.User_ID == Obj_ID && A.Property_Function == Property_Function
                                select I;
                    return query.ToList();
                }
            }
            catch (Exception)
            {
                
                throw;
            }

        }
        /// <summary>
        /// 添加属性
        /// </summary>
        /// <returns></returns>
        public int AddAppendProperty(Base_AppendProperty info)
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    db.Base_AppendProperty.Add(info);
                    return db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        /// <summary>
        /// 修改属性
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateAppendProertty(Base_AppendProperty info)
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    db.Base_AppendProperty.Attach(info);
                    db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="Property_ID"></param>
        /// <returns></returns>
        public int DeleteAppendProettty(string Property_ID)
        {
            try
            {
                using (Sam_DBEntities db=new Sam_DBEntities())
                {
                    var obj = new Base_AppendProperty { Property_ID= Property_ID };
                    db.Base_AppendProperty.Attach(obj);
                    db.Base_AppendProperty.Remove(obj);
                    return db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    
}
