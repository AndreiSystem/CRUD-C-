using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace CrudByAndrei.Models
{
    public class MongoHelper
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }

        // Conexão com o Mongo (Aqui você adiciona a conexão necessária para acessar o banco)
        public static string MongoConnection = "mongodb://localhost:27017";

        // Database do Mongo (Aqui você adiciona a Database que você pretende manipular)
        public static string MongoDatabase = "crud_mongo";

        public static IMongoCollection<Models.Student> student_collection { get; set; }

        // Método para startar a conexão com o serviço do Mongo
        internal static void ConnectToMongoService()
        {
            try
            {
                client = new MongoClient(MongoConnection);
                database = client.GetDatabase(MongoDatabase);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}