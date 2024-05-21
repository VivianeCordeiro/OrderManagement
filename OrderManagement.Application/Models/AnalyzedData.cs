using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Models
{
    public class AnalyzedData
    {
        public int Norte { get; set; }
        public int Nordeste { get; set; }
        public int Sul { get; set; }
        public int Sudeste { get; set; }
        public int CentroOeste { get; set; }
        public int SP { get; set; }
        public int Televisao { get; set; }
        public int Notebook { get; set; }
        public int Celular { get; set;}
        public List<Sales> Sales { get; set; }
        public AnalyzedData()
        {
            Sales = new List<Sales>(); // Inicializa a lista
        }

    }
}
