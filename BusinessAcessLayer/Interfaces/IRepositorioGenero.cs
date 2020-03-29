using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAcessLayer.Modelos;


namespace BusinessAcessLayer.Interfaces
{
     public interface IRepositorioGenero
    {
        void AgregarGenero( ModeloGenero model);
        void EliminiarGenero(int id);
        void EditarGenero(ModeloGenero  model);
        List<ModeloGenero> ObtenerTodosGenero();
         ModeloGenero ObtenerGeneroId(int id);
    }
}
