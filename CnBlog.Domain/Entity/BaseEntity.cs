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
    public class BaseEntity : IEntity
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
    public class BaseFullEntity : BaseEntity, IFullEntity
    {
        public virtual Guid CreateUser { get; set; }
        public virtual Guid UpdateUser { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime UpdateTime { get; set; }
    }




    public class BaseFullEntity<T> : BaseEntity<T>, IFullEntity<T> where T : struct
    {
        public virtual Guid CreateUser { get; set; }
        public virtual Guid UpdateUser { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime UpdateTime { get; set; }
    }
}
