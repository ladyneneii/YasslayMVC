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
            DataTable dtblGift = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO GiftsTable VALUES(@GiftName,@Price,@QuantityLeft,@Status,@UserID)";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@GiftName", giftsModel.GiftName);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Price", giftsModel.Price);
                sqlDa.SelectCommand.Parameters.AddWithValue("@QuantityLeft", giftsModel.QuantityLeft);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Status", giftsModel.Status);
                sqlDa.SelectCommand.Parameters.AddWithValue("@UserID", giftsModel.UserID);
                sqlDa.Fill(dtblGift);
            }
            return RedirectToAction("Index", "Gifts", new { @id = giftsModel.UserID });
        }

        // GET: GiftsController/Edit/5
        public ActionResult Edit(int GiftID)
        {
            GiftsModel giftsModel = new GiftsModel();
            DataTable dtblGift = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM GiftsTable WHERE GiftID = @GiftID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@GiftID", GiftID);
                sqlDa.Fill(dtblGift);
            }
            if (dtblGift.Rows.Count == 1)
            {
                giftsModel.GiftID = Convert.ToInt32(dtblGift.Rows[0][0].ToString());
                giftsModel.GiftName = dtblGift.Rows[0][1].ToString();
                giftsModel.Price = Convert.ToInt32(dtblGift.Rows[0][2].ToString());
                giftsModel.QuantityLeft = Convert.ToInt32(dtblGift.Rows[0][3].ToString());
                giftsModel.Status = dtblGift.Rows[0][4].ToString();
                giftsModel.UserID = Convert.ToInt32(dtblGift.Rows[0][5].ToString());
                return View(giftsModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
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
