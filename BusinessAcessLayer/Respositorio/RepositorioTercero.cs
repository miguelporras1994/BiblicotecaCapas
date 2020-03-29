using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAcessLayer.Modelos;
using BusinessAcessLayer.Interfaces;
using DataAccessLayer;

namespace BusinessAcessLayer.Respositorio
{
   public  class RepositorioTercero : IRepositorioTercero
    {
        public void AgregarTercero(ModeloTercero model)
        {
            using (var Db = new LibreriasEntities())
            {
                Db.Tercero.Add(MapearTerceroDataBase(model));
            }
        }

        public void EditarTercero(ModeloTercero model)
        {
            using (var Db = new LibreriasEntities())
            {
                var Editar = Db.Tercero.Find(model.Id_Tercero);

            
                Editar.Nombre_Ter = model.Nombre_Ter;
                Editar.Apellido_Ter = model.Apellido_Ter;
                Editar.Correo = model.Correo;
                Editar.Fecha_Nacimi = model.Fecha_Nacimi;
                Editar.Direccion = model.Direccion;
                Editar.Localidad = model.Localidad;
                Editar.Cuidad = model.Correo;

                Db.SaveChanges();

            }
        }

        public void EliminarTercero(int id)
        {
            using (var Db = new LibreriasEntities())
            {
                var Elimninar = Db.Tercero.Find(id);
                Db.Tercero.Remove(Elimninar);
            }
        }

        public ModeloTercero ObtenerTerceroId(int id)
        {
            using (var Db = new LibreriasEntities())
            {
                return MapearAAplicacionTercero(Db.Tercero.Find(id));
            }
        }

        public List<ModeloTercero> ObtenerTodosTercero()
        {
            using (var Db = new LibreriasEntities())
            {
                return Db.Tercero.Select(MapearAAplicacionTercero).ToList();
            }
        }


        private Tercero MapearTerceroDataBase(ModeloTercero Tabla)
        {
            return new Tercero()
            {
             

               Id_Tercero = Tabla.Id_Tercero,
               Nombre_Ter = Tabla.Nombre_Ter,
               Apellido_Ter = Tabla.Apellido_Ter,
               Correo = Tabla.Correo,
               Fecha_Nacimi = Tabla.Fecha_Nacimi,
               Direccion = Tabla.Direccion,
               Localidad = Tabla.Localidad,
               Cuidad = Tabla.Cuidad,

    };
        }

        private ModeloTercero   MapearAAplicacionTercero(Tercero Tabla)
        {
            return new ModeloTercero()
            {

                Id_Tercero = Tabla.Id_Tercero,
                Nombre_Ter = Tabla.Nombre_Ter,
                Apellido_Ter = Tabla.Apellido_Ter,
                Correo = Tabla.Correo,
                Fecha_Nacimi = Tabla.Fecha_Nacimi,
                Direccion = Tabla.Direccion,
                Localidad = Tabla.Localidad,
                Cuidad = Tabla.Cuidad,
            };
        }

       
    }
}


    

