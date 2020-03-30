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


            int Numdatos = 0, iniciar = 0, datosporpaginas = 3;
            int cantidad_pag, paginas;
            string Paginador = "";


            //var Db = new ApplicationDbContext();
            //var Enlace = new Enlace();



            List<object[]> datos = new List<object[]>();
            //List<Eqs> Encontrar = new List<Eqs>();



            //var ordenar = Enlace.Eqs.OrderBy(c => c.Id_dispositivo);
            //Numdatos = ordenar.Count();
            //iniciar = (numPagina - 1) * datosporpaginas;

            //if (Dife == "null")
            //{

            //    Encontrar = ordenar.Skip(iniciar).Take(datosporpaginas).ToList(); ;
            //}
            //else
            //if (Dife == "Id")
            //{
            //    Encontrar = ordenar.Where(c => c.Id_dispositivo.StartsWith(valor)).Skip(iniciar).Take(datosporpaginas).ToList();
            //}

            //else if (Dife == "Marca")
            //{
            //    Encontrar = ordenar.Where(c => c.Nom_marca.StartsWith(valor) || c.Procesador.StartsWith(valor)).Skip(iniciar).Take(datosporpaginas).ToList();





            //}



            //if ((Numdatos % datosporpaginas) > 0)
            //{
            //    Numdatos += 4;
            //}
            //cantidad_pag = (Numdatos / datosporpaginas);

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

            //if (valor == "null")
            //{
            //    if (numPagina > 1)
            //    {
            //        paginas = numPagina - 1;
            //        Paginador += "<a class='btn btn-default' onclick='ShowTeam(" + 1 + ',' + "null" + ")'> << </a>" +
            //        "<a class='btn btn-default' onclick='ShowTeam(" + paginas + ',' + ")'> < </a>";
            //    }
            //    if (1 < cantidad_pag)
            //    {
            //        Paginador += "<strong class='btn btn-success'>" + numPagina + ".de." + cantidad_pag + "</strong>";
            //    }
            //    if (numPagina < cantidad_pag)
            //    {
            //        paginas = numPagina + 1;
            //        Paginador += "<a class='btn btn-default' onclick='ShowTeam(" + paginas + ',' + "null" + ")'>  > </a>" +
            //                     "<a class='btn btn-default' onclick='ShowTeam(" + cantidad_pag + ',' + "null" + ")'> >> </a>";
            //    }


            //}


            //return retorno;
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






            //Db.SaveChanges();
















            return Save;
        }




    }
}