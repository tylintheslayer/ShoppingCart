using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataBaseItems
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }

        [ForeignKey(typeof(ClientType))]
        public int ClientTypeId { get; set; }

        [OneToOne]
        public ClientType ClientType { get; set;}
    }
}
