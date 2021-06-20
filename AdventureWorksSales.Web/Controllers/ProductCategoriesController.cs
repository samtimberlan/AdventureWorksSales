using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using AdventureWorksSales.Core.Data;
using AdventureWorksSales.Services;

namespace AdventureWorksSales.Web.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private ProductCategoryService _productCategoryService;

        public ProductCategoriesController()
        {
            _productCategoryService = new ProductCategoryService();
        }

        // GET: ProductCategories
        public async Task<ActionResult> Index()
        {
            return View(await _productCategoryService.GetAllProductCategoriesAsync());
        }

        // GET: ProductCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = await _productCategoryService.GetProductCategoryById(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // GET: ProductCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                await _productCategoryService.CreateProductCategoryAsync(productCategory);
                return RedirectToAction("Index");
            }

            return View(productCategory);
        }

        // GET: ProductCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = await _productCategoryService.GetProductCategoryById(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductCategoryID,Name,rowguid,ModifiedDate")] ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                await _productCategoryService.UpdateProductCategoryAsync(productCategory);
                return RedirectToAction("Index");
            }
            return View(productCategory);
        }

        // GET: ProductCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategory productCategory = await _productCategoryService.GetProductCategoryById(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _productCategoryService.DeleteProductCategory(id);
            return RedirectToAction("Index");
        }
    }
}
