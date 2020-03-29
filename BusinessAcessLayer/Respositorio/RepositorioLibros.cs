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
    public class RepositorioLibros : IRepositorioLibros
    {
        public void AgregarLibros(ModeloLibro model)
        {
            using (var Db = new LibreriasEntities())
            {
                Db.libros.Add(MapearLibroDataBase(model));
            }
        }

        public void EditarLibros(ModeloLibro model)
        {
            using (var Db = new LibreriasEntities())
            {
                var Editar = Db.libros.Find(model.Id_Libro);
                
                Editar.Titulo = model.Titulo;
                Editar.Id_Genero = model.Id_Genero;
                Editar.Genero = model.Genero;
                Editar.Id_Marca = model.Id_Marca;
                Editar.Marca = model.Marca;
                Editar.Id_Estado = model.Id_Estado;
                Editar.Nom_Estado = model.Nom_Estado;

                Db.SaveChanges();

            }
        }

        public void EliminarLibros(int id)
        {
            using (var Db = new LibreriasEntities())
            {
                var Eliminar = Db.libros.Find(id);
                Db.libros.Remove(Eliminar);
            }
        }

        public ModeloLibro ObtenerLibrosId(int  id)
        {
            using (var Db = new LibreriasEntities())
            {
                return MapearAAplicacionLibros(Db.libros.Find(id));
            }
        }

        public List<ModeloLibro> ObtenerTodosLibros()
        {
            using (var Db = new LibreriasEntities())
            {
                return Db.libros.Select(MapearAAplicacionLibros).ToList();
            }
        }



        private libros MapearLibroDataBase(ModeloLibro Tabla)
        {
            return new libros()
            {
                Id_Libro = Tabla.Id_Libro,
                Titulo = Tabla.Titulo,
                Id_Genero = Tabla.Id_Genero,
                Genero = Tabla.Genero,
                Id_Marca = Tabla.Id_Marca,
                Marca = Tabla.Marca,
                Id_Estado = Tabla.Id_Estado,
                Nom_Estado = Tabla.Nom_Estado
            };
        }

        private ModeloLibro MapearAAplicacionLibros(libros Tabla)
        {
            return new ModeloLibro()
            {
                Id_Libro = Tabla.Id_Libro,
                Titulo = Tabla.Titulo,
                Id_Genero = Tabla.Id_Genero,
                Genero = Tabla.Genero,
                Id_Marca = Tabla.Id_Marca,
                Marca = Tabla.Marca,
                Id_Estado = Tabla.Id_Estado,
                Nom_Estado = Tabla.Nom_Estado
            };
        }



    }
}
