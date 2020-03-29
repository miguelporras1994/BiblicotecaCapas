using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAcessLayer.Modelos;

namespace BusinessAcessLayer.Interfaces
{
     public interface IRepositorioHistorial
    {

        void AgregarHistorial(ModeloHistorial model);
        void EliminiarHistorial(int id);
        void EditarHistorial(ModeloHistorial model);
        List<ModeloHistorial> ObtenerTodosHistorial();
        ModeloHistorial ObtenerHistorialId(int id);
    }
}
