using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using YasslayMVC.Models;

namespace YasslayMVC.Controllers
{
    public class ConfessionsController : Controller
    {
        string connectionString = @"Data Source=DESKTOP-9MQ1M1N\SQLEXPRESS;Initial Catalog=Yasslay;Integrated Security=True";
        [HttpGet]
        public ActionResult Index(int id)
        {
            DataTable dtblConfess = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM ConfessionsTable", sqlCon);
                sqlDa.Fill(dtblConfess);
            }
            ViewBag.LinkableId = id;

            return View(dtblConfess);
        }

        public ActionResult Index_Seller(int id)
        {
            DataTable dtblConfess = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM ConfessionsTable", sqlCon);
                sqlDa.Fill(dtblConfess);
            }
            ViewBag.LinkableId = id;

            return View(dtblConfess);
        }

        [HttpGet]
        // GET: ConfessionsController/Create
        public ActionResult Create(int id)
        {
            ViewBag.LinkableId = id;

            return View(new ConfessionsModel());
        }

        // POST: ConfessionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConfessionsModel confessionsModel)
        {
            DataTable dtblConfess = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO ConfessionsTable VALUES(@UserID,@Relationship,@Message,@RecipientLN,@RecipientFN,@GiftID,@Status,NULL)";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@UserID", confessionsModel.UserID);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Relationship", confessionsModel.Relationship);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Message", confessionsModel.Message);
                sqlDa.SelectCommand.Parameters.AddWithValue("@RecipientLN", confessionsModel.RecipientLN);
                sqlDa.SelectCommand.Parameters.AddWithValue("@RecipientFN", confessionsModel.RecipientFN);
                sqlDa.SelectCommand.Parameters.AddWithValue("@GiftID", confessionsModel.GiftID);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Status", "Pending");
                sqlDa.Fill(dtblConfess);
            }
            return RedirectToAction("Index", "Confessions", new { @id = confessionsModel.UserID });
        }

        // GET: ConfessionsController/Edit/5
        public ActionResult Edit(int ConfessID, int id)
        {
            ViewBag.LinkableId = id;
            ConfessionsModel confessionsModel = new ConfessionsModel();
            DataTable dtblConfess = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM ConfessionsTable WHERE ConfessID = @ConfessID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@ConfessID", ConfessID);
                sqlDa.Fill(dtblConfess);
            }
            if (dtblConfess.Rows.Count == 1)
            {
                confessionsModel.ConfessID = Convert.ToInt32(dtblConfess.Rows[0][0].ToString());
                confessionsModel.UserID = id;
                confessionsModel.Relationship = dtblConfess.Rows[0][2].ToString();
                confessionsModel.Message = dtblConfess.Rows[0][3].ToString();
                confessionsModel.RecipientLN = dtblConfess.Rows[0][4].ToString();
                confessionsModel.RecipientFN = dtblConfess.Rows[0][5].ToString();
                confessionsModel.GiftID = Convert.ToInt32(dtblConfess.Rows[0][6].ToString());
                confessionsModel.Status = dtblConfess.Rows[0][7].ToString();
                return View(confessionsModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: ConfessionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConfessionsModel confessionsModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE ConfessionsTable SET UserID = @UserID, Relationship = @Relationship, Message = @Message, RecipientLN = @RecipientLN, RecipientFN = @RecipientFN, GiftID = @GiftID, Status = @Status WHERE ConfessID = @ConfessID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ConfessID", confessionsModel.ConfessID);
                sqlCmd.Parameters.AddWithValue("@UserID", confessionsModel.UserID);
                sqlCmd.Parameters.AddWithValue("@Relationship", confessionsModel.Relationship);
                sqlCmd.Parameters.AddWithValue("@Message", confessionsModel.Message);
                sqlCmd.Parameters.AddWithValue("@RecipientLN", confessionsModel.RecipientLN);
                sqlCmd.Parameters.AddWithValue("@RecipientFN", confessionsModel.RecipientFN);
                sqlCmd.Parameters.AddWithValue("@GiftID", confessionsModel.GiftID);
                sqlCmd.Parameters.AddWithValue("@Status", "Pending");
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index", "Confessions", new { @id = confessionsModel.UserID });
        }

        public ActionResult Edit_Seller(int ConfessID, int id)
        {
            ViewBag.LinkableId = id;
            ConfessionsModel confessionsModel = new ConfessionsModel();
            DataTable dtblConfess = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM ConfessionsTable WHERE ConfessID = @ConfessID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@ConfessID", ConfessID);
                sqlDa.Fill(dtblConfess);
            }
            if (dtblConfess.Rows.Count == 1)
            {
                confessionsModel.ConfessID = Convert.ToInt32(dtblConfess.Rows[0][0].ToString());
                confessionsModel.UserID = Convert.ToInt32(dtblConfess.Rows[0][1].ToString());
                confessionsModel.Relationship = dtblConfess.Rows[0][2].ToString();
                confessionsModel.Message = dtblConfess.Rows[0][3].ToString();
                confessionsModel.RecipientLN = dtblConfess.Rows[0][4].ToString();
                confessionsModel.RecipientFN = dtblConfess.Rows[0][5].ToString();
                confessionsModel.GiftID = Convert.ToInt32(dtblConfess.Rows[0][6].ToString());
                confessionsModel.Status = dtblConfess.Rows[0][7].ToString();
                return View(confessionsModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Seller(ConfessionsModel confessionsModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE ConfessionsTable SET Status = @Status, StatusID = @StatusID WHERE ConfessID = @ConfessID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ConfessID", confessionsModel.ConfessID);
                sqlCmd.Parameters.AddWithValue("@Status", confessionsModel.Status);
                sqlCmd.Parameters.AddWithValue("@StatusID", confessionsModel.StatusID);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index_Seller", "Confessions", new { @id = confessionsModel.StatusID });
        }


        // GET: ConfessionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConfessionsController/Delete/5
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
