using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using AdventureWorksSales.Core.Data;

namespace AdventureWorksSales.Web.Controllers
{
    public class SalesOrdersController : Controller
    {
        private AdventureWorksSalesEntities db = new AdventureWorksSalesEntities();

        // GET: SalesOrders
        public async Task<ActionResult> Index()
        {
            return View(await db.SalesOrders.ToListAsync());
        }

        // GET: SalesOrders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = await db.SalesOrders.FindAsync(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // GET: SalesOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SalesOrderID,SalesOrderDetailID,CarrierTrackingNumber,OrderQty,ProductID,SpecialOfferID,UnitPrice,UnitPriceDiscount,LineTotal,rowguid,ModifiedDate")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                db.SalesOrders.Add(salesOrder);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(salesOrder);
        }

        // GET: SalesOrders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = await db.SalesOrders.FindAsync(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // POST: SalesOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SalesOrderID,SalesOrderDetailID,CarrierTrackingNumber,OrderQty,ProductID,SpecialOfferID,UnitPrice,UnitPriceDiscount,LineTotal,rowguid,ModifiedDate")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesOrder).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(salesOrder);
        }

        // GET: SalesOrders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = await db.SalesOrders.FindAsync(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // POST: SalesOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SalesOrder salesOrder = await db.SalesOrders.FindAsync(id);
            db.SalesOrders.Remove(salesOrder);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
