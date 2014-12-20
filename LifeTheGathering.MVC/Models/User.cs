using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeTheGathering.MVC.Models
{
    public class User
    {
        #region properties
        public string Name { get; set; }
        public int Food { get; set; }
        public int Wood { get; set; }
        #endregion

        #region objects
        public int Snails { get; set; }
        #endregion

        public User(string name)
        {
            Name = name;
        }
    }
}