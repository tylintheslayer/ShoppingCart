using ShoppingCart.DataBaseItems;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;
using SQLitePCL;


namespace ShoppingCart.Databaseservices
{
        public class ShoppingDatabase
        {
            private SQLiteConnection _dbConnection;

            public string GetDatabasePath()
            {
                string filename = "shoppingdata.db";
                string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(pathToDb, filename);
            }

            public ShoppingDatabase()
            {

                _dbConnection = new SQLiteConnection(GetDatabasePath());

                _dbConnection.CreateTable<Client>();
                _dbConnection.CreateTable<ClientType>();
            _dbConnection.CreateTable<Shoes>();

            SeedDatabase();
            }
        public void SeedDatabase()
        {
            if (_dbConnection.Table<ClientType>().Count() == 0)
            {

                ClientType clientType = new ClientType()
                {
                    ClientTypeDescription = "Cash Client"
                };

                _dbConnection.Insert(clientType);

                clientType = new ClientType()
                {
                    ClientTypeDescription = "Credit Account Holder"
                };

                _dbConnection.Insert(clientType);

                if (_dbConnection.Table<Client>().Count() == 0)
                {

                    Client client = new Client()
                    {
                        Name = "",
                        Surname = "",
                        Email = "",
                        Number = "",
                        Password = "",
                    
                    };

                    _dbConnection.Insert(client);
                }

                if (_dbConnection.Table<Shoes>().Count() == 0) 
                {
                    Shoes shoes = new Shoes()
                    {
                        ShoeId = 1,
                       ShoeAmount = 10,
                        ShoePrice = 200,
                        ShoeImage = "nikeshoejpeg", 
                        ShoeType = "nike",
                    };
                    if (_dbConnection.Table<Shoes>().Count() == 0)
                        shoes = new()
                    {
                        ShoeId = 1,
                        ShoeAmount = 16,
                        ShoePrice = 300,
                        ShoeImage = "jordan.jpeg",
                        ShoeType = "Jordan",
                    };
                    if (_dbConnection.Table<Shoes>().Count() == 5)
                        shoes = new()
                    {
                        ShoeId = 1,
                        ShoeAmount = 2,
                        ShoePrice = 400,
                        ShoeImage = "fabiani.jpeg",
                        ShoeType = "Fabiani",
                    };
                    if (_dbConnection.Table<Shoes>().Count() == 1)
                        shoes = new()
                    {
                        ShoeId = 1,
                        ShoeAmount = 12,
                        ShoePrice = 500,
                        ShoeImage = "gstar.jpeg",
                        ShoeType = "GstarRaw",
                    };

                }


            }


        }

        public List<ClientType> GetAllClientTypes()
        {
            var clientTypes = _dbConnection.Table<ClientType>().ToList();

            return clientTypes;
        }

        public List<Client> GetAllClients()
        {
            return _dbConnection.Table<Client>().ToList();
        }

        public void UpdateClient(Client client)
        {
            _dbConnection.Update(client);
        }

        public Client GetClientById(int id)
        {
            Client client = _dbConnection.Table<Client>().Where(x => x.ClientId == id).FirstOrDefault();

            if (client != null)
                _dbConnection.GetChildren(client, true);

            return client;
        }
    }


}

