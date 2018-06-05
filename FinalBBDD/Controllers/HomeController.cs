﻿using System;
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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //try
            //{
                ViewBag.Message = "All champions.";
                ViewBag.ChampList = new List<Champion>();

                string Sql = "SELECT * FROM champions;";
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

                            ViewBag.ChampList.Add(champ);

                        }
                    }
                }

                //ViewBag.TagList = ["Mage", "Ranged", "Starter-friendly", "Fighter", "Melee", "Tank", "Support", "Assassin", "Pusher", "Jungler", "Carry", "Stealth"];

                return View();
            //}
            //catch (Exception e)
            //{

            //    return View();
            //}
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Creator and contact information for support and general issues.";

            return View();
        }
    }
}