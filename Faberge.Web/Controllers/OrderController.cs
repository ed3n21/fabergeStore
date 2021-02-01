using AutoMapper;
using Faberge.BL.Models;
using Faberge.BL.Services;
using Faberge.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Faberge.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public OrderController(IOrderService service, IMapper mapper, IProductService productService)
        {
            _service = service;
            _mapper = mapper;
            _productService = productService;
        }

        // GET: Order
        public ActionResult Index()
        {
            var orders = _mapper.Map<IEnumerable<OrderModel>>(_service.Get(include: "Product").Where(order => order.UserId == User.Identity.GetUserId()));

            return View(orders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create(int productId)
        {
            var product = _mapper.Map<ProductModel>(_productService.Get(productId));
            //ViewBag.Product = product;
            OrderModel order = new OrderModel()
            {
                Date = DateTime.Now,
                DeliveryDate = DateTime.Now,
                Product = product,
                ProductId = product.Id,
                UserId = User.Identity.GetUserId()
            };


            return View(order);
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(OrderModel order)
        {
            if (ModelState.IsValid)
            {
                order.Product = null;
                _service.Create(_mapper.Map<OrderBL>(order));
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrderModel order)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(_mapper.Map<OrderBL>(order));
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
