using PagedList;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication002.DAL;
using WebApplication002.Models;

namespace WebApplication002.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeListContext db = new EmployeeListContext();

        // GET: Employee

        //public ActionResult Index()
        //{
        //    return View(db.Employees.ToList());
        //}

        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            //Creating cases to select in switch statement for sorting
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "";
            ViewBag.LastNameSortParm = sortOrder == "lastname" ? "lastname_desc" : "lastname";
            ViewBag.SalaryNetoSortParm = sortOrder == "salary" ? "salary_desc" : "salary";

            //Paging functionality
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var employees = from s in db.Employees
                            select s;

            //Setting up search
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            //Switch statement to select sort order
            switch (sortOrder)
            {
                case "lastname_desc":
                    employees = employees.OrderByDescending(s => s.LastName);
                    break;

                case "lastname":
                    employees = employees.OrderBy(s => s.LastName);
                    break;

                case "firstname_desc":
                    employees = employees.OrderByDescending(s => s.FirstName);
                    break;

                case "salary_desc":
                    employees = employees.OrderByDescending(s => s.SalaryNeto);
                    break;

                case "salary":
                    employees = employees.OrderBy(s => s.SalaryNeto);
                    break;

                default:
                    employees = employees.OrderBy(s => s.FirstName);
                    break;
            }

            //more paging stuff with extension methods
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, pageSize));
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Removed ID from the Bind attribute because ID is set automatically when the row is inserted. Input from the user does not set the ID value.
        public ActionResult Create([Bind(Include = "FirstName,LastName,SalaryNeto")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,SalaryNeto")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Employee employee = db.Employees.Find(id);
                if (employee != null) db.Employees.Remove(employee);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}