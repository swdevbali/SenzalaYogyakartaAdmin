using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenzalaYogyakartaAdmin
{
    class MainLibrary
    {
        private static MainLibrary instance;
        string connectionString = "mongodb://swdev:muhammad@linus.mongohq.com:10030/senzalayogyakarta";
        MongoClient client;
        MongoServer server;
        MongoDatabase db;
        public MongoCollection siswaCol;

        private MainLibrary()
        {
        }

        public static MainLibrary getInstance()
        {
            if (instance == null)
            {
                instance = new MainLibrary();
            }
            return instance;
            
        }

        public void connect()
        {
            client = new MongoClient(connectionString);
            server = client.GetServer();
            db = server.GetDatabase("senzalayogyakarta");

            siswaCol = db.GetCollection<Siswa>("siswa");
        }
    }
}
