using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LifeTheGathering.MVC.Models;

namespace LifeTheGathering.MVC.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public User User { get; set; }
    }
}