﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WongTung.DataAccess
{
    public class DAJob : WongTung.DBUtility.DALBase<Entity.Table.job>
    {
        public DAJob()
        {
            TableName = Entity.Table.job.TableName;
        }
    }
}