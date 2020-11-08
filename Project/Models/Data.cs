using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.Models
{
    public class Data
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public int MaxCapacity { get; set; }
        public DateTime Date_n_Time { get; set; }
        public int CurrentCapacity { get; set; }
    }
}
