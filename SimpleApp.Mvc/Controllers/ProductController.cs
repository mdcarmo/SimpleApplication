using SimpleApp.Mvc.Infra.Business;
using SimpleApp.Mvc.Infra.Model;
using SimpleApp.Mvc.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SimpleApp.Mvc.Controllers
{
    public class ProductController : Controller
    {
		#region [ Index() ]
		public ActionResult Index()
		{
			ProductBusiness business = new ProductBusiness();
			List<Product> products = business.GetAll();

			List<ProductViewModel> productsViewModel = new List<ProductViewModel>();

			foreach (Product product in products)
				productsViewModel.Add(new ProductViewModel() { Id = product.Id, Name = product.Name, Description = product.Description });
	
			return View(productsViewModel);
		} 
		#endregion

		#region [ Details(int id) ]
		public ActionResult Details(int id)
		{
			ProductViewModel productViewModel = GenerateProductViewModel(id);

			return View(productViewModel);
		} 
		#endregion

     	#region [ Create() ]
		public ActionResult Create()
		{
			return View();
		} 
		#endregion

		#region [ Create(ProductViewModel model) ]
		[HttpPost]
		public ActionResult Create(ProductViewModel model)
		{
			try
			{
				ProductBusiness business = new ProductBusiness();

				Product product = new Product()
				{
					Name = model.Name,
					Description = model.Description
				};

				business.Add(product);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		} 
		#endregion

		#region [ Edit(int id) ]
		public ActionResult Edit(int id)
		{
			ProductViewModel productViewModel = GenerateProductViewModel(id);

			return View(productViewModel);
		} 
		#endregion

		#region [ Edit(ProductViewModel model) ]
		[HttpPost]
		public ActionResult Edit(ProductViewModel model)
		{
			try
			{
				ProductBusiness business = new ProductBusiness();

				Product product = new Product()
				{
					Id = model.Id,
					Name = model.Name,
					Description = model.Description
				};

				business.Update(product);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		} 
		#endregion

		#region [ Delete(int id) ]
		public ActionResult Delete(int id)
		{
			ProductViewModel productViewModel = GenerateProductViewModel(id);

			return View(productViewModel);
		}
		#endregion

		#region [ Delete(ProductViewModel model) ]
		[HttpPost]
		public ActionResult Delete(ProductViewModel model)
		{
			try
			{
				ProductBusiness business = new ProductBusiness();
				business.Delete(model.Id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		} 
		#endregion

		#region [ GenerateProductViewModel(int id) ]
		private static ProductViewModel GenerateProductViewModel(int id)
		{
			ProductBusiness business = new ProductBusiness();
			Product product = business.FindById(id);

			ProductViewModel productViewModel = new ProductViewModel()
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description
			};
			return productViewModel;
		}  
		#endregion
    }
}
