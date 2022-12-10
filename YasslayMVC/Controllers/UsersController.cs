using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using YasslayMVC.Models;

namespace YasslayMVC.Controllers
{
    public class UsersController : Controller
    {
        string connectionString = @"Data Source=DESKTOP-9MQ1M1N\SQLEXPRESS;Initial Catalog=Yasslay;Integrated Security=True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblUsers = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM UsersTable", sqlCon);
                sqlDa.Fill(dtblUsers);

            }
            return View(dtblUsers);
        }

        [HttpGet]
        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View(new UsersModel());
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersModel usersModel)
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
                sqlCmd.Parameters.AddWithValue("@State", usersModel.State);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
