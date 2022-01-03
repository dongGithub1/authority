using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YX.DAL;
using YX.Entity;
namespace YX.BLL
{
    public class SystemRole_Bll
    {
        SystemRole_Dal role_dal = new SystemRole_Dal();
        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public List<Base_Roles> GetRoles()
        {
            try
            {
                return role_dal.GetRoles();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        /// <summary>
        /// 通过角色ID 获取角色
        /// </summary>
        /// <param name="Roles_ID"></param>
        /// <returns></returns>
        public List<Base_Roles> GetRoleByRoleId(string Roles_ID)
        {
          
            try
            {
                return role_dal.GetRoleByRoleId(Roles_ID);
            }
            catch (Exception)
            {

                throw;
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
                return role_dal.GetRoleParentId();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }
        public List<Base_UserRole> GetUserRoleByUserID(string UserID)
        {
            try
            {
                return role_dal.GetUserRoleByUserID(UserID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddRoles(Base_Roles info)
        {
            try
            {
                return role_dal.AddRoles(info);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int UpdateRoles(Base_Roles info)
        {
            try
            {
                return role_dal.UpdateRoles(info);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int DeleteRole(string RoleID)
        {
            try
            {
                return role_dal.DeleteRole(RoleID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
