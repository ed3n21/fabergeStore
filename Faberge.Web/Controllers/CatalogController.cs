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
    }
}