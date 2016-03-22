using SimpleApp.Mvc.Infra.DataAccess;
using SimpleApp.Mvc.Infra.Model;
using System.Collections.Generic;

namespace SimpleApp.Mvc.Infra.Business
{
	public class ProductBusiness
	{
		#region [ Add(Product product) ]
		public void Add(Product product)
		{
			//aqui ficaria alguma validação de regra de negócio
			ProductDal dao = new ProductDal();

			dao.Add(product);
		} 
		#endregion

		#region [ FindById(int id) ]
		public Product FindById(int id)
		{
			ProductDal dao = new ProductDal();

			Product product = dao.FindById(id);

			return product;
		} 
		#endregion

		#region [ Update(Product product) ]
		public void Update(Product product)
		{
			//aqui ficaria alguma validação de regra de negócio
			ProductDal dao = new ProductDal();

			dao.Update(product);
		} 
		#endregion

		#region [ List<Product> GetAll() ]
		public List<Product> GetAll()
		{
			ProductDal dao = new ProductDal();

			List<Product> lista = dao.GetAll();

			return lista;
		} 
		#endregion

		#region [ Delete(int id) ]
		public void Delete(int id)
		{
			ProductDal dao = new ProductDal();

			dao.Delete(id);
		} 
		#endregion
	}
}