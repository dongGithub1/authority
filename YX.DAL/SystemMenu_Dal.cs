using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using YX.Entity;
using System.Data.Entity;
using System.Linq.Expressions;
namespace YX.DAL
{
    public class SystemMenu_Dal
    {
       
        ///// <summary>
        ///// 获取子节点
        ///// </summary>
        ///// <returns></returns>
        //public DataTable GetSysMenuChilds(string ParentId)
        //{
        //    DataTable dt = null;
        //    try
        //    {
        //        using (Sam_DBEntities db=new Sam_DBEntities())
        //        {
        //            string sql = @"SELECT  
        //            Menu_Id
        //          ,[Menu_Name] as '菜单名称'
        //          ,[Menu_Tag] as '菜单标记'
        //          ,[Menu_Img] as '菜单图标'
	       //       ,case[ParentId] when '0'then '父节' else '子节'end as '节点位置'
        //          ,[SortCode] as '菜单排序'
        //          ,[CreateDate] as'创建时间'
        //          ,[CreateUserName] as'创建人'
        //          ,[ModifyDate] as '修改时间'
        //          ,[ModifyUserName] as'修改人'
        //            FROM [Base_SysMenu]WHERE ParentId=@ParentId
        //            order by sortcode asc";
        //            SqlParameter[] par = new SqlParameter[]
        //            {
        //            new SqlParameter("@ParentId", ParentId)
        //            };
        //            dt = SqlHelper.ExecuteDataset(db.Database.Connection.ConnectionString, CommandType.Text, sql, par).Tables[0];
        //        }
                  
        //    }
        //    catch (Exception ex)
        //    {
                
        //        throw ex;
        //    }
        //    return dt;
        //}
        public List<Base_SysMenu> GetMenusByCondition(Expression<Func<Base_SysMenu, bool>> lambda)
        {
            List<Base_SysMenu> list = new List<Base_SysMenu>();
            using (Sam_DBEntities db = new Sam_DBEntities())
            {
                list = db.Base_SysMenu.Where(lambda).ToList();
            }
            return list;
        }
        /// <summary>
        /// 用户权限查询
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public List<Base_UserRight> GetUserRightByCondition(Expression<Func<Base_UserRight, bool>> lambda)
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    return db.Base_UserRight.Where(lambda).ToList(); ;
                }

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
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    return db.Base_RoleRight.Where(lambda).ToList(); ;
                }

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
        public List<Base_SysMenu> GetSysMenus()
        {

            try
            {
                //DataTable dt = dal.GetParent();
                //list = DataTableToModel.GetEntities<Base_SysMenu>(dt).ToList();
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    return db.Base_SysMenu.ToList();
                }

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
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    var query = (from menuinfo in db.Base_SysMenu
                                join userright in db.Base_UserRight
                                on menuinfo.Menu_Id equals userright.Menu_Id
                                where menuinfo.ParentId == "0" && userright.Base_UserInfo.User_ID == UserID
                                orderby menuinfo.SortCode ascending
                                select menuinfo).Union(from M in db.Base_SysMenu
                                                       join R_R in db.Base_RoleRight on M.Menu_Id equals R_R.Menu_Id
                                                       join U_R in db.Base_UserRole on R_R.Base_Roles.Roles_ID equals U_R.Roles_ID
                                                       where M.ParentId == "0" && U_R.Base_UserInfo.User_ID == UserID
                                                       orderby M.SortCode ascending
                                                       select M);
                    //var sql = query.ToString();                           
                    return query.ToList(); ;
                }

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
        public List<Base_SysMenu> GetSysMenuChilds(string ParentId, string UserID)
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    var query = (from menuinfo in db.Base_SysMenu
                                join userright in db.Base_UserRight
                                on menuinfo.Menu_Id equals userright.Menu_Id
                                where menuinfo.ParentId == ParentId && userright.Base_UserInfo.User_ID == UserID
                              
                                select menuinfo).Union(from M in db.Base_SysMenu 
                                                       join R_R in db.Base_RoleRight on M.Menu_Id equals R_R.Menu_Id
                                                       join U_R in db.Base_UserRole on R_R.Base_Roles.Roles_ID equals U_R.Roles_ID
                                                       where M.ParentId==ParentId && U_R.Base_UserInfo.User_ID==UserID
                                                  
                                                       select M).OrderBy(o=>o.SortCode);
                    return query.ToList(); ;
                    //  return db.Base_SysMenu.Where(o=>o.ParentId==ParentId).ToList();
                }
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
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    var query = (from menuinfo in db.Base_SysMenu                               
                                 where menuinfo.ParentId == ParentId                           
                                 select menuinfo).OrderBy(o => o.SortCode);
                    return query.ToList(); ;
                    //  return db.Base_SysMenu.Where(o=>o.ParentId==ParentId).ToList();
                }
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
        public int AddSysMenu(Base_SysMenu info)
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    db.Base_SysMenu.Add(info);
                    return db.SaveChanges();
                }
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
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    db.Base_SysMenu.Attach(info);
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
        /// 删除菜单
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int DeleteSysMenu(string key)
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    var obj = new Base_SysMenu { Menu_Id = key };
                    db.Base_SysMenu.Attach(obj);
                    db.Base_SysMenu.Remove(obj);
                    return db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //获取按钮
        public List<Base_SysMenu> GetButtonList(string ParentId, string UserID)
        {
            try
            {
                using (Sam_DBEntities db = new Sam_DBEntities())
                {
                    var query = (from a in db.Base_SysMenu
                                join b in db.Base_UserRight
                                on a.Menu_Id equals b.Menu_Id
                                where a.ParentId == ParentId &&b.Base_UserInfo.User_ID==UserID
                                 select a).Union(from M in db.Base_SysMenu
                                                join R_R in db.Base_RoleRight on M.Menu_Id equals R_R.Menu_Id
                                                join U_R in db.Base_UserRole on R_R.Base_Roles.Roles_ID equals U_R.Roles_ID
                                                where M.ParentId == ParentId && U_R.Base_UserInfo.User_ID == UserID
                                                orderby M.SortCode ascending
                                                select M);
                    return query.ToList();
                    //return db.Base_SysMenu.Where(o => o.ParentId == MenuID && o.Menu_Type == 3).ToList() ;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
