using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using YX.DAL;
using YX.Entity;

namespace YX.BLL
{
    public class SystemAppendProperty_Bll
    {
        SystemAppendProperty_Dal append_dal = new SystemAppendProperty_Dal();
        //业务功能列表
        public List<string> GetAppendPropertys()
        {
            try
            {
                return append_dal.GetAppendPropertys();
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
                //using (Sam_DBEntities db = new Sam_DBEntities())
                //{
                //  return   db.Base_AppendProperty.Where(o=>o.DeleteMark==1 && o.Property_Function== Property_Function).OrderBy(o=>o.SortCode).ToList();
                //}
                return append_dal.AppendProperty_List(Property_Function);
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
                //StringBuilder item_value = new StringBuilder();
                //using (Sam_DBEntities db = new Sam_DBEntities())
                //{
                //    var query = from I in db.Base_AppendPropertyInstance
                //                join A in db.Base_AppendProperty
                //                on I.Property_Control_ID equals A.Property_Control_ID
                //                where I.Base_UserInfo.User_ID == Obj_ID && A.Property_Function == Property_Function
                //                select I;
                //    return query.ToList();
                //}
                return append_dal.GetPropertyInstancepk(Property_Function, Obj_ID);
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
                //using (Sam_DBEntities db = new Sam_DBEntities())
                //{
                //    db.Base_AppendProperty.Add(info);
                //    return db.SaveChanges();
                //}
                return append_dal.AddAppendProperty(info);
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
                //using (Sam_DBEntities db = new Sam_DBEntities())
                //{
                //    db.Base_AppendProperty.Attach(info);
                //    db.Entry(info).State = System.Data.Entity.EntityState.Modified;
                //    return db.SaveChanges();
                //}
                return append_dal.UpdateAppendProertty(info);
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
                //using (Sam_DBEntities db=new Sam_DBEntities())
                //{
                //    var obj = new Base_AppendProperty { Property_ID= Property_ID };
                //    db.Base_AppendProperty.Attach(obj);
                //    db.Base_AppendProperty.Remove(obj);
                //    return db.SaveChanges();
                //}
                return append_dal.DeleteAppendProettty(Property_ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
