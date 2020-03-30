using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAcessLayer.Modelos
{
    public class ModeloLibro
    {


        public int Id_Libro { get; set; }
        
        public string Titulo { get; set; }
        public int? Id_Genero { get; set; }
        public string Genero { get; set; }
        public int? Id_Marca { get; set; }
        public string Marca { get; set; }
        public int? Id_Estado { get; set; }
        public string Nom_Estado { get; set; }
        public string Autor { get; set; }


    }
}
