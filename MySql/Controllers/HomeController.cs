using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Models;
//using MySql.Models;

namespace MySql.Controllers
{
    public class HomeController : Controller
    {
        private BowlingDbContext _repo { get; set; }

        //constructor
        public HomeController(BowlingDbContext temp)
        {
            _repo = temp;
        }


        public IActionResult Index(string teamName)
        {
            ViewBag.name = RouteData?.Values["teamName"];

            List<Team> teams = _repo.Teams
                .Where(x => x.TeamName == teamName || teamName == null)
                .ToList();

            List<Bowler> bowlers = _repo.Bowlers
                .Where(x => x.TeamName.TeamName == teamName || teamName == null)
                .OrderBy(x => x.BowlerID)
                .ToList();
            return View(bowlers);
        }

        [HttpGet]
        public IActionResult NewBowler()
        {
            ViewBag.Teams = _repo.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult NewBowler(Bowler ar)
        {
            _repo.Add(ar);
            _repo.SaveChanges();

            return View("Confirmation", ar);
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Bowler = _repo.Bowlers.ToList();

            var application = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("NewBowler", application);
        }
        [HttpPost]
        public IActionResult Edit(Bowler mv)
        {
            _repo.Update(mv);
            _repo.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int applicationid)
        {

            var application = _repo.Bowlers.Single(x => x.BowlerID == applicationid);

            return View(application);
        }
        [HttpPost]
        public IActionResult Delete(Bowler mv)
        {
            _repo.Bowlers.Remove(mv);
            _repo.SaveChanges();

            return RedirectToAction("Index");
        }
    }


}
