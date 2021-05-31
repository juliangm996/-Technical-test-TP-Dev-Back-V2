using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev_Back.Api.Entities
{
    public class StockDao
    {
        public List<int> ItemCount { get; set; }
        public int Target { get; set; }
    }
}
