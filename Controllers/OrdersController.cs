using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaIntegraMedia.Data;
using PruebaIntegraMedia.Models;

namespace PruebaIntegraMedia.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orders.Include(o => o.Client).Include(o => o.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Employee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "Full_Name");
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "Full_Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDate,ClientID,EmployeeID")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Edit", "Orders", new { id = order.ID });

            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "Full_Name", order.ClientID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "Full_Name", order.EmployeeID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "Full_Name", order.ClientID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "Full_Name", order.EmployeeID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OrderDate,ClientID,EmployeeID")] Order order)
        {
            if (id != order.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "CreditCard", order.ClientID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "First_Name", order.EmployeeID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Employee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: OrderDetails
        public async Task<IActionResult> OrderDetails(int OrderId)
        {
            var applicationDbContext = _context.OrderDetails.Include(p => p.Product)
                .Where(x => x.OrderId == OrderId);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderDetails
        public async Task<IActionResult> Print(int id)
        {
            var orderDetails = _context.OrderDetails.Include(p => p.Product)
                .Where(x => x.OrderId == id);
            var OrderId = orderDetails.FirstOrDefault().OrderId;
            var Order = _context.Orders.Where(x => x.ID == OrderId).FirstOrDefault();
            ViewBag.Order = Order;
            ViewBag.Client = _context.Clients.Where(x => x.ID == Order.ClientID).FirstOrDefault();
            ViewBag.Emproyee = _context.Employees.Where(x => x.ID == Order.EmployeeID).FirstOrDefault();
            return View(await orderDetails.ToListAsync());
        }

        public async Task<IActionResult> OrderDetailAdd(int ProductId, int OrderId)
        {
            var Product = _context.Products
                .SingleOrDefault(x => x.ID == ProductId);

            var OrderDetailQuery = _context.OrderDetails
            .SingleOrDefault(x => x.OrderId == OrderId && x.ProductId == ProductId);

            if (OrderDetailQuery == null )
            {
                // Create a new cart delivery item if not item exists

                OrderDetail NewOrderDetail = new OrderDetail
                {
                    OrderId = OrderId,
                    ProductId = ProductId,
                    Price = Product.Unit_Price,
                    Quantity = 1

                };
                _context.OrderDetails.Add(NewOrderDetail);
            }
            else
            {
                OrderDetailQuery.Quantity = OrderDetailQuery.Quantity + 1;
            }

            _context.SaveChanges();

            return RedirectToAction("Edit", "Orders", new { id = OrderId });
        }

        public async Task<IActionResult> OrderDetailDelete(int OrderDetailId, int OrderId)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(OrderDetailId);
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", "Orders", new { id = OrderId });
        }


        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.ID == id);
        }
    }
}
