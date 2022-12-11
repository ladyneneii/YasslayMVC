﻿using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
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
                sqlCmd.Parameters.AddWithValue("@State", usersModel.State);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}