using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Models
{
    public class AnalyzedDataDTO
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
        public List<SalesDTO> Sales { get; set; }
        public AnalyzedDataDTO()
        {
            Sales = new List<SalesDTO>(); 
        }

    }
}
