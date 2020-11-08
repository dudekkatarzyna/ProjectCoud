using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.Models
{
    public class SensorData
    {
        public int Id { get; }
        public int ShopId { get; }
        public DateTime Data_n_Time { get; }
        public int CurrentCapacity { get; }
    }
}
