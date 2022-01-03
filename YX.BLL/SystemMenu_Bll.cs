using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YX.DAL;
using System.Data;
using YX.Entity;
using System.Data.Entity;
using System.Linq.Expressions;
namespace YX.BLL
{
    public class SystemMenu_Bll
    {
        SystemMenu_Dal menu_dal = new SystemMenu_Dal();
        public List<Base_SysMenu> GetMenusByCondition(Expression<Func<Base_SysMenu,bool>>lambda)
        {

            try
            {
                return menu_dal.GetMenusByCondition(lambda);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        /// <summary>
        /// 用户权限查询
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public List<Base_UserRight> GetUserRightByCondition(Expression<Func<Base_UserRight,bool>>lambda)
        {
            try
            {

                return menu_dal.GetUserRightByCondition(lambda);
            }
            catch (Exception EX)
            {

                throw EX;
            }
        }
        /// <summary>
        /// 角色权限查询
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public List<Base_RoleRight> GetRoleRightByCondition(Expression<Func<Base_RoleRight, bool>> lambda)
        {
            try
            {

                return menu_dal.GetRoleRightByCondition(lambda);
            }
            catch (Exception EX)
            {

                throw EX;
            }
        }
        /// <summary>
        /// 获取全部菜单
        /// </summary>
        /// <returns></returns>
        public List<Base_SysMenu>  GetSysMenus()
        {
          
            try
            {

                return menu_dal.GetSysMenus();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
     
        }
        /// <summary>
        /// 获取菜单根节点
        /// </summary>
        /// <returns></returns>
        public List<Base_SysMenu> GetSysMenusParent(string UserID)
        {
            try
            {

                return menu_dal.GetSysMenusParent(UserID);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        /// <summary>
        /// 获取菜单子节点
        /// </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        public List<Base_SysMenu> GetSysMenuChilds(string ParentId,string UserID)
        {
            try
            {

                return menu_dal.GetSysMenuChilds(ParentId,UserID);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
        /// <summary>
        /// 获取菜单子节点
        /// </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        public List<Base_SysMenu> GetSysMenuChilds(string ParentId)
        {
            try
            {

                return menu_dal.GetSysMenuChilds(ParentId);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="info"></param>
        public int  AddSysMenu(Base_SysMenu info)
        {
            try
            {

                return menu_dal.AddSysMenu(info);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateSysMenu(Base_SysMenu info)
        {
            try
            {
                return menu_dal.UpdateSysMenu(info);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int DeleteSysMenu(string key)
        {
            try
            {

                return menu_dal.DeleteSysMenu(key);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //获取按钮
        public List<Base_SysMenu>GetButtonList(string ParentId, string UserID)
        {
            try
            {
                return menu_dal.GetButtonList(ParentId, UserID);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
