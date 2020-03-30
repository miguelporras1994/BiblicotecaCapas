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
           
                using (var Db = new Biblioteca())
                {
                    Db.libros.Add(MapearLibroDataBase(model));
                    Db.SaveChanges();
                    
                }



         
        }

        public void EditarLibros(ModeloLibro model)
        {
            using (var Db = new Biblioteca())
            {
                var Editar = Db.libros.Find(model.Id_Libro);
                
                Editar.Titulo = model.Titulo;
                Editar.Id_Genero = model.Id_Genero;
                Editar.Genero = model.Genero;
                Editar.Id_Marca = model.Id_Marca;
                Editar.Marca = model.Marca;
                Editar.Id_Estado = model.Id_Estado;
                Editar.Nom_Estado = model.Nom_Estado;
                Editar.Autor = model.Autor;

                Db.SaveChanges();

            }
        }

        public void EliminarLibros(int id)
        {
            using (var Db = new Biblioteca())
            {
                var Eliminar = Db.libros.Find(id);
                Db.libros.Remove(Eliminar);
            }
        }

        public ModeloLibro ObtenerLibrosId(int  id)
        {
            using (var Db = new Biblioteca())
            {
                return MapearAAplicacionLibros(Db.libros.Find(id));
            }
        }

        public List<ModeloLibro> ObtenerTodosLibros()
        {
            using (var Db = new Biblioteca())
            {
                var validar = Db.libros.ToList();
                
                  
                return Db.libros.Select(MapearAAplicacionLibros).ToList();
            }
        }



        private libros MapearLibroDataBase(ModeloLibro modelo)
        {
            return new libros()
            {
                Id_Libro = modelo.Id_Libro,
                Titulo = modelo.Titulo,
                Autor = modelo.Autor,
                Id_Genero = modelo.Id_Genero,
                Genero = modelo.Genero,
                Id_Marca = modelo.Id_Marca,
                Marca = modelo.Marca,
                Id_Estado = modelo.Id_Estado,
                Nom_Estado = modelo.Nom_Estado,
            };
        }

        private ModeloLibro MapearAAplicacionLibros(libros Tabla)
        {
            return new ModeloLibro()
            {
                Id_Libro = Tabla.Id_Libro,
                Titulo = Tabla.Titulo,
                Autor = Tabla.Autor,
                Id_Genero = Tabla.Id_Genero,
                Genero = Tabla.Genero,
                Id_Marca = Tabla.Id_Marca,
                Marca = Tabla.Marca,
                Id_Estado = Tabla.Id_Estado,
                Nom_Estado = Tabla.Nom_Estado,
            };
        }



    }
}
