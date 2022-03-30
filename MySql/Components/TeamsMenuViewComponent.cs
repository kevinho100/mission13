using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MySql.Models;

namespace MySql.Components
{
    public class TeamsMenuViewComponent : ViewComponent
    {
        private IBowlersRepository repo { get; set; }

        public TeamsMenuViewComponent (IBowlersRepository temp)
        {
            repo = temp;
        }
        
        public IViewComponentResult Invoke()
        {
            ViewBag.TeamName = RouteData?.Values["TeamName"];

            var teams = repo.Bowlers.Select(x => x.TeamName.TeamName).Distinct().OrderBy(x => x);
            return View(teams);
        }
    }
}