using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeatRequest.API.Model
{
    public class Heat
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Sicaklik { get; set; }
        public int MakinaId { get; set; }
    }
}
