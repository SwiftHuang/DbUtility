﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WongTung.DataAccess
{
    public class DAJob : BaseDataAccess<Entity.Table.job>
    {
        public DAJob()
        {
            TableName = "job";
        }
    }
}