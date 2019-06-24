using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CnBlog.Domain
{

    public interface IEntity<T> where T : struct
    {
        T Id { get; set; }
    }

    /// <summary>
    /// 领域实体
    /// </summary>
    public interface IEntity : IEntity<int>
    {
    }

    /// <summary>
    /// 创建时间
    /// </summary>
    public interface ICreateEntity : IEntity
    {
        DateTime CreateTime { get; set; }
    }

    public interface ICreateEntity<T> : IEntity<T> where T : struct
    {
        DateTime CreateTime { get; set; }
    }

    /// <summary>
    /// 创建人
    /// </summary>
    public interface ICreateUserEntity<T, F> : ICreateEntity<T>
        where T : struct
        where F : struct
    {
        F CreateUserId { get; set; }
    }

    public interface ICreateUserEntity<T, F, U> : ICreateUserEntity<T, F>
        where T : struct
        where U : class
        where F : struct
    {
        [ForeignKey("CreateUserId")]
        U CreateUser { get; set; }
    }


    public interface ICreateUserEntity : ICreateUserEntity<int, Guid>
    {
    }

    /// <summary>
    /// 更新时间
    /// </summary>


    public interface IModlfyEntity<T> : IEntity<T> where T : struct
    {
        DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// 更新人
    /// </summary>
    public interface IModlfyUserEntity<T, F> : ICreateUserEntity<T, F>, IModlfyEntity<T>
        where T : struct
        where F : struct
    {
        F UpdateUserId { get; set; }
    }

    public interface IModlfyUserEntity<T, F, U> : ICreateUserEntity<T, F, U>, IModlfyUserEntity<T, F>
       where T : struct
       where U : class
       where F : struct
    {
        [ForeignKey("UpdateUserId")]
        U UpdateUser { get; set; }
    }

    public interface IModlfyEntity : IEntity
    {
        DateTime UpdateTime { get; set; }
    }

    public interface IModlfyUserEntity : IModlfyUserEntity<int, Guid>
    {
    }

    /// <summary>
    /// 全实体
    /// </summary>
    public interface IFullEntity<U> : IModlfyUserEntity<int, Guid, U>
        where U : class
    {

    }

    public interface IFullEntity<T, F, U> : IModlfyUserEntity<T, F, U>
       where T : struct
       where U : class
       where F : struct
    {

    }


    /// <summary>
    /// 聚合根
    /// </summary>
    public interface IAggregateRoot : IEntity
    {

    }

    /// <summary>
    /// 索引实体
    /// </summary>
    public interface ILuceneIndexable
    {
        /// <summary>
        /// 主键
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// 索引
        /// </summary>
        string IndexId { get; set; }
    }
}
