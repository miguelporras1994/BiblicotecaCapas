using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAcessLayer.Modelos;

namespace BusinessAcessLayer.Interfaces
{
     public  interface IRepositorioEstado
    {
        void AgregarEstado(ModeloEstado model);
        void EliminiarEstado(int id);
        void EditarEstado(ModeloEstado model);
        List<ModeloEstado> ObtenerTodosEstado();
        ModeloEstado ObtenerEstadoId(int id);
        ModeloEstado ObtenerEstadoNom(string Nom_Estado);



    }
}
