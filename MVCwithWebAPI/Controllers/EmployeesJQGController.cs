using MVCwithWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCwithWebAPI.Controllers
{
    public class EmployeesJQGController : Controller
    {
        // GET: EmployeesJQG
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeesJQG
        public ActionResult JQGIndex()
        {
            return View();
        }

        SqlDbContext db = new SqlDbContext();

        public JsonResult GetValues(string sidx, string sord, int page, int rows) //Gets the todo Lists.  
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var Results = db.Employees.Select(
                a => new
                {
                    a.Id,
                    a.Name,
                    a.Address,
                    a.Gender,
                    a.Company,
                    a.Designation,

                });
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // TODO:insert a new row to the grid logic here  
        [HttpPost]
        public string Create(Employee obj)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    obj.Id = Guid.NewGuid().ToString();
                    db.Employees.Add(obj);
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        public string Edit(Employee obj)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        public string Delete(int Id)
        {
            Employee list = db.Employees.Find(Id);
            db.Employees.Remove(list);
            db.SaveChanges();
            return "Deleted successfully";
        }

        //Gets the to-do Lists.    
        //public JsonResult GetCustomers(string sord, int page, int rows, string searchString)
        //{
        //    //#1 Create Instance of DatabaseContext class for Accessing Database.  
        //    using (SqlDbContext db = new SqlDbContext())
        //    {
        //        //#2 Setting Paging  
        //        int pageIndex = Convert.ToInt32(page) - 1;
        //        int pageSize = rows;

        //        //#3 Linq Query to Get Customer   
        //        var Results = db.Employees.Select(
        //            a => new
        //            {
        //                a.Id,
        //                a.Name,
        //                a.Address,
        //                a.Gender,
        //                a.Company,
        //                a.Designation,
        //            });

        //        //#4 Get Total Row Count  
        //        int totalRecords = Results.Count();
        //        var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
        //        //#5 Setting Sorting  
        //        if (sord.ToUpper() == "DESC")
        //        {
        //            Results = Results.OrderByDescending(s => s.Name);
        //            Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
        //        }
        //        else
        //        {
        //            Results = Results.OrderBy(s => s.Name);
        //            Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
        //        }
        //        //#6 Setting Search  
        //        if (!string.IsNullOrEmpty(searchString))
        //        {
        //            Results = Results.Where(m => m.Name == searchString);
        //        }
        //        //#7 Sending Json Object to View.  
        //        var jsonData = new
        //        {
        //            total = totalPages,
        //            page,
        //            records = totalRecords,
        //            rows = Results
        //        };
        //        return Json(jsonData, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}