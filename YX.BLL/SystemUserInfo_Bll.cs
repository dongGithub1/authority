using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YX.Entity;
using System.Transactions;
using System.Data.Entity;
using System.Security.Cryptography;
using YX.Common.DotNetEncrypt;
using YX.DAL;
using System.Data;
using System.Data.SqlClient;

namespace YX.BLL
{
    public class SystemUserInfo_Bll
    {
        SystemUserInfo_Dal user_dal = new SystemUserInfo_Dal();
        public DataTable GetUserInfoByOrganization_Id(StringBuilder SqlWhere, IList<SqlParameter> IList_param)
        {
            try
            {
                return user_dal.GetUserInfoByOrganization_Id(SqlWhere,IList_param);
            }
            catch (Exception)
            {

                throw;
            }
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

                var password = Md5Helper.Md5(pwd);
                return   user_dal.UserLogin(name, password);
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
            try
            {              
                UserInfo.User_Pwd = Md5Helper.Md5("123456");
                return   user_dal.AddUserInfo(UserInfo);
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
            try
            {
                
              return    user_dal.EditUserInfo(UserInfo);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
