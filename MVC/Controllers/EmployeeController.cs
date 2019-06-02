using MVC.Models;
using MVC.Models.APICONNECT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeInMVC> emplist;

            HttpResponseMessage response = GloableVariable.WepApiAddress.GetAsync("employees").Result;
            emplist = response.Content.ReadAsAsync<IEnumerable<EmployeeInMVC>>().Result;

            return View(emplist);
        }



        public ActionResult AddOrEdit(int id = 0)
        {
            if (id==0)
            {
                return View(new EmployeeInMVC());

            }
            HttpResponseMessage response = GloableVariable.WepApiAddress.GetAsync("employees/"+id.ToString()).Result;

            return View(response.Content.ReadAsAsync<EmployeeInMVC>().Result);

        }
        [HttpPost]
        public ActionResult AddOrEdit(EmployeeInMVC emp)
        {
            if (emp.EmpID == 0 )
            {
                HttpResponseMessage res = GloableVariable.WepApiAddress.PostAsJsonAsync("Employees", emp).Result;
                return RedirectToAction("index");

            }

            HttpResponseMessage response = GloableVariable.WepApiAddress.PutAsJsonAsync("employees/" + emp.EmpID,emp).Result;

            return RedirectToAction("index");

        }



        public ActionResult Delete(int id)
        {
            HttpResponseMessage res = GloableVariable.WepApiAddress.DeleteAsync("Employees/"+id.ToString()).Result;

            return RedirectToAction("index");
        }

    }
}