using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
    public class HomeController : Controller
    {
      private readonly FactoryContext _db;

      public HomeController(FactoryContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        Engineer[] Engineers = _db.Engineers.ToArray();
        Machine[] Machines = _db.Machines.ToArray();
        Dictionary<string, object[]> model = new Dictionary<string, object[]>();
        model.Add("Engineers", Engineers);
        model.Add("Machines", Machines);
        ViewBag.PageTitle = "Welcome to Dr. Sillystringz Factory!";
        return View(model);
      }

      // public ActionResult Search(string query)
      // {
      //   List<Engineer> engineerResults = _db.Engineers.Where(engineer => engineer.Name.Contains(query)).ToList();
      //   return View(engineerResults);
      // }
    }
}