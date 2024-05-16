using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace St10083869.prog7311.part2.Controllers
{
    public class Farmers : Controller
    {
        public string currentFarmer = "";
        public SqlConnection _con = new SqlConnection("Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=farmers;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=False");
        public IActionResult Index(IFormCollection collection)
        {
            currentFarmer = Request.QueryString.ToString().Split("=")[1];
            ViewData["username"] = currentFarmer;
            

            // edit request
            if (collection["post_type"] == "edit")
            {
                var id = collection["id"];
                var name = collection["name"];
                var prod = collection["production_date"].ToString();
                var cat = collection["category"];
                // edit product
                try
                {
                    string INSERTQUERY = "update products set name='"+name+"', category='"+cat+"', production_date='"+prod+"' where id="+id+";";
                    _con.Open();
                    SqlCommand _cmd3 = new SqlCommand(INSERTQUERY, _con);
                    _cmd3.CommandText = INSERTQUERY;
                    if (_cmd3.ExecuteNonQuery() == 1)
                    {
                        ViewData["insert_msg"] = "Product updated successfully.";
                    }
                    else
                    {
                        ViewData["insert_msg"] = "PRODUCT NOT UPDATED!!!";
                    }

                }
                catch (SqlException e)
                {
                    ViewData["insert_msg"] = e.ToString();
                    //throw;
                }
                finally
                {
                    //_cmd3.Dispose();
                    _con.Close();
                }

                Console.WriteLine("edit: " + id);
            }
            else if (collection["post_type"] == "delete")
            {
                var id = collection["id"];
                try
                {
                    string INSERTQUERY = "delete from products where id=" + id + ";";
                    _con.Open();
                    SqlCommand _cmd3 = new SqlCommand(INSERTQUERY, _con);
                    _cmd3.CommandText = INSERTQUERY;
                    if (_cmd3.ExecuteNonQuery() == 1)
                    {
                        ViewData["insert_msg"] = "Product deleted successfully.";
                    }
                    else
                    {
                        ViewData["insert_msg"] = "PRODUCT NOT Deleted!!!";
                    }

                }
                catch (SqlException e)
                {
                    ViewData["insert_msg"] = e.ToString();
                    //throw;
                }
                finally
                {
                    //_cmd3.Dispose();
                    _con.Close();
                }


                Console.WriteLine("delete: " + id);
            }
            else if (collection["post_type"] == "add")
            {
                var name = collection["name"];
                var prod = collection["production_date"];
                var cat = collection["category"];
                var image = collection["image"];

                // add new product
                try
                {
                    string INSERTQUERY = "insert into products(farmer, name, category, production_date, image) values('" + currentFarmer + "', '" + name + "', '" + cat + "', '" + prod + "', '" + image + "')";
                    _con.Open();
                    SqlCommand _cmd3 = new SqlCommand(INSERTQUERY, _con);
                    _cmd3.CommandText = INSERTQUERY;
                    if (_cmd3.ExecuteNonQuery() == 1)
                    {
                        ViewData["insert_msg"] = "New Product added successfully.";
                    }
                    else
                    {
                        ViewData["insert_msg"] = "PRODUCT NOT INSERTED SUCCESSFULLY!!!";
                    }

                }
                catch (SqlException e)
                {
                    ViewData["insert_msg"] = e.ToString();
                    //throw;
                }
                finally
                {
                    //_cmd3.Dispose();
                    _con.Close();
                }

                Console.WriteLine("adding: " + name);
            }

            ViewData["products"] = GetMyProducts();

            return View();
        }

        public IActionResult Logout()
        {
            currentFarmer = "";
            ViewData["login_msg"] = "";
            ViewData["register_msg"] = "";
            return Redirect("~/");
        }

        public List<Product> GetMyProducts()
        {
            List<Product> products = new List<Product>();
            // get all farmers from database
            _con.Open();
            string queryStatement = "SELECT * FROM dbo.products WHERE farmer='" + currentFarmer +"'";
            SqlCommand _cmd1 = new SqlCommand(queryStatement, _con);
            SqlDataReader reader1 = _cmd1.ExecuteReader();
            while (reader1.Read())
            {
                products.Add(new Product(
                    int.Parse(reader1["id"].ToString()),
                    reader1["name"].ToString(),
                    reader1["category"].ToString(),
                    reader1["production_date"].ToString(),
                    reader1["image"].ToString()
                ));
            }
            reader1.Close();
            _cmd1.Dispose();
            _con.Close();

            return products;
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public string Production_date { get; set; }
        public string Image { get; set; }

        public Product(int id, string name, string cat, string dt, string img)
        {
            this.Id = id;
            this.Name = name;
            this.Category = cat;
            this.Image = img;
            this.Production_date =  dt;

        }
    }
}
