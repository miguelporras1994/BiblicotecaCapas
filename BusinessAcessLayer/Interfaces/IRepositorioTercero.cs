using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAcessLayer.Modelos;

namespace BusinessAcessLayer.Interfaces
{
    public interface IRepositorioTercero
    {
        void AgregarTercero(ModeloTercero  model);
        void EliminarTercero(int id);
        void EditarTercero(ModeloTercero model);
        List<ModeloTercero> ObtenerTodosTercero();
        ModeloTercero ObtenerTerceroId(int id);
    }
}
