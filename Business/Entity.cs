using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

using Profile.Common.Validate;

namespace Profile.Business
{
    /// <summary>
    /// 表示实体
    /// </summary>
    public abstract class Entity<T>
        where T : class
    {
        /// <summary>
        /// 新实体的ID取值
        /// </summary>
        public const int NEW_ENTITY_ID = 0;

        /// <summary>
        /// 取得实体的ID
        /// </summary>
        public abstract int ID { get; }
        /// <summary>
        /// 取得实体的时间戳
        /// </summary>
        public abstract byte[] TimeStamp { get; }

        /// <summary>
        /// 取得实体是否是新实体
        /// </summary>
        public bool IsNew
        {
            get { return ID == NEW_ENTITY_ID; }
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="database">数据库</param>
        /// <returns>验证结果</returns>
        public ValidateResult Validate(IDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException("database");

            var validater = new Validater();
            ValidateAction(validater, database);
            return validater.Validate();
        }
        /// <summary>
        /// 验证动作
        /// </summary>
        /// <param name="validater">验证器</param>
        /// <param name="database">数据库</param>
        protected virtual void ValidateAction(Validater validater, IDatabase database) { }

        /// <summary>
        /// 保存 
        /// </summary>
        /// <param name="database">数据库</param>
        public void Save(IDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException("database");

            var validateResult = this.Validate(database);
            if (!validateResult.IsValidated)
                throw new ValidateFailException(validateResult);

            SaveAction(database);
        }
        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="database">数据库</param>
        protected virtual void SaveAction(IDatabase database)
        {
            IEntityDataAccess<T> dataAccess = database.GetDataAccess<T>();
            if (this.IsNew)
                dataAccess.Add(this as T);

            database.Submit();

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="database">数据库</param>
        public void Delete(IDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException("database");

            DeleteAction(database);
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="database">数据库</param>
        protected virtual void DeleteAction(IDatabase database)
        {
            IEntityDataAccess<T> dataAccess = database.GetDataAccess<T>();
            if (!this.IsNew)
                dataAccess.Remove(this as T);

            database.Submit();
        }
    }

    /// <summary>
    /// 对于实体接口的扩展方法
    /// </summary>
    public static class EntityExtension
    {
        /// <summary>
        /// 根据ID取得实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="query">实体查询</param>
        /// <param name="id">ID</param>
        /// <returns>对应的实体，不存在则返回空</returns>
        public static T GetByID<T>(this IQueryable<T> query, int id)
            where T : Entity<T>
        {
            if (query == null)
                throw new ArgumentNullException("query");

            return query.SingleOrDefault(entity => entity.ID == id);
        }

        public static List<T> ExecuteQuery<T>(this IQueryable query,IDatabase database)
        {
            DbCommand command = database.GetCommand(query);
            database.OpenConnection();

            using (DbDataReader reader = command.ExecuteReader())
            {
                return database.Translate<T>(reader).ToList();
            }
        }

        private static void OpenConnection(this IDatabase database)
        {
            if (database.Connection.State == ConnectionState.Closed)
            {
                database.Connection.Open();
            }
        }
    }
}
