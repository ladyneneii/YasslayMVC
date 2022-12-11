using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using YasslayMVC.Models;

namespace YasslayMVC.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = @"Data Source=DESKTOP-9MQ1M1N\SQLEXPRESS;Initial Catalog=Yasslay;Integrated Security=True";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        // GET: HomeController/Register
        public ActionResult Register()
        {
            return View(new UsersModel());
        }

        // POST: HomeController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UsersModel usersModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO UsersTable VALUES(@FirstName,@LastName,@Email,@Password,@UserType,@State)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@FirstName", usersModel.FirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", usersModel.LastName);
                sqlCmd.Parameters.AddWithValue("@Email", usersModel.Email);
                sqlCmd.Parameters.AddWithValue("@Password", usersModel.Password);
                sqlCmd.Parameters.AddWithValue("@UserType", usersModel.UserType);
                sqlCmd.Parameters.AddWithValue("@State", "Active");
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        // GET: HomeController/Register
        public ActionResult Login()
        {
            return View(new UsersModel());
        }

        public ActionResult Login(UsersModel usersModel)
        {
            DataTable dtblUser = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM UsersTable WHERE Email = @Email AND Password = @Password";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Email", usersModel.Email);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Password", usersModel.Password);
                sqlDa.Fill(dtblUser);
            }
            if (dtblUser.Rows.Count == 1)
            {
                if (string.Compare(dtblUser.Rows[0][6].ToString(), "Active") == 0)
                {
                    if (string.Compare(dtblUser.Rows[0][5].ToString(), "Seller") == 0)
                    {
                        return RedirectToAction("Index", "Gifts", new { @id = Convert.ToInt32(dtblUser.Rows[0][0].ToString()) });
                    }
                    else if (string.Compare(dtblUser.Rows[0][5].ToString(), "Non-Seller") == 0)
                    {
                        return RedirectToAction("Index", "Confessions", new { @id = Convert.ToInt32(dtblUser.Rows[0][0].ToString()) });
                    }
                    else if (string.Compare(dtblUser.Rows[0][5].ToString(), "Admin") == 0)
                    {
                        return RedirectToAction("Index", "Users", new { @id = Convert.ToInt32(dtblUser.Rows[0][0].ToString()) });
                    }
                    else
                    {
                        return RedirectToAction("Error");
                    }
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            else
            {
                return RedirectToAction("Error");
            }   
        }

        public ActionResult Settings(int id)
        {
            @ViewBag.LinkableId = id;
            UsersModel usersModel = new UsersModel();
            DataTable dtblUser = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM UsersTable WHERE UserID = @UserID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@UserID", id);
                sqlDa.Fill(dtblUser);
            }
            if (dtblUser.Rows.Count == 1)
            {
                usersModel.UserID = Convert.ToInt32(dtblUser.Rows[0][0].ToString());
                usersModel.FirstName = dtblUser.Rows[0][1].ToString();
                usersModel.LastName = dtblUser.Rows[0][2].ToString();
                usersModel.Email = dtblUser.Rows[0][3].ToString();
                usersModel.Password = dtblUser.Rows[0][4].ToString();
                usersModel.UserType = dtblUser.Rows[0][5].ToString();
                return View(usersModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Settings(UsersModel usersModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE UsersTable SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Password = @Password, UserType = @UserType WHERE UserID = @UserID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", usersModel.UserID);
                sqlCmd.Parameters.AddWithValue("@FirstName", usersModel.FirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", usersModel.LastName);
                sqlCmd.Parameters.AddWithValue("@Email", usersModel.Email);
                sqlCmd.Parameters.AddWithValue("@Password", usersModel.Password);
                sqlCmd.Parameters.AddWithValue("@UserType", usersModel.UserType);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        public ActionResult Delete_Settings(UsersModel usersModel)
        {
            DataTable dtblUser = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM UsersTable WHERE Email = @Email AND Password = @Password";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Email", usersModel.Email);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Password", usersModel.Password);
                sqlDa.Fill(dtblUser);
            }
            if (dtblUser.Rows.Count == 1)
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM UsersTable WHERE Email = @Email AND Password = @Password";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                    sqlDa.SelectCommand.Parameters.AddWithValue("@Email", usersModel.Email);
                    sqlDa.SelectCommand.Parameters.AddWithValue("@Password", usersModel.Password);
                    sqlDa.Fill(dtblUser);
                }
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            else
            {
                return RedirectToAction("Settings", "Home", new { area = "" });
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}