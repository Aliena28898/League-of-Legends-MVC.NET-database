using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;
using FinalBBDD.Models;

namespace FinalBBDD.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ChampionInfo(int id)
        {
            string Sql = "SELECT * FROM champions where id =" + id.ToString() + ";";
            string conn = ("Server=localhost;Database=lol;Uid=root;Pwd=2889828898;SslMode=none");
            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                connection.Open();

                MySqlCommand com = new MySqlCommand();
                com.Connection = connection;
                com.CommandText = Sql;


                MySqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //reader.Read();

                        Champion champ = new Champion();
                        champ.Id = reader.GetInt32(0);
                        champ.Name = reader.GetString(1);
                        champ.Title = reader.GetString(2);
                        champ.Lore = reader.GetString(3);
                        String[] taglist = reader.GetString(4).Split(',');
                        champ.Tags = taglist.OfType<String>().ToList(); ;

                        ViewBag.Champion = champ;

                    }
                }
            }



            return View();
        }
    }
}