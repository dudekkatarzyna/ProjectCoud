using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.Controllers
{
    public class DataBaseConnecion
    {
        public string DatabaseConnectionStrng { get; }
        public DataBaseConnecion()
        {
            this.DatabaseConnectionStrng = "Database=shopping_center;Data Source=shopping-ceneter-1.cpyweoetxkin.us-east-1.rds.amazonaws.com;User Id=admin;Password=j5FWjmnKfGDzKHd";
        }
    }
}
