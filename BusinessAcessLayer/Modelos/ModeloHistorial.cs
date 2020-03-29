using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAcessLayer.Modelos
{
    public class ModeloHistorial
    {

        public int Id_Historial { get; set; }
        public string Id_Tercero { get; set; }
        public string Nombre_Ter { get; set; }
        public int? Id_Libro { get; set; }
        public string Titulo { get; set; }
        public DateTime? Fecha_Pres { get; set; }
        public DateTime? Fecha_Devo { get; set; }
        public int? Id_Estado { get; set; }
        public string Nom_Estado { get; set; }
    }
}
