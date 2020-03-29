﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAcessLayer.Interfaces;
using BusinessAcessLayer.Modelos;
using DataAccessLayer;

namespace BusinessAcessLayer.Respositorio
{
    public class RepositorioMarca : IRepositorioMarca
    {
        public void AgregarMarca(ModeloMarca model)
        {
            using (var Db = new LibreriasEntities())
            {
                Db.Marcas.Add(MapearMarcaDataBase(model));
            }
        }

        public void EditarMarca(ModeloMarca model)
        {
            using (var Db = new LibreriasEntities())
            {
                var Editar = Db.Marcas.Find(model.Id_Marca);
                Editar.Nom_Marca = model.Nom_Marca;
                

                Db.SaveChanges();

            }
        }

        public void EliminarMarca(int id)
        {
            using (var Db = new LibreriasEntities())
            {
                var Eliminar = Db.Marcas.Find(id);
                Db.Marcas.Remove(Eliminar);
            }
        }

        public ModeloMarca ObtenerMarca(int id)
        {
            using (var Db = new LibreriasEntities())
            {
                return MapearAAplicacionMarca(Db.Marcas.Find(id));
            }
        }

        public List<ModeloMarca> ObtenerTodosMarca()
        {
            using (var Db = new LibreriasEntities())
            {
                return Db.Marcas.Select(MapearAAplicacionMarca).ToList();
            }
        }





        private Marcas MapearMarcaDataBase(ModeloMarca Tabla)
        {
            return new Marcas()
            {
                Id_Marca = Tabla.Id_Marca,
                Nom_Marca = Tabla.Nom_Marca,

            };
        }

        private ModeloMarca MapearAAplicacionMarca(Marcas Tabla)
        {
            return new ModeloMarca()
            {
                Id_Marca = Tabla.Id_Marca,
                Nom_Marca = Tabla.Nom_Marca,
                

               
            };
        }
    }
}
