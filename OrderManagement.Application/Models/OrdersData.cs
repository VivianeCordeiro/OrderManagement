using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using OrderManagement.Converters;

namespace OrderManagement.Application.Models
{
    public class OrdersData
    {
        public string Documento { get; set; }
        public string RazaoSocial { get; set;}
        public string CEP { get; set; }
        public string Produto { get; set;} 
        public int NumeroPedido { get; set; }
        [JsonConverter(typeof(DateTimeConverter2))]
        public DateTime Date { get; set; }
    }
}
