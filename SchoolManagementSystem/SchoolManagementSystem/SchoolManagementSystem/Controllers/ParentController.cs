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
			var result = BL.Parent.ParentClass.GetAllParents();
			return View(result);
		}

		// GET: Parent/Details/5
		public ActionResult Details(int id)
		{
			Model.Entities.ModelEntities.ParentModelEntity objParentModelEntity = ParentClass.GetParentByParentId(id);
			return View(objParentModelEntity);
		}

		// GET: Parent/Create
		public ActionResult Create()
		{
			var ListParentViewModel = ParentClass.FillParentDropDowns();
			return View(ListParentViewModel);
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
					//var objParent = _mapper.Map<TblParent>(objParentViewModel);

					if (objParentViewModel.ParentId != 0)
					{
						//objParent.UpdatedDate = DateTime.Now;
						//clsParent.UpdateParent(objParent);
					}
					else
					{
						objParentViewModel.IPAddress= CommonMethods.GetIPAddress();
						ParentClass.CreateParent(objParentViewModel);
					}

					TempData["MessageType"] = ViewBag.MessageType = "success";
					TempData["Message"] = ViewBag.Message = "Data Saved Successfully";
					return RedirectToAction("Index");
				}
				else
				{
					return Json(new { message = "The model is not valid, please fill form correctly.", url = Url.Action("Index", "Parent") });
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		// GET: Parent/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Parent/Edit/5
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

		// GET: Parent/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Parent/Delete/5
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
