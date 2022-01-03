using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;
using YX.Entity;

namespace YX.DAL
{
    public class SystemRole_Dal
    {
      
        /// <summary>
        /// 通过角色ID 获取角色
        /// </summary>
        /// <returns></returns>
        public List<Base_Roles> GetRoleByRoleId(string Roles_ID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Sam_DBEntities db=new Sam_DBEntities())
                {
                    //string sql = @"SELECT 
                    //        Roles_ID as '角色ID', 
                    //        ParentId as '节点位置', 
                    //        Roles_Name as  '角色名称', 
                    //        Roles_Remark as '角色描述',
                    //        SortCode as '排序',                          
                    //        CreateDate as '创建日期',
                    //        CreateUserName as '创建人',
                    //        ModifyDate as '修改日期', 
                    //        ModifyUserName as '修改人'
                    //        FROM Base_Roles WHERE DeleteMark != 0 and Roles_ID=@Roles_ID ORDER BY SortCode ASC";

                    //SqlParameter[] par = new SqlParameter[]
                    //{
                    //new SqlParameter("@Roles_ID", Roles_ID)
                    //};
                    //dt = SqlHelper.ExecuteDataset(db.Database.Connection.ConnectionString, CommandType.Text, sql, par).Tables[0];
                   return    db.Base_Roles.Where(o=>o.DeleteMark!=0 && o.Roles_ID==Roles_ID).OrderBy(o=>o.SortCode).ToList();
                }
                    

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 获取全部角色
        /// </summary>
        /// <returns></returns>
        public List<Base_Roles> GetRoles()
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    return db.Base_Roles.Where(o => o.DeleteMark != 0).OrderBy(o => o.SortCode).ToList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 获取角色节点
        /// </summary>
        /// <returns></returns>
        public DataTable GetRoleParentId()
        {
            DataTable dt = new DataTable();
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    var sql = @"SELECT Roles_ID,
                            Roles_Name + ' - ' + CASE ParentId WHEN '0' THEN '父节' ELSE  '子节' END AS Roles_Name
                            FROM Base_Roles WHERE DeleteMark = 1 ORDER BY SortCode ASC";
                    dt = SqlHelper.ExecuteDataset(db.Database.Connection.ConnectionString, CommandType.Text, sql).Tables[0];
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }
        public List<Base_UserRole> GetUserRoleByUserID(string UserID)
        {
            try
            {
                using (Sam_DBEntities db=new Sam_DBEntities())
                {
                    return db.Base_UserRole.Where(o => o.Base_UserInfo.User_ID == UserID).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int AddRoles(Base_Roles info)
        {
            try
            {
                int result = 0;
                using (Sam_DBEntities db=new Sam_DBEntities())
                {
                    using (TransactionScope trans = new TransactionScope())
                    {
                        // UserInfo.User_Pwd = Md5Helper.Md5("123456");
                        db.Base_Roles.Add(info);
                        result = db.SaveChanges();
                        trans.Complete();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateRoles(Base_Roles info)
        {
            try
            {
                int result = 0;
                using (Sam_DBEntities db=new Sam_DBEntities())
                {
                    using (TransactionScope trans=new TransactionScope())
                    {
                        db.Database.ExecuteSqlCommand("delete from Base_RoleRight where Roles_ID={0}",info.Roles_ID);

                        if (info.Base_RoleRight != null && info.Base_RoleRight.Count>0)
                        {
                            string sql_roleright = "";
                            foreach (var item in info.Base_RoleRight)
                            {
                                sql_roleright += string.Format(@"insert into Base_RoleRight ([RoleRight_ID]
                                      ,[Roles_ID]
                                      ,[Menu_Id]
                                      ,[CreateDate]
                                      ,[CreateUserId]
                                      ,[CreateUserName])
                                        values('{0}','{1}','{2}','{3}','{4}','{5}');"
                                    , Guid.NewGuid().ToString(), info.Roles_ID, item.Menu_Id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), item.CreateUserId, item.CreateUserName);
                            }
                            db.Database.ExecuteSqlCommand(sql_roleright);
                        }

                        //把当前实体的状态改为Modified
                        db.Base_Roles.Attach(info);
                        db.Entry(info).State = EntityState.Modified;//会全部字段修改
                        db.Entry(info).Property("CreateDate").IsModified = false;//不修改某字段
                        db.Entry(info).Property("CreateUserId").IsModified = false;//不修改某字段
                        db.Entry(info).Property("CreateUserName").IsModified = false;//不修改某字段
                        result = db.SaveChanges();
                        trans.Complete();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int DeleteRole(string  RoleID)
        {
            try
            {
                using (Sam_DBEntities db=new Sam_DBEntities())
                {
                    var obj = new Base_Roles {  Roles_ID=RoleID };
                    db.Base_Roles.Attach(obj);
                    db.Base_Roles.Remove(obj);
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
