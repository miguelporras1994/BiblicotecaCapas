using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAcessLayer.Modelos;
namespace BusinessAcessLayer.Interfaces
{
    public interface IRepositorioLibros 
    {

        void AgregarLibros(ModeloLibro model);
        void EliminarLibros(int id);
        void EditarLibros(ModeloLibro model);
        List<ModeloLibro> ObtenerTodosLibros();
        ModeloLibro ObtenerLibrosId(int id);
    }
}
