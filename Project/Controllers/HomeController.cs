using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cloud.Models;
using Org.BouncyCastle.Bcpg.OpenPgp;
using MySql.Data.MySqlClient;

namespace Cloud.Controllers
{
    public class HomeController : Controller
    {
        DataBaseConnecion d = new DataBaseConnecion();
        List<Data> allData = new List<Data>();


        //Home/GetAll
        [HttpGet]
        public JsonResult GetAll()
        {
            GetShops();
            GetData();

            return Json(allData);
        }

        public void GetShops()
        {
            //database variables
            MySqlConnection myConnection = new MySqlConnection(d.DatabaseConnectionStrng);
            MySqlCommand myCommandLabel;
            MySqlDataReader myReaderLabel;
            string myQuery;

            myQuery = "SELECT * FROM Shop";
            myCommandLabel = new MySqlCommand(myQuery, myConnection);
            myConnection.Open();
            myReaderLabel = myCommandLabel.ExecuteReader();
            while (myReaderLabel.Read())
            {
                Data d = new Data();
                d.ShopId = myReaderLabel.GetInt32(0);
                d.ShopName = myReaderLabel.GetString(1).Trim();
                d.MaxCapacity = myReaderLabel.GetInt32(2);
                allData.Add(d);
            }
            //call Close when done reading.
            myReaderLabel.Close();
            //Close the connection when done with it.
            myConnection.Close();
        }

        public void GetData()
        {
            //database variables
            MySqlConnection myConnection = new MySqlConnection(d.DatabaseConnectionStrng);
            MySqlCommand myCommandLabel;
            MySqlDataReader myReaderLabel;
            string myQuery;

            myQuery = "SELECT * FROM SensorData ORDER BY id DESC LIMIT 30";
            myCommandLabel = new MySqlCommand(myQuery, myConnection);
            myConnection.Open();
            myReaderLabel = myCommandLabel.ExecuteReader();
            while (myReaderLabel.Read())
            {
                int index = myReaderLabel.GetInt32(1);
                Data d = allData.FirstOrDefault(t => t.ShopId == index);
                d.Id = myReaderLabel.GetInt32(0);
                d.Date_n_Time = myReaderLabel.GetDateTime(2);
                d.CurrentCapacity = myReaderLabel.GetInt32(3);
            }
            //call Close when done reading.
            myReaderLabel.Close();
            //Close the connection when done with it.
            myConnection.Close();
        }
    }
}
