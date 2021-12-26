﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessApp.DataAccessLayer
{
    internal interface ISqlDataAccess
    {
        Task<int> Execute<T>(string sql,T model);
        Task<IEnumerable<T>> GetAll<T>(string sql, T model);
        Task<T> Get<T>(string sql, T model);
        int ExecuteWithReturnValue(string sql, DynamicParameters parameters);
    }
}
