using ConexaoBD.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConexaoBD.WEB.MVC.Controllers
{
    public class MoradaController : Controller
    {
        // GET: MoradaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MoradaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MoradaController/Create
        public ActionResult Create()
        {
            var morada = new Morada();
            return View(morada);
        }

        // POST: MoradaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MoradaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MoradaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MoradaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MoradaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
