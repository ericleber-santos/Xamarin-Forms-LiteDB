using LiteDB;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TesteLiteDB.Helpers;
using TesteLiteDB.Models;

namespace TesteLiteDB.Data
{
    public static class Class1DAO
    {
        readonly static LiteDatabase _encryptedDB = DBHelper.DBConnection;

        public static Class1 GetObjetoClass1(int id)
        {            
            return _encryptedDB.GetCollection<Class1>("Classes").FindOne(x => x.CLASS_ID == id); 
        }

        public static bool Atualizar(Class1 class1)
        {
            try
            {
                var classes = _encryptedDB.GetCollection<Class1>("Classes");              

                var itemCadastrado = GetObjetoClass1(class1.CLASS_ID);

                if (itemCadastrado != null)
                {
                    class1.CLASS_CODIGO = (class1.CLASS_CODIGO > 0 ? class1.CLASS_CODIGO : itemCadastrado.CLASS_CODIGO);
                    class1.CLASS_DESCRICAO = (!string.IsNullOrEmpty(class1.CLASS_DESCRICAO) ? class1.CLASS_DESCRICAO : itemCadastrado.CLASS_DESCRICAO);

                    return classes.Update(itemCadastrado);
                }
                else
                {
                    class1.CLASS_ID = classes.Count() == 0 ? 1 : (int)(classes.Max(x => x.CLASS_ID) + 1);
                    return classes.Upsert(class1);
                } 
            }
            catch (LiteException e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public static List<Class1> ListarTodos()
        {
            return _encryptedDB.GetCollection<Class1>("Classes").FindAll().ToList(); 
        }

        public static Class1 GetUltimoInserido()
        { 
            return _encryptedDB.GetCollection<Class1>("Classes")
               .FindOne(             
                   Query.All(Query.Descending)
               );
        }
    }
}