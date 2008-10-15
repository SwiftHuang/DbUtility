using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Profile.Business.Profiles;

namespace Profile.Business
{
    /// <summary>
    /// 数据库接口
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// 取得某一个实体的数据访问
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns>该实体的数据访问</returns>
        IEntityDataAccess<T> GetDataAccess<T>() where T : class;

        /// <summary>
        /// 提交数据库变更
        /// </summary>
        void Submit();
        string SqlLog { get; }

        #region Customers

        /// <summary>
        /// 取得日志数据访问
        /// </summary>
        IEntityDataAccess<Customer> Customers { get; }
        /// <summary>
        /// 取得日志分类数据访问
        /// </summary>
        IEntityDataAccess<CustomerDetail> CustomerDetails { get; }
        IEntityDataAccess<User> Users { get; }

        #endregion

    }
}
