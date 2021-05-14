using ProductsShowcase.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsShowcase.Services
{
    public class ProductsDAO : IProductDataService
    {
        // Treats all slashes as literals by putting @
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Delete(ProductModel product)
        {
            int newIdNumber = -1;

            string sqlStatement = "DELETE FROM dbo.Products WHERE Id = @Id";

            using (SqlConnection conneciton = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, conneciton);
                command.Parameters.AddWithValue("@Id", product.Id);


                try
                {
                    conneciton.Open();
                    // It will return a value of the first column of whatever was changed there.
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return newIdNumber;

        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> foundProducts = new List<ProductModel>();
            
            string sqlStatement = "SELECT * FROM dbo.Products";

            using (SqlConnection conneciton = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, conneciton);
                try 
                {
                    conneciton.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) 
                    {
                        foundProducts.Add(new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Description = (string)reader[3]});
                    }
                }catch (Exception ex) 
                {
                    Console.WriteLine(ex);
                }
            }

            return foundProducts;
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel foundProduct = null;

            string sqlStatement = "SELECT * FROM dbo.Products WHERE Id = @Id";

            using (SqlConnection conneciton = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, conneciton);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    conneciton.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProduct = new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Description = (string)reader[3] };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return foundProduct;
        }

        public int Insert(ProductModel product)
        {
            int newIdNumber = -1;

            string sqlStatement = "INSERT INTO dbo.Products (Name, Price, Description) VALUES (@Name, @Price, @Description)";

            using (SqlConnection conneciton = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, conneciton);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);


                try
                {
                    conneciton.Open();
                    // It will return a value of the first column of whatever was changed there.
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return newIdNumber;
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            string sqlStatement = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";

            using (SqlConnection conneciton = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, conneciton);
                // % is a wild card character so even if the searchterm is not completely matching there would still be results
                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');

                try
                {
                    conneciton.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel { Id = (int)reader[0], Name = (string)reader[1], Price = (decimal)reader[2], Description = (string)reader[3] });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return foundProducts;
        }

        public int Update(ProductModel product)
        {
            int newIdNumber = -1;

            string sqlStatement = "UPDATE dbo.Products SET Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id";

            using (SqlConnection conneciton = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, conneciton);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Id", product.Id);


                try
                {
                    conneciton.Open();
                    // It will return a value of the first column of whatever was changed there.
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return newIdNumber;
        }
    }
}
