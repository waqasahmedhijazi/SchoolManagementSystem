using SchoolManagementSystem.BL.Parent;
using SchoolManagementSystem.ViewModel.ViewModel;
using SchoolManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Controllers
{
	public class ParentController : Controller
	{
		// GET: Parent
		public ActionResult Index()
		{
			try
			{
				var result = BL.Parent.ParentClass.GetAllParents();
				return View(result);
			}
			catch (Exception ex)
			{
				TempData["MessageType"] = ViewBag.MessageType = "error";
				return Json(new { message = ex.ToString(), url = Url.Action("Index", "Parent") });
			}
		}

		// GET: Parent/Details/5
		public ActionResult Details(int id)
		{
			try
			{
				Model.Entities.ModelEntities.ParentModelEntity objParentModelEntity = ParentClass.GetParentDetailByParentId(id);
				return View(objParentModelEntity);
			}
			catch (Exception ex)
			{
				TempData["MessageType"] = ViewBag.MessageType = "error";
				return Json(new { message = ex.ToString(), url = Url.Action("Index", "Parent") },JsonRequestBehavior.AllowGet);
			}
		}

		// GET: Parent/Create
		public ActionResult Create()
		{

			try
			{
				var ListParentViewModel = ParentClass.FillParentDropDowns();
				return View(ListParentViewModel);
			}
			catch (Exception ex)
			{
				TempData["MessageType"] = ViewBag.MessageType = "error";
				return Json(new { message = ex.ToString(), url = Url.Action("Index", "Parent") });
			}
		}

		// POST: Parent/Create
		[HttpPost]
		public ActionResult Create(ParentViewModel objParentViewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					objParentViewModel.ProfilePicture = objParentViewModel.ProfilePicture;
					HttpPostedFileBase File = objParentViewModel.ImagePath;
					string FileName = "";
					if (File != null)
					{
						FileName = FileUpload.UploadParentProfileImage(File);
						objParentViewModel.ProfilePicture = FileName;
					}
					if (objParentViewModel.ParentId != 0)
					{
						objParentViewModel.IPAddress = CommonMethods.GetIPAddress();
						ParentClass.CreateParent(objParentViewModel);
					}
					else
					{
						objParentViewModel.IPAddress= CommonMethods.GetIPAddress();
						ParentClass.CreateParent(objParentViewModel);
					}
					TempData["MessageType"] = ViewBag.MessageType = "success";
					TempData["Message"] = ViewBag.Message = "Parent information saved successfully.";
					return RedirectToAction("Index");
				}
				else
				{
					TempData["MessageType"] = ViewBag.MessageType = "error";
					return Json(new { message = "The model is not valid, please fill form correctly.", url = Url.Action("Index", "Parent") });
				}
			}
			catch (Exception ex)
			{
				TempData["MessageType"] = ViewBag.MessageType = "error";
				return Json(new { message = ex.ToString(), url = Url.Action("Index", "Parent") });
			}
		}

		// GET: Parent/Edit/5
		public ActionResult Edit(int id)
		{
			try
			{
				ParentViewModel objParentViewModel = ParentClass.GetParentByParentId(id);
				return View("Create", objParentViewModel);
			}
			catch (Exception ex)
			{
				TempData["MessageType"] = ViewBag.MessageType = "error";
				return Json(new { message = ex.ToString(), url = Url.Action("Index", "Parent") });
			}
		}

		// GET: Parent/Delete/5
		public ActionResult Delete(int id)
		{
			try
			{
				if (id > 0)
					ParentClass.DeleteParent(id);

				TempData["MessageType"] = ViewBag.MessageType = "success";
				TempData["Message"] = ViewBag.Message = "Parent deleted successfully.";

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				TempData["MessageType"] = ViewBag.MessageType = "error";
				return Json(new { message = ex.ToString(), url = Url.Action("Index", "Parent") });
			}
		}
	}
}
