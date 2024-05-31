using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace St10083869.prog7311.part2.Controllers
{
	public class Employee : Controller
	{
		public string currentEmployee = "";
		public SqlConnection _con = new SqlConnection("Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=farmers;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=False");
		public IActionResult Index(IFormCollection collection)
		{
			ViewData["username"] = Request.QueryString.ToString().Split("=")[1];
			currentEmployee = Request.QueryString.ToString().Split("=")[1];
			

            // edit request
            if(collection["post_type"] == "edit")
			{
				var name = collection["name"];
                var username = collection["username"];
                var email = collection["email"];

                // edit product
                try
                {
                    //code attribution 
                    //Author:Unknown
                    //Link:https://stackoverflow.com/questions/15062734/insert-in-sql-using-c-sharp 
                    //end
                    string INSERTQUERY = "update farmers set name='" + name + "', username='" + username + "' where email='" + email + "';";
                    _con.Open();
                    SqlCommand _cmd3 = new SqlCommand(INSERTQUERY, _con);
                    _cmd3.CommandText = INSERTQUERY;
                    if (_cmd3.ExecuteNonQuery() == 1)
                    {
                        ViewData["insert_msg"] = "Farmer updated successfully.";
                    }
                    else
                    {
                        ViewData["insert_err"] = "FARMER NOT UPDATED!!!";
                    }

                }
                catch (SqlException e)
                {
                    ViewData["insert_err"] = e.ToString();
                    //throw;
                }
                finally
                {
                    //_cmd3.Dispose();
                    _con.Close();
                }

                Console.WriteLine("edit: " + email + "-" + name + "-" + username);
			} else if(collection["post_type"] == "delete")
			{
                var email = collection["email"];

                try
                {
                    string INSERTQUERY = "delete from farmers where email='" + email + "';";
                    _con.Open();
                    SqlCommand _cmd3 = new SqlCommand(INSERTQUERY, _con);
                    _cmd3.CommandText = INSERTQUERY;
                    if (_cmd3.ExecuteNonQuery() == 1)
                    {
                        ViewData["insert_msg"] = "Farmer deleted successfully.";
                    }
                    else
                    {
                        ViewData["insert_err"] = "FARMER NOT Deleted!!!";
                    }

                }
                catch (SqlException e)
                {
                    ViewData["insert_err"] = e.ToString();
                    //throw;
                }
                finally
                {
                    //_cmd3.Dispose();
                    _con.Close();
                }

                Console.WriteLine("delete: " + email);
            }
            else if (collection["post_type"] == "add")
			{
                var email = collection["email"];
                var username = collection["username"];
                var name = collection["name"];
                var password = collection["password"];

                // add new product
                try
                {
                    //code attribution 
                    //Author:Unknown
                    //Link:https://stackoverflow.com/questions/15062734/insert-in-sql-using-c-sharp 
                    //end
                    string INSERTQUERY = "insert into farmers(email, name, password, username) values('" + email + "', '" + name + "', '" + password + "', '" + username + "')";
                    _con.Open();
                    SqlCommand _cmd3 = new SqlCommand(INSERTQUERY, _con);
                    _cmd3.CommandText = INSERTQUERY;
                    if (_cmd3.ExecuteNonQuery() == 1)
                    {
                        ViewData["insert_msg"] = "New Farmer added successfully.";
                    }
                    else
                    {
                        ViewData["insert_err"] = "Farmer NOT INSERTED SUCCESSFULLY!!!";
                    }

                }
                catch (SqlException e)
                {
                    ViewData["insert_err"] = e.ToString();
                    //throw;
                }
                finally
                {
                    //_cmd3.Dispose();
                    _con.Close();
                }

                Console.WriteLine("adding: " + email);
            }

            ViewData["farmers"] = GetAllFarmers();
            ViewData["products"] = GetAllProducts();

            return View();
		}

		public List<Farmer> GetAllFarmers()
		{
			List<Farmer> farmers = new List<Farmer>();
			// get all farmers from database
			_con.Open();
            //code attribution 
            //Author :
            //Link:https://stackoverflow.com/questions/15124034/out-of-memory-when-reading-a-string-from-sqldatareader
            string queryStatement = "SELECT * FROM dbo.farmers";
			SqlCommand _cmd1 = new SqlCommand(queryStatement, _con);
			SqlDataReader reader1 = _cmd1.ExecuteReader();
			while (reader1.Read())
			{
				farmers.Add(new Farmer(
					reader1["name"].ToString(),
					reader1["email"].ToString(),
					reader1["username"].ToString()
				));
			}
			reader1.Close();
			_cmd1.Dispose();
			_con.Close();

			return farmers;
		}

        public List<Product_> GetAllProducts()
        {
            List<Product_> products = new List<Product_>();
            // get all farmers from database
            _con.Open();
            string queryStatement = "SELECT * FROM dbo.products";
            SqlCommand _cmd1 = new SqlCommand(queryStatement, _con);
            SqlDataReader reader1 = _cmd1.ExecuteReader();
            while (reader1.Read())
            {
                products.Add(new Product_(
                    int.Parse(reader1["id"].ToString()),
                    reader1["name"].ToString(),
                    reader1["category"].ToString(),
                    reader1["production_date"].ToString(),
                    reader1["image"].ToString(),
                    reader1["farmer"].ToString()
                ));
            }
            reader1.Close();
            _cmd1.Dispose();
            _con.Close();

            return products;
        }

        public IActionResult Logout()
        {
            currentEmployee = "";
            ViewData["login_msg"] = "";
            ViewData["register_msg"] = "";
            return Redirect("~/");
        }
	}

	public class Farmer
	{
		public string name { get; set; }
		public string email { get; set; }
		public string username { get; set; }

		public Farmer(string name, string email, string username)
		{
			this.name = name;
			this.email = email;
			this.username = username;
		}
	}

    public class Product_
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Farmer { get; set; }
        public string Category { get; set; }

        public string Production_date { get; set; }
        public string Image { get; set; }

        public Product_(int id, string name, string cat, string dt, string img, string farmer)
        {
            this.Id = id;
            this.Name = name;
            this.Category = cat;
            this.Image = img;
            this.Production_date = dt;
            this.Farmer = farmer;
        }
    }
}
