//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YX.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Base_Roles
    {
        public Base_Roles()
        {
            this.Base_RoleRight = new HashSet<Base_RoleRight>();
        }
    
        public string Roles_ID { get; set; }
        public string ParentId { get; set; }
        public string Roles_Name { get; set; }
        public string Roles_Remark { get; set; }
        public Nullable<int> SortCode { get; set; }
        public Nullable<int> DeleteMark { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyUserId { get; set; }
        public string ModifyUserName { get; set; }
    
        public virtual ICollection<Base_RoleRight> Base_RoleRight { get; set; }
    }
}
