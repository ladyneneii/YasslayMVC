using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using YasslayMVC.Models;

namespace YasslayMVC.Controllers
{
    public class GiftsController : Controller
    {
        string connectionString = @"Data Source=DESKTOP-9MQ1M1N\SQLEXPRESS;Initial Catalog=Yasslay;Integrated Security=True";
        [HttpGet]
        public ActionResult Index(int id)
        {
            DataTable dtblGifts = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM GiftsTable", sqlCon);
                sqlDa.Fill(dtblGifts);
            }
            ViewBag.LinkableId = id;

            return View(dtblGifts);
        }

        [HttpGet]
        // GET: GiftsController/Create
        public ActionResult Create(int id)
        {
            ViewBag.LinkableId = id;

            return View(new GiftsModel());
        }
        
        // POST: GiftsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GiftsModel giftsModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO GiftsTable VALUES(@GiftName,@Price,@QuantityLeft,@Status)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@GiftName", giftsModel.GiftName);
                sqlCmd.Parameters.AddWithValue("@Price", giftsModel.Price);
                sqlCmd.Parameters.AddWithValue("@QuantityLeft", giftsModel.QuantityLeft);
                sqlCmd.Parameters.AddWithValue("@Status", giftsModel.Status);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Gifts", new { @id = ViewBag.LinkableId });
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
