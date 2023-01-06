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
        Engineer[] engineers = _db.Engineers.ToArray();
        Machine[] machines = _db.Machines.ToArray();
        Dictionary<string, object[]> model = new Dictionary<string, object[]>();
        model.Add("engineers", engineers);
        model.Add("machines", machines);
        return View(model);
      }

      // public ActionResult Search(string query)
      // {
      //   List<Engineer> engineerResults = _db.Engineers.Where(engineer => engineer.Name.Contains(query)).ToList();
      //   return View(engineerResults);
      // }
    }
}