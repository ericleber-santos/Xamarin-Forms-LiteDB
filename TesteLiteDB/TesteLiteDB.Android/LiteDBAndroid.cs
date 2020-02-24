using System;
using System.IO;
using TesteLiteDB.Droid;
using TesteLiteDB.Services;

[assembly: Xamarin.Forms.Dependency(typeof(LiteDBAndroid))]
namespace TesteLiteDB.Droid
{
    public class LiteDBAndroid : ILiteDBDatabasePathProvider
    {  
        public string GetDBPath()
        {  
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "testelitedb.db3"); 
        }
    }
}