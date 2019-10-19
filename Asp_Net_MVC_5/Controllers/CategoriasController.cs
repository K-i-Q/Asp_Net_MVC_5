using Asp_Net_MVC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp_Net_MVC_5.Controllers
{
    public class CategoriasController : Controller
    {
        #region Lista de Categorias
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria()
            {
                CategoriaId = 1,
                Nome = "Notebooks"
            },
            new Categoria()
            {
                CategoriaId = 2,
                Nome = "Monitores"
            },
            new Categoria(){
                CategoriaId = 3,
                Nome = "Impressoras"
            },
            new Categoria(){
                CategoriaId = 4,
                Nome = "Mouses"
            },
            new Categoria()
            {
                CategoriaId = 5,
                Nome = "Desktops"
            }
        };
        #endregion

        #region Métodos GET
        public ActionResult Index() => View(categorias);

        public ActionResult Create() => View();

        public ActionResult Edit(long id) => View(categorias.Where(m => m.CategoriaId == id).First());

        public ActionResult Details(long id) => View(categorias.Where(m => m.CategoriaId == id).First());

        public ActionResult Delete(long id) => View(categorias.Where(m => m.CategoriaId == id).First());
        #endregion

        #region Métodos POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categorias.Add(categoria);
            categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias[categorias.IndexOf(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First())] = categoria;

            //Método alternativo para edição da categoria
            //categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            //categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            return RedirectToAction("Index");
        }
        #endregion

    }
}