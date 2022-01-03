using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using YX.Entity;
using System.Transactions;
namespace YX.DAL
{
    public class SystemUserInfo_Dal
    {
      
       public DataTable GetUserInfoByOrganization_Id(StringBuilder SqlWhere, IList<SqlParameter> IList_param)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Sam_DBEntities db=new Sam_DBEntities())
                {

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT 
                 U.User_ID,
                U.User_Code as '用户工号',
                U.User_Name as '用户名称',
                U.User_Account as '登录账户',
 
                U.User_Sex as '性别',
                U.Title as '职称',
                U.DeleteMark as '状态',
                U.User_Remark as '备注',
                U.CreateDate  as'创建时间',
                U.Email as '邮箱'
                from Base_UserInfo U 
                LEFT JOIN Base_StaffOrganize S 
                ON U.User_ID = S.User_ID where U.DeleteMark !=0");
                    strSql.Append(SqlWhere);
                    strSql.Append(" GROUP BY U.User_ID,U.User_Code,U.User_Name,U.User_Account,U.User_Sex,U.Title,U.DeleteMark,U.User_Remark,U.CreateDate,U.Email");

                    dt = SqlHelper.ExecuteDataset(db.Database.Connection.ConnectionString, CommandType.Text, strSql.ToString(), IList_param.ToArray()).Tables[0];
                }

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return dt;
        }
       /// <summary>
       /// 后台登陆验证
       /// </summary>
       /// <param name="name">账户</param>
       /// <param name="pwd">密码</param>
       /// <returns></returns>
       public Base_UserInfo UserLogin(string name, string pwd)
       {

           try
           {
               using (Sam_DBEntities db = new Sam_DBEntities())
               {
                  // var password = Md5Helper.Md5(pwd);
                   return db.Base_UserInfo.Where(o => o.User_Account == name && o.User_Pwd == pwd).FirstOrDefault();
               }

           }
           catch (Exception ex)
           {

               throw ex;
           }
       }
       /// <summary>
       /// 添加用户
       /// </summary>
       /// <param name="UserInfo"></param>
       /// <returns></returns>
       public int AddUserInfo(Base_UserInfo UserInfo)
       {
           int result = 0;
           try
           {
               using (Sam_DBEntities db = new Sam_DBEntities())
               {
                   using (TransactionScope trans = new TransactionScope())
                   {
                      // UserInfo.User_Pwd = Md5Helper.Md5("123456");
                       db.Base_UserInfo.Add(UserInfo);
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
       /// 修改用户
       /// </summary>
       /// <param name="UserInfo"></param>
       /// <returns></returns>
       public int EditUserInfo(Base_UserInfo UserInfo)
       {
           int result = 0;
           try
           {
               using (Sam_DBEntities db = new Sam_DBEntities())
               {

                   using (TransactionScope trans = new TransactionScope())
                   {
                       //先删除所属部门                       
                       db.Database.ExecuteSqlCommand("delete from Base_StaffOrganize where User_ID={0}", UserInfo.User_ID);
                       //先删除用户权限               
                       db.Database.ExecuteSqlCommand("delete from Base_UserRight where User_ID={0}", UserInfo.User_ID);
                       //先删除属性
                       db.Database.ExecuteSqlCommand("delete from Base_AppendPropertyInstance where PropertyInstance_Key={0}", UserInfo.User_ID);
                        //先删除用户角色
                       db.Database.ExecuteSqlCommand("delete from Base_UserRole where User_ID={0}",UserInfo.User_ID);

                       //添加用户权限

                       if (UserInfo.Base_UserRight != null && UserInfo.Base_UserRight.Count>0)
                       {
                           string sql_userright = "";
                           foreach (var item in UserInfo.Base_UserRight)
                           {
                               sql_userright += string.Format(@"insert into Base_UserRight ([UserRight_ID]
                                                      ,[User_ID]
                                                      ,[Menu_Id]
                                                      ,[CreateDate]
                                                      ,[CreateUserId]
                                                      ,[CreateUserName])
                                        values('{0}','{1}','{2}','{3}','{4}','{5}');"
                                   , Guid.NewGuid().ToString(), UserInfo.User_ID, item.Menu_Id, DateTime.Now.ToString("yyyy-MM-dd HH: mm:ss"), item.CreateUserId, item.CreateUserName);
                           }
                           db.Database.ExecuteSqlCommand(sql_userright);
                       }

                       //添加所属部门
                       if (UserInfo.Base_StaffOrganize != null && UserInfo.Base_StaffOrganize.Count>0)
                       {
                           string sql_staff = "";
                           foreach (var item in UserInfo.Base_StaffOrganize)
                           {
                               sql_staff += string.Format(@"insert into Base_StaffOrganize 
                            ([StaffOrganize_Id]  ,[Organization_ID],[User_ID] ,[CreateDate] ,[CreateUserId],[CreateUserName] )
                            values('{0}','{1}','{2}','{3}','{4}','{5}');", Guid.NewGuid().ToString(), item.Organization_ID, UserInfo.User_ID, DateTime.Now.ToString("yyyy-MM-dd HH: mm:ss"),
                                                                       item.CreateUserId, item.CreateUserName);
                           }
                           db.Database.ExecuteSqlCommand(sql_staff);
                       }
                        //添加所属角色
                        if (UserInfo.Base_UserRole != null && UserInfo.Base_UserRole.Count>0)
                        {
                            string sql_user_role = "";
                            foreach (var item in UserInfo.Base_UserRole)
                            {
                                sql_user_role += string.Format(@"insert into Base_UserRole( [UserRole_ID]
                                  ,[User_ID],[Roles_ID],[CreateDate],[CreateUserId],[CreateUserName])
                                    values('{0}','{1}','{2}','{3}','{4}','{5}')",Guid.NewGuid().ToString(),UserInfo.User_ID,item.Roles_ID,DateTime.Now.ToString("yyyy-MM-dd HH: mm:ss"),
                                    item.CreateUserId,item.CreateUserName);
                            }
                            db.Database.ExecuteSqlCommand(sql_user_role);
                        }
                       //添加属性
                       if (UserInfo.Base_AppendPropertyInstance != null && UserInfo.Base_AppendPropertyInstance.Count>0)
                       {
                           string sql_append = "";
                           foreach (var item in UserInfo.Base_AppendPropertyInstance)
                           {
                               sql_append += string.Format(@"insert into Base_AppendPropertyInstance([PropertyInstance_ID] ,[Property_Control_ID] ,
                                [PropertyInstance_Value],[PropertyInstance_Key])values('{0}','{1}','{2}','{3}');",
                                            Guid.NewGuid().ToString(), item.Property_Control_ID, item.PropertyInstance_Value, UserInfo.User_ID);
                           }
                           db.Database.ExecuteSqlCommand(sql_append);
                       }
                      
                       //修改信息
                       db.Base_UserInfo.Attach(UserInfo);
                       //把当前实体的状态改为Modified
                       db.Entry(UserInfo).State = EntityState.Modified;//会全部字段修改
                       db.Entry(UserInfo).Property("User_Pwd").IsModified = false;//不修改某字段
                       db.Entry(UserInfo).Property("CreateDate").IsModified = false;//不修改某字段
                       db.Entry(UserInfo).Property("CreateUserId").IsModified = false;//不修改某字段
                       db.Entry(UserInfo).Property("CreateUserName").IsModified = false;//不修改某字段
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
    }
}
