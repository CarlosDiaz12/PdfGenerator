using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfGenerator
{
    public class Cheque
    {
        public int Id { get; set; }
        public long NumeroCheque { get; set; }
        public string ConceptoPago { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaPago { get; set; }
        public double Monto { get; set; }
        public string MontoLetra { get; set; }
    }
}
