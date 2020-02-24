using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using TesteLiteDB.Services;
using Xamarin.Forms;

namespace TesteLiteDB.Helpers
{
    public static class DBHelper
    {
        private static LiteDatabase _dbConnection;       

        public static string DBTOKEN = "suasenha";

        public static LiteDatabase DBConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    var connSenha = new ConnectionString(DependencyService.Get<ILiteDBDatabasePathProvider>().GetDBPath())
                    {
                        Password = DBHelper.DBTOKEN
                    };

                    _dbConnection = new LiteDatabase(connSenha); 
                }
                return _dbConnection;
            }
        }       
    }
}
