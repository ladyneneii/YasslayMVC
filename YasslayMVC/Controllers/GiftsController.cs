using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace YasslayMVC.Controllers
{
    public class GiftsController : Controller
    {
        string connectionString = @"Data Source=DESKTOP-9MQ1M1N\SQLEXPRESS;Initial Catalog=Yasslay;Integrated Security=True";
        [HttpGet]
        public ActionResult Index(int id)
        {
            DataTable dtblUsers = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM GiftsTable", sqlCon);
                sqlDa.Fill(dtblUsers);

            }
            return View(dtblUsers);
        }

        // GET: GiftsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GiftsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: GiftsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GiftsController/Edit/5
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

        // GET: GiftsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GiftsController/Delete/5
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
