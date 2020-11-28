//using Dapper;
//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer
{
    public class Class1
    {
        private string _connection = @"Server=neighlink-dev-server.mysql.database.azure.com; Database=neighlinkdb; Uid=marcoliva@neighlink-dev-server; Pwd=Neighlink20;";

        //public IEnumerable<Models.User> GetData()
        //{
        //    IEnumerable<Models.User> lst = null;
        //    using (var db = new MySqlConnection( _connection ))
        //    {
        //        var sql = "select UserId from user";
        //        lst = db.Query<Models.User>( sql );
        //    }
        //    return lst;
        //}
    }
}
