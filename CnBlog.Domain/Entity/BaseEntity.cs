using CnBlog.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CnBlog.Domain
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class BaseEntity : IEntity<int>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
    }

    public class BaseEntity<T> : IEntity<T> where T : struct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; set; }
    }

    /// <summary>
    /// 全实体基类
    /// </summary>
    public class BaseFullEntity : BaseEntity, IFullEntity<SystemUser>
    {
        public virtual Guid CreateUserId { get; set; }
        public virtual Guid UpdateUserId { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime UpdateTime { get; set; }
        [ForeignKey("UpdateUserId")]
        public SystemUser UpdateUser { get; set; }
        [ForeignKey("CreateUserId")]
        public SystemUser CreateUser { get; set; }
    }




    public class BaseFullEntity<T, F, U> : BaseEntity<T>, IFullEntity<T, F, U>
        where T : struct
        where U : class
        where F : struct
    {
        public virtual F CreateUserId { get; set; }
        public virtual F UpdateUserId { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime UpdateTime { get; set; }
        [ForeignKey("UpdateUserId")]
        public U UpdateUser { get; set; }
        [ForeignKey("CreateUserId")]
        public U CreateUser { get; set; }
    }
}
