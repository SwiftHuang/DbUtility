using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;

using Profile.Business;

namespace Profile.DataAccess
{
    /// <summary>
    /// 实体数据访问的转换器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class EntityDataAccessAdapter<T> : IEntityDataAccess<T> where T : class
    {
        private Table<T> _Table;
        private Database _Database;

        /// <summary>
        /// 构造代理类
        /// </summary>
        /// <param name="database">数据库</param>
        public EntityDataAccessAdapter(Database database)
        {
            if (database == null)
                throw new ArgumentNullException("database");

            this._Database = database;
            this._Table = database.GetTable<T>();
        }

        #region IEntityDataAccess<T> Members

        public void Add(T entity)
        {
            _Table.InsertOnSubmit(entity);
        }

        public void Remove(T entity)
        {
            _Table.DeleteOnSubmit(entity);
        }
        public void RemoveAll<TSubEntity>(IEnumerable<TSubEntity> entities) where TSubEntity : T
        {
            _Table.DeleteAllOnSubmit(entities);
        }

        public int ExecuteCommand(string command, params object[] parameters)
        {
            return _Table.Context.ExecuteCommand(command, parameters);
        }

        public void Submit()
        {
            _Table.Context.SubmitChanges();
        }

        public IDatabase Database
        {
            get { return _Database; }
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return _Table.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Table.GetEnumerator();
        }

        #endregion

        #region IQueryable Members

        public System.Type ElementType
        {
            get { return typeof(T); }
        }

        public Expression Expression
        {
            get { return (_Table as IQueryable).Expression; }
        }

        public IQueryProvider Provider
        {
            get { return (_Table as IQueryable).Provider; }
        }

        #endregion

    }
}
