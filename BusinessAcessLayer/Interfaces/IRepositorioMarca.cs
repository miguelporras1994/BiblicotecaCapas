using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAcessLayer.Modelos;

namespace BusinessAcessLayer.Interfaces
{
    public interface IRepositorioMarca
    {

        void AgregarMarca(ModeloMarca model);
        void EliminarMarca(int id);
        void EditarMarca(ModeloMarca model);
        List<ModeloMarca> ObtenerTodosMarca();
        ModeloMarca ObtenerMarca(int id);

    }
}
