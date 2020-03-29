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

        public LibrosController() {

            if(_RepositorioLibros == null)
            {
                _RepositorioLibros = new RepositorioLibros();
            }


        }




        // GET: Libros
        public ActionResult Index()
        {
            var listaLibros = _RepositorioLibros.ObtenerTodosLibros();
            return View(listaLibros);
        }
    }
}