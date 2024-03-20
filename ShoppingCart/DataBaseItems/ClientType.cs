using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DataBaseItems
{
    public class ClientType
    {
        [PrimaryKey,AutoIncrement]
        public int ClientTypeId { get; set; }
        public string ClientTypeDescription { get; set; }
    }
}
