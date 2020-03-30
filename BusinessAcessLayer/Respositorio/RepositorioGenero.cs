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
     public class RepositorioGenero : IRepositorioGenero
    {
        public void AgregarGenero(ModeloGenero model)
        {
            using (var Db = new Biblioteca())
            {
                Db.Generos.Add(MapearGenerosDataBase(model));
            }
        }

        public void EditarGenero(ModeloGenero model)
        {
            using (var Db = new Biblioteca())
            {
                var Editar = Db.Generos.Find(model.Id_Genero);
                Editar.Nom_Genero= model.Nom_Genero;


                Db.SaveChanges();

            }
        }

        public void EliminiarGenero(int id)
        {
            using (var Db = new Biblioteca())
            {
                var Eliminar = Db.Generos.Find(id);
                Db.Generos.Remove(Eliminar);
            }
        }

       public   ModeloGenero ObtenerGeneroNom(string Nom_Genero)
        {
            using (var Db = new Biblioteca())
            {
                return MapearAAplicacionGeneros(Db.Generos.Where(H =>H.Nom_Genero == Nom_Genero).FirstOrDefault());
            }
        }
        public ModeloGenero ObtenerGeneroId(int id)
        {
            using (var Db = new Biblioteca())
            {
                return MapearAAplicacionGeneros(Db.Generos.Find(id));
            }
        }

        public List<ModeloGenero> ObtenerTodosGenero()
        {
            using (var Db = new Biblioteca())
            {
                return Db.Generos.Select(MapearAAplicacionGeneros).ToList();
            }
        }


        private Generos MapearGenerosDataBase(ModeloGenero Tabla)
        {
            return new  Generos()
            {
                Id_Genero = Tabla.Id_Genero,
                Nom_Genero = Tabla.Nom_Genero,

            };
        }

        private ModeloGenero MapearAAplicacionGeneros(Generos Tabla)
        {
            return new ModeloGenero()
            {
                Id_Genero = Tabla.Id_Genero,
                Nom_Genero = Tabla.Nom_Genero,
                



            };
        }
        }
}
