using AutoMapper;
using Faberge.BL.Models;
using Faberge.BL.Services;
using Faberge.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Faberge.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ICatalogService _catalogService;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper, ICatalogService catalogService)
        {
            _service = service;
            _mapper = mapper;
            _catalogService = catalogService;
        }

        public ActionResult Index(int? page, int? CatalogId)
        {
            int pageSize = 3;
            int pageNumber = page ?? 1;

            ViewBag.Catalogs = _mapper.Map<IEnumerable<CatalogModel>>(_catalogService.Get());

            IEnumerable<ProductModel> products;
            if (CatalogId == null)
                products = _mapper.Map<IEnumerable<ProductModel>>(_service.Get());
            else 
                products = _mapper.Map<IEnumerable<ProductModel>>(_service.Get().Where(prod => prod.CatalogId == CatalogId.Value));
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                _service.Create(_mapper.Map<ProductBL>(product));
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var product = _service.Get(id);

            if (product != null)
            {
                _service.Delete(id);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            ProductModel model = _mapper.Map<ProductModel>(_service.Get(id));
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ProductModel product = _mapper.Map<ProductModel>(_service.Get(id));
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(_mapper.Map<ProductBL>(product));
                return RedirectToAction("Details", new { id = product.Id});
            }
            return View();
        }
    }
}