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
    class RepositorioHistorial : IRepositorioHistorial
    {
        public void AgregarHistorial(ModeloHistorial model)
        {
            using (var Db = new Biblioteca())
            {
                Db.Historial.Add(MapearHistorialDataBase(model));
            }
        }

        public void EditarHistorial(ModeloHistorial model)
        {
            using (var Db = new Biblioteca())
            {
                var Editar = Db.Historial.Find(model.Id_Libro);

                Editar.Id_Tercero = model.Id_Tercero;
                Editar.Nombre_Ter = model.Nombre_Ter;
                
                Editar.Id_Libro = model.Id_Libro;
               Editar.Titulo = model.Titulo;
                Editar.Fecha_Pres = model.Fecha_Pres;
               Editar.Fecha_Devo = model.Fecha_Devo;
                Editar.Id_Estado = model.Id_Estado;
                Editar.Nom_Estado = model.Nom_Estado;

                Db.SaveChanges();

            }
        }

        public void EliminiarHistorial(int id)
        {
            using (var Db = new Biblioteca())
            {
                var Eliminar = Db.Historial.Find(id);
                Db.Historial.Remove(Eliminar);
            }
        }

        public ModeloHistorial ObtenerHistorialId(int id)
        {
            using (var Db = new Biblioteca())
            {
                return MapearAAplicacionHistorial(Db.Historial.Find(id));
            }
        }

        public List<ModeloHistorial> ObtenerTodosHistorial()
        {
            using (var Db = new Biblioteca())
            {
                return Db.Historial.Select(MapearAAplicacionHistorial).ToList();
            }
        }


        private Historial MapearHistorialDataBase(ModeloHistorial Tabla)
        {
            return new Historial()
            {

                Id_Historial = Tabla.Id_Historial,
                Id_Tercero = Tabla.Id_Tercero,
                Nombre_Ter = Tabla.Nombre_Ter,
                Id_Libro = Tabla.Id_Libro,
                Titulo = Tabla.Titulo,
                Fecha_Pres = Tabla.Fecha_Pres,
                Fecha_Devo = Tabla.Fecha_Devo,
                Id_Estado = Tabla.Id_Estado,
                Nom_Estado = Tabla.Nom_Estado


                
            };
        }

        private ModeloHistorial MapearAAplicacionHistorial(Historial Tabla)
        {
            return new ModeloHistorial()
            {

                Id_Historial = Tabla.Id_Historial,
                Id_Tercero = Tabla.Id_Tercero,
                Nombre_Ter = Tabla.Nombre_Ter,
                Id_Libro = Tabla.Id_Libro,
                Titulo = Tabla.Titulo,
                Fecha_Pres = Tabla.Fecha_Pres,
                Fecha_Devo = Tabla.Fecha_Devo,
                Id_Estado = Tabla.Id_Estado,
                Nom_Estado = Tabla.Nom_Estado
            };
        }


    }
}
