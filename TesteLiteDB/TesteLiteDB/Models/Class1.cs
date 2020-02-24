
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteLiteDB.Models
{    
    public class Class1
    {      
        [BsonId]
        public int CLASS_ID { get; set; }
        public int CLASS_CODIGO { get; set; }
        public string CLASS_DESCRICAO { get; set; }

        public Class1()
        {
            
        }
    }
}
