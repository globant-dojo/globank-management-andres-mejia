using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Application.Report.Dtos
{
    public class ReportsDto
    {
        public List<ReportDto> Movements { get; set; }
    }

    public class ReportDto
    {
        public string Fecha { get; set; }
        public string Cliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public int SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public int Movimiento { get; set; }
        public int SaldoDisponible { get; set; }



    }
}
