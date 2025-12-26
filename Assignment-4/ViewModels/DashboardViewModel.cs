using System.Collections.Generic;
using Assignment_4.Models;

namespace Assignment_4.ViewModels
{
    public class DashboardViewModel
    {
        public List<Movies> Movies { get; set; } = new();
        public List<Actor> Actors { get; set; } = new();
        public List<Character> Characters { get; set; } = new();
    }
}
