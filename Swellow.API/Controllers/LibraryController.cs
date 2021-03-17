using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swellow.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.API.Controllers
{

    [ApiController]
    [Route("api/librarys")]
    public class LibraryController : Controller
    {
        private readonly DbManager _dbManager;

        public LibraryController(DbManager dbManager)
        {
            _dbManager = dbManager;
        }


        // GET: LibraryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LibraryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LibraryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibraryController/Create
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

        // GET: LibraryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LibraryController/Edit/5
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

        // GET: LibraryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LibraryController/Delete/5
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
