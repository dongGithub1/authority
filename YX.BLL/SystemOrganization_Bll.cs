using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using YX.DAL;
using YX.Entity;

namespace YX.BLL
{
    public class SystemOrganization_Bll
    {
        SystemOrganization_Dal org_dal = new SystemOrganization_Dal();
        public List<Base_Organization>GetOrganizations()
        {
            try
            {
                //using (Sam_DBEntities db = new Sam_DBEntities())
                //{
                //    return db.Base_Organization.ToList();
                //}
                return org_dal.GetOrganizations();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public DataTable GetInitParentId()
        {
            try
            {
                return org_dal.GetInitParentId();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Base_Organization> GetOrganizationDetail(string Organization_ID)
        {
            try
            {
                return org_dal.GetOrganizationDetail(Organization_ID);
            }
            catch (Exception)
            {

                throw;
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
                //using (Sam_DBEntities db = new Sam_DBEntities())
                //{
                //    return db.Base_StaffOrganize.Where(o => o.Base_UserInfo.User_ID == User_ID).ToList(); ;
                //}
                return org_dal.GetStaffOrganize(User_ID);
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
                //using (Sam_DBEntities db = new Sam_DBEntities())
                //{
                //    db.Base_Organization.Add(info);
                //    return db.SaveChanges();
                //}
                return org_dal.AddSysOrganization(info);
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
                //using (Sam_DBEntities db = new Sam_DBEntities())
                //{
                //    db.Base_Organization.Attach(info);
                //    //把当前实体的状态改为Modified
                //    db.Entry(info).State = EntityState.Modified;
                //    return db.SaveChanges();
                //}
                return org_dal.UpdateSysOrganization(info);
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
                //using (Sam_DBEntities db = new Sam_DBEntities())
                //{
                //    var obj = new Base_Organization {  Organization_ID = key };
                //    db.Base_Organization.Attach(obj);
                //    db.Base_Organization.Remove(obj);
                //    return db.SaveChanges();
                //}
                return org_dal.DeleteSysOrganization(key);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
