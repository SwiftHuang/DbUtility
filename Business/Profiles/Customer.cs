using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

using Profile.Common;

namespace Profile.Business.Profiles
{
    /// <summary>
    /// Customer
    /// </summary>
    public partial class Customer : Entity<Customer>
    {
        protected override void SaveAction(IDatabase database)
        {
            base.SaveAction(database);
        }
    }

    /// <summary>
    /// Customer的业务外观 
    /// </summary>
    public static class CustomerExtension
    {
        /// <summary>
        /// 根据顾客ID取得顾客
        /// </summary>
        /// <param name="query">顾客查询</param>
        /// <param name="blogClassID">顾客ID</param>
        /// <returns>该ID的顾客</returns>
        public static List<Customer> GetCust(this IQueryable<Customer> query, int CustomerID)
        {
            if (query == null)
                throw new ArgumentNullException("query");
            
            return query
                .Where(b => b.CustID == CustomerID)
                .OrderByDescending(b => b.UpdateOn)
                .ToList();
        }

        public static Customer GetCustByID(this IQueryable<Customer> query, int ID)
        {
            if (query == null)
                throw new ArgumentNullException("query");
            
            return query.Single<Customer>(b => b.ID == ID);
        }


        //public static List<Item> GetItems(, int CustomerID)
        //{
        //    ItemDataContext dataContext = new ItemDataContext();
        //    var query = from item in dataContext.Items
        //                where item.UserID == ownerId
        //                orderby item.CreateTime descending
        //                select new
        //                {
        //                    ItemID = item.ItemID,
        //                    Title = item.Title,
        //                    CreateTime = item.CreateTime,
        //                    UserID = item.UserID
        //                };

        //    using (dataContext.Connection)
        //    {
        //        return dataContext.ExecuteQuery<Item>(query);
        //    }
        //}


    }
}
