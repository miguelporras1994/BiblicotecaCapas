using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessAcessLayer.Interfaces;
using BusinessAcessLayer.Respositorio;
using BusinessAcessLayer.Modelos;



namespace Biblioteca.Content
{
    public class LibrosController : Controller





    {
        private IRepositorioLibros _RepositorioLibros;
        private IRepositorioGenero _RepositorioGenero;
        private IRepositorioMarca _RepositorioMarca;
        private IRepositorioEstado _RepositorioEstado;
        

        public LibrosController() {

            if(_RepositorioLibros == null)
            {
                _RepositorioLibros = new RepositorioLibros();
            }
            if (_RepositorioGenero == null)
            {
                _RepositorioGenero = new RepositorioGenero();
            }
            if (_RepositorioMarca == null)
            {
                _RepositorioMarca = new RepositorioMarca();
            }
            if (_RepositorioEstado == null)
            {
                _RepositorioEstado = new RepositorioEstado();
            }


        }




        // GET: Libros
        public ActionResult Index()
        {

    

          
            return View();
        }




        public JsonResult ShowTeam(string valor, string Dife, int numPagina)
        {

            var listarLibros = _RepositorioLibros.ObtenerTodosLibros();


           
            string Paginador = "";


           

            List<object[]> datos = new List<object[]>();
           

            string Filtrar = "  ";

            foreach (var data in listarLibros)
            {


                Filtrar += "<center>" + "<tr>" +
                "<td>" + data.Id_Libro + "</td>" +
                 "<td>" + data.Titulo + "</td>" +
                  "<td>" + data.Autor + "</td>" +
                 "<td>" + data.Genero + "</td>" +
                "<td>" + data.Marca + "</td>" +
                  "<td>" + data.Nom_Estado + "</td>" +

                   "<td>" + "<a class='btn btn-success' data-toggle='modal' data-target='#EditTeam' onclick='EditTeam(" + data.Id_Libro + ")'>Editar</a>" + "</td>";
                        

            }

           
            object[] Mostrar = { Filtrar, Paginador };

            datos.Add(Mostrar);
            var retorno = Json(Mostrar);
            return retorno;


        }


        public JsonResult EditTeam(int id)


        {

           var    Obtener   = _RepositorioLibros.ObtenerLibrosId(id);

            

           
            object[] Mostrar = {Obtener };


            var retorno = Json(Mostrar);
            return retorno;



        }




        public JsonResult ValidarComplemento(string valores)
        {

            
            List<object[]> Info = new List<object[]>();
            var retorno = Json(Info);



            switch (valores)
            {



                case "Estado":



                  


                  var  Estado = _RepositorioEstado.ObtenerTodosEstado(); 

                    retorno = Json(Estado);
                    break;

                case "Marca":





                    var Marca = _RepositorioMarca.ObtenerTodosMarca();


                    retorno = Json(Marca);


                    break;


                case "Genero":


                    var Genero = _RepositorioGenero.ObtenerTodosGenero();


                  


                    retorno = Json(Genero);


                    break;




            }

            return retorno;
        }



        public string SaveTeam( int Id ,string Titulo, string Autor, string Mar, string Genero,   string State, string difference)
        {
            var Save = "Save";

            ModeloEstado ConsuEstado = _RepositorioEstado.ObtenerEstadoNom(State);
            ModeloGenero ConsuGenero = _RepositorioGenero.ObtenerGeneroNom(Genero);
            ModeloMarca ConsuMarca = _RepositorioMarca.ObtenerMarcaNom(Mar);

            if (difference == "Create")
            {
               
                ModeloLibro Team = new ModeloLibro()
                {
                    
                    Id_Libro = Id,
                    Titulo = Titulo,
                    Id_Genero = ConsuGenero.Id_Genero,
                    Genero = Genero,
                    Id_Marca = ConsuMarca.Id_Marca,
                    Marca = Mar,
                    Id_Estado = ConsuEstado.Id_Estado,
                    Nom_Estado = State,
                    Autor = Autor,
                };
                _RepositorioLibros.AgregarLibros(Team);

                }
                if (difference == "Edit")
            {



                ModeloLibro Team = new ModeloLibro()
                {
                    Id_Libro = Id,
                    Titulo = Titulo,
                    Id_Genero = ConsuGenero.Id_Genero,
                    Genero = Genero,
                    Id_Marca = ConsuMarca.Id_Marca,
                    Marca = Mar,
                    Id_Estado = ConsuEstado.Id_Estado,
                    Nom_Estado = State,
                    Autor = Autor,
                };

                _RepositorioLibros.EditarLibros(Team);
               

            }






           















            return Save;
        }




    }
}