using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "View all engineers";
      List<Engineer> EngineerList = _db.Engineers.Include(engineer => engineer.JoinEntities)
          .ThenInclude(join => join.Machine).OrderByDescending(engineer => engineer.JoinEntities.Count).ToList();

      return View(EngineerList);
    }

    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
          .Include(engineer => engineer.JoinEntities)
          .ThenInclude(join => join.Machine)
          .FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.PageTitle = $"{thisEngineer.Name} Details";
      return View(thisEngineer);
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add Engineer";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      ViewBag.PageTitle = "Engineers";
      if (!ModelState.IsValid)
      {
        return View(engineer);
      }
      else
      {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
      }
    }

    public ActionResult AddMachine(int id)
    {
      //almost certain this is depricated
      // Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      // ViewBag.PageTitle = "Add Machine";
      // return View(thisEngineer);
      Engineer thisEngineer = _db.Engineers
      .Include(engineer => engineer.JoinEntities)
      .ThenInclude(join => join.Machine)
      .FirstOrDefault(engineer => engineer.EngineerId == id);

      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      ViewBag.PageTitle = $"Add machine to {thisEngineer.Name}'s roster";
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int machineId)
    {
      #nullable enable
      EngineerMachine? joinEntity = _db.EngineerMachines.FirstOrDefault(join => (join.MachineId == machineId && join.EngineerId == engineer.EngineerId));
      #nullable disable
      if (joinEntity == null && machineId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { MachineId = machineId, EngineerId = engineer.EngineerId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = engineer.EngineerId });
    }

    public ActionResult Edit(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.PageTitle = $"Modify {thisEngineer.Name}";
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Engineers.Update(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.PageTitle = $"Delete {thisEngineer.Name}";
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      EngineerMachine joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
