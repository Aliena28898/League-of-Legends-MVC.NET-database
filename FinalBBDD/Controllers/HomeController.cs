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

            Sql = "SELECT * FROM champion_abilities where champion =" + id.ToString() + ";";
            conn = ("Server=localhost;Database=lol;Uid=root;Pwd=2889828898;SslMode=none");
            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                connection.Open();

                MySqlCommand com = new MySqlCommand();
                com.Connection = connection;
                com.CommandText = Sql;


                MySqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    ViewBag.Champion.Abilities = new List<Ability>();
                    while (reader.Read())
                    {
                        //reader.Read();

                        Ability champ = new Ability();
                        champ.id = reader.GetInt32(0);
                        champ.champion = reader.GetInt32(1);
                        champ.name = reader.GetString(2);
                        champ.description = reader.GetString(3);

                        ViewBag.Champion.Abilities.Add(champ);


                    }
                }


            }

            Sql = "SELECT * FROM champion_tips where champion =" + id.ToString() + ";";
            conn = ("Server=localhost;Database=lol;Uid=root;Pwd=2889828898;SslMode=none");
            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                connection.Open();

                MySqlCommand com = new MySqlCommand();
                com.Connection = connection;
                com.CommandText = Sql;


                MySqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    ViewBag.Champion.Tips = new List<String>();
                    while (reader.Read())
                    {
                        //reader.Read();

                        ViewBag.Champion.Tips.Add(reader.GetString(2));


                    }
                }

                return View();
            }

        }
    }
}