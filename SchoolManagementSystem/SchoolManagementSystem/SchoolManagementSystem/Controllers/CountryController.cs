using SchoolManagementSystem.BL.Country;
using SchoolManagementSystem.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            try
            {
                var Countries = BL.Country.CountryClass.GetAllCountries();
                return View(Countries);
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = ViewBag.MessageType = "error";
                return Json(new { message = ex.ToString(), url = Url.Action("Index", "Country") },JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            CountryViewModel objCountryViewModel = new CountryViewModel();
            return PartialView("_CreateUpdate", objCountryViewModel);
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(CountryViewModel objCountryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CountryClass.CreateCountry(objCountryViewModel);
                    TempData["MessageType"] = ViewBag.MessageType = "success";
                    TempData["Message"] = ViewBag.Message = "Country information saved successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MessageType"] = ViewBag.MessageType = "error";
                    return Json(new { message = "The model is not valid, please fill form correctly.", url = Url.Action("Index", "Country") });
                }
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = ViewBag.MessageType = "error";
                return Json(new { message = ex.ToString(), url = Url.Action("Index", "Country") });
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
