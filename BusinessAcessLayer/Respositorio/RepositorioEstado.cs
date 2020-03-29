using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAcessLayer.Interfaces;
using BusinessAcessLayer.Modelos;
using DataAccessLayer;
namespace BusinessAcessLayer.Respositorio
{
    class RepositorioEstado : IRepositorioEstado
    {
        public void AgregarEstado(ModeloEstado model)
        {
            using (var Db = new LibreriasEntities())
            {
                Db.Estados.Add(MapearEstadosDataBase(model));
            }
        }

        public void EditarEstado(ModeloEstado model)
        {
            using (var Db = new LibreriasEntities())
            {
                var Editar = Db.Estados.Find(model.Id_Estado);
                Editar.Nom_Estado = model.Nom_Estado;


                Db.SaveChanges();

            }
        }

            public void EliminiarEstado(int id)
        {
            using (var Db = new LibreriasEntities())
            {
                var Eliminar = Db.Estados.Find(id);
                Db.Estados.Remove(Eliminar);
            }
        }

        public ModeloEstado ObtenerEstadoId(int id)
        {
            using (var Db = new LibreriasEntities())
            {
                return MapearAAplicacionEstados(Db.Estados.Find(id));
            }
        }

        public List<ModeloEstado> ObtenerTodosEstado()
        {
            using (var Db = new LibreriasEntities())
            {
                return Db.Estados.Select(MapearAAplicacionEstados).ToList();
            }
        }


        private Estados  MapearEstadosDataBase(ModeloEstado Tabla)
        {
            return new Estados()
            {
                Id_Estado= Tabla.Id_Estado,
                Nom_Estado = Tabla.Nom_Estado,

            };
        }

        private ModeloEstado MapearAAplicacionEstados(Estados Tabla)
        {
            return new ModeloEstado()
            {
                Id_Estado = Tabla.Id_Estado,
                Nom_Estado = Tabla.Nom_Estado,



            };
        }

        }
}
