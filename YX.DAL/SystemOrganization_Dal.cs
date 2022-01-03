using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using YX.Entity;
using System.Data.Entity;

namespace YX.DAL
{
    public class SystemOrganization_Dal
    {
       // static string _connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();
        ///// <summary>
        ///// 获取所有部门
        ///// </summary>
        ///// <returns></returns>
        //public DataTable GetOrganizations()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        string sql = @"SELECT  Organization_ID,ParentId,Organization_Name FROM [Base_Organization]";
           
        //        dt = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, sql).Tables[0];

        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //    return dt;
        //}
        /// <summary>
        /// 部门详情
        /// </summary>
        /// <param name="Organization_ID">部门ID</param>
        /// <returns></returns>
        public List<Base_Organization> GetOrganizationDetail(string Organization_ID)
        {
            //DataTable dt = new DataTable();
            //try
            //{
            //    string sql = @"SELECT  
            //    Organization_ID
            //  ,[Organization_Code] as '部门编码'
            //  ,[Organization_Name] as '部门名称'
            //  ,[Organization_InnerPhone] as '内线电话'
            //  ,[Organization_OuterPhone] as '外线电话'
            //  ,[Organization_Manager] as '主负责人'
            //  ,Organization_AssistantManager as '副负责人'
            //  ,[Organization_Fax] as '传真号码'
            //  ,[Organization_Zipcode]as '行政号码'
            //  ,[Organization_Address] as '所在地址'
            //  ,ParentId as '节点位置'
            //,[SortCode]  as '排序'  
            //  ,Organization_Remark as '备注'  
            //   FROM [Base_Organization] where Organization_ID=@Organization_ID";
            // SqlParameter[] par = new SqlParameter[]
            // {
            //    new SqlParameter("@Organization_ID", Organization_ID)
            // };
            // dt = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, sql,par).Tables[0];
            //}            
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            //return dt;
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    return db.Base_Organization.Where(o=>o.Organization_ID==Organization_ID).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetInitParentId()
        {
            DataTable dt = new DataTable();
            try
            {
                using (Sam_DBEntities db=new Sam_DBEntities())
                {
                    var sql = @"SELECT Organization_ID,
                            Organization_Name + ' - ' + CASE ParentId WHEN '0' THEN '父节' ELSE  '子节' END AS Organization_Name
                            FROM Base_Organization WHERE DeleteMark = 1 ORDER BY SortCode ASC";
                    dt = SqlHelper.ExecuteDataset(db.Database.Connection.ConnectionString, CommandType.Text, sql).Tables[0];
                }         

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }

        public List<Base_Organization> GetOrganizations()
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    return db.Base_Organization.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 获取所在部门
        /// </summary>
        /// <param name="User_ID"></param>
        /// <returns></returns>
        public List<Base_StaffOrganize> GetStaffOrganize(string User_ID)
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    return db.Base_StaffOrganize.Where(o => o.Base_UserInfo.User_ID == User_ID).ToList(); ;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="info"></param>
        public int AddSysOrganization(Base_Organization info)
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    db.Base_Organization.Add(info);
                    return db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateSysOrganization(Base_Organization info)
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    db.Base_Organization.Attach(info);
                    //把当前实体的状态改为Modified
                    db.Entry(info).State = EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int DeleteSysOrganization(string key)
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    var obj = new Base_Organization { Organization_ID = key };
                    db.Base_Organization.Attach(obj);
                    db.Base_Organization.Remove(obj);
                    return db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
