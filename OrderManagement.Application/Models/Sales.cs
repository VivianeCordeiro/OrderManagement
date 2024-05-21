using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Product { get; set; }
        public double FinalValue { get; set; }
        public DateTime DeliveryDate { get; set; }

    }
}
