using AutoMapper;
using Faberge.BL.Models;
using Faberge.BL.Services;
using Faberge.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Faberge.Web.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;
        private readonly IMapper _mapper;

        public CatalogController(ICatalogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: Catalog
        public ActionResult Index()
        {
            IEnumerable<CatalogModel> catalogs = _mapper.Map<IEnumerable<CatalogModel>>(_service.Get());
            return View(catalogs);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CatalogModel catalog)
        {
            if (ModelState.IsValid)
            {
                _service.Create(_mapper.Map<CatalogBL>(catalog));
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            CatalogModel catalog = _mapper.Map<CatalogModel>(_service.Get(id));
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CatalogModel product)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(_mapper.Map<CatalogBL>(product));
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}