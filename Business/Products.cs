using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Profile;
using Profile.Entity;
using Profile.DataAccess;

namespace Profile.Business
{
    public class Products : BaseDataAccess<Entity.Product>
    {
        public override bool Delete(int productID)
        {
            Product pro = Database.Products.Single(b => b.ProductID == productID);
        }
    }
}
