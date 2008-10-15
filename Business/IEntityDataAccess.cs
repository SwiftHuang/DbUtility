using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Profile.Business
{
    /// <summary>
    /// 实体数据访问接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IEntityDataAccess<T> : IQueryable<T>
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Add(T entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        void Remove(T entity);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="TSubEntity">实体类型或派生类</typeparam>
        /// <param name="entities">要删除的实体列表</param>
        void RemoveAll<TSubEntity>(IEnumerable<TSubEntity> entities) where TSubEntity : T;

        /// <summary>
        /// 取得对应的数据库
        /// </summary>
        IDatabase Database { get; }
    }
}
