using SimpleApp.Mvc.Infra.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SimpleApp.Mvc.Infra.DataAccess
{
	public class ProductDal
	{
		private string connectionstring = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

		#region [ Add(Product product) ]
		public void Add(Product product)
		{
			using (IDbConnection connection = new SqlConnection(connectionstring))
			using (IDbCommand command = connection.CreateCommand())
			{
				command.CommandText = "insert into Product (Name, Description) values (@name, @description)";

				IDbDataParameter paramName = command.CreateParameter();
				paramName.ParameterName = "name";
				paramName.Value = product.Name;

				IDbDataParameter paramDescription = command.CreateParameter();
				paramDescription.ParameterName = "description";
				paramDescription.Value = product.Description;

				command.Parameters.Add(paramName);
				command.Parameters.Add(paramDescription);

				connection.Open();
				command.ExecuteNonQuery();
			}
		} 
		#endregion

		#region [ FindById(int id) ]
		public Product FindById(int id)
		{
			using (IDbConnection connection = new SqlConnection(connectionstring))
			using (IDbCommand command = connection.CreateCommand())
			{
				command.CommandText = "select * from Product where Id = @id";

				IDbDataParameter paramId = command.CreateParameter();
				paramId.ParameterName = "id";
				paramId.Value = id;

				command.Parameters.Add(paramId);

				connection.Open();
				IDataReader dr = command.ExecuteReader();

				Product product = null;
				if (dr.Read())
				{
					product = new Product();
					product.Id = Convert.ToInt32(dr["Id"]);
					product.Name = dr["Name"].ToString();
					product.Description = dr["Description"].ToString();
				}

				return product;
			}
		} 
		#endregion

		#region [ Update(Product product) ]
		public void Update(Product product)
		{
			using (IDbConnection connection = new SqlConnection(connectionstring))
			using (IDbCommand command = connection.CreateCommand())
			{
				command.CommandText = "update Product set Name = @name, Description = @description where Id = @id";

				IDbDataParameter paramId = command.CreateParameter();
				paramId.ParameterName = "id";
				paramId.Value = product.Id;

				IDbDataParameter paramName = command.CreateParameter();
				paramName.ParameterName = "name";
				paramName.Value = product.Name;

				IDbDataParameter paramDescription = command.CreateParameter();
				paramDescription.ParameterName = "description";
				paramDescription.Value = product.Description;

				command.Parameters.Add(paramId);
				command.Parameters.Add(paramName);
				command.Parameters.Add(paramDescription);

				connection.Open();
				command.ExecuteNonQuery();
			}
		} 
		#endregion

		#region [ List<Product> GetAll() ]
		public List<Product> GetAll()
		{
			using (IDbConnection connection = new SqlConnection(connectionstring))
			using (IDbCommand command = connection.CreateCommand())
			{
				command.CommandText = "select * from Product";

				connection.Open();
				IDataReader dr = command.ExecuteReader();

				List<Product> listProduct = new List<Product>();
				while (dr.Read())
				{
					Product product = new Product();
					product = new Product();
					product.Id = Convert.ToInt32(dr["id"]);
					product.Name = dr["name"].ToString();
					product.Description = dr["description"].ToString();

					listProduct.Add(product);
				}

				return listProduct;
			}
		} 
		#endregion

		#region [ Delete(int id) ]
		public void Delete(int id)
		{
			using (IDbConnection connection = new SqlConnection(connectionstring))
			using (IDbCommand command = connection.CreateCommand())
			{
				command.CommandText = "delete from product where id = @id";

				IDbDataParameter paramId = command.CreateParameter();
				paramId.ParameterName = "id";
				paramId.Value = id;

				command.Parameters.Add(paramId);

				connection.Open();
				command.ExecuteNonQuery();
			}
		} 
		#endregion
	}
}