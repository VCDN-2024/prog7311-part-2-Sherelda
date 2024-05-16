using Microsoft.AspNetCore.Mvc;
using St10083869.prog7311.part2.Models;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;

namespace St10083869.prog7311.part2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
		public User currentUser;

        public IActionResult Index(IFormCollection collection)
        {
			if(collection["auth"] != "") {
				
				var connectionString = "Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=farmers;MultipleActiveResultSets=True;Integrated Security=True;Encrypt=False";
				SqlConnection _con = new SqlConnection(connectionString);

				ViewData["auth"] = collection["auth"];

				if (collection["auth"] == "login")
				{
					var email = collection["log_email"];
					var password = collection["log_password"];	
					var user_type = collection["log_user_type"];
					Console.WriteLine(user_type);

					var count = 0;
					string queryStatement, url;
					if(user_type == "farmer") {
						queryStatement = "SELECT * FROM farmers where email='" + email + "' and password='" + password + "'";
						url = "/Farmers/Index?username=" + email;
					} else
					{
                        queryStatement = "SELECT * FROM employees where email='" + email + "' and password='" + password + "'";
                        url = "/Employee/Index?username=" + email;
                    }

					
					_con.Open();

					SqlCommand _cmd1 = new SqlCommand(queryStatement, _con);
					SqlDataReader reader1 = _cmd1.ExecuteReader();
					while (reader1.Read())
					{
						count++;
						// login successful
						ViewData["username"] = email;
						ViewData["login_msg"] = "successfull login";
						//string url = "Employee/Index?username=" + email;
						return Redirect(url);
					}
					//reader1.Close();
					//_cmd1.Dispose();
					_con.Close();

					// if no record is found
					if(count == 0)
					{
						ViewData["login_error"] = "The username you provided does not exist!!";
					}

				} else if (collection["auth"] == "register")
                {
					var email = collection["reg_email"];
					var password = collection["reg_password"];
					var name = collection["reg_fullname"];
					var user_type = collection["reg_user_type"];

					var count = 0;
					var count2 = 0;

					// ------- check if the email already exists in farmers table
					string queryStatement = "SELECT * FROM dbo.farmers WHERE email='" + email + "';";
					_con.Open();

					SqlCommand _cmd2 = new SqlCommand(queryStatement, _con);
					SqlDataReader reader2 = _cmd2.ExecuteReader();
					while (reader2.Read())
					{
						count++;
					}

					// ------- check if the email already exists in employees table
					queryStatement = "SELECT * FROM dbo.employees WHERE email='" + email + "';";
					_cmd2 = new SqlCommand(queryStatement, _con);
					reader2 = _cmd2.ExecuteReader();
					while (reader2.Read())
					{
						count2++;
					}
					//reader2.Close();
					//_cmd2.Dispose();
					_con.Close();
					// ######################################################
					if (count > 0 || count2 > 0)
					{
						ViewData["register_error"] = "The email you entered already exists!!";
					}
					else
					{
						ViewData["email"] = email;
						String INSERTQUERY = "";

						if (user_type == "farmer")
						{
							ViewData["user_type"] = "farmer";
							INSERTQUERY = "insert into farmers(email, name, password, username) values('" + email + "', '" + name + "', '" + password + "', '" + email + "')";
						}
						else
						{
							ViewData["user_type"] = "employee";
							INSERTQUERY = "insert into employees(email, name, password, username) values('" + email + "', '" + name + "', '" + password + "', '" + email + "')";
						}

						// add new user
						try
						{
							_con.Open();
							SqlCommand _cmd3 = new SqlCommand(INSERTQUERY, _con);
							_cmd3.CommandText = INSERTQUERY;
							if (_cmd3.ExecuteNonQuery() == 1)
							{
								ViewData["register_msg"] = "Registration successful. Proceed to login";
							}
							else
							{
								ViewData["register_error"] = "DATA NOT INSERTED SUCCESSFULLY";
							}

						}
						catch (SqlException e)
						{
							ViewData["register_error"] = e.ToString();
							//throw;
						} finally {
							//_cmd3.Dispose();
							_con.Close();
						}
						
					}
				}
			}
            return View();
        }


		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

	public class User
	{
		public string Email { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string UserType { get; set; }

	}
}
