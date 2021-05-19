using SchoolManagementSystem.Model.Context.Database;
using SchoolManagementSystem.Model.Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.SqlClient;
using SchoolManagementSystem.ViewModel.ViewModel;
using SchoolManagementSystem.WebApi.AutoMapper;
using SchoolManagementSystem.Model.Entities.ModelEntities;

namespace SchoolManagementSystem.WebApi.Controllers
{
	public class ParentController : ApiController
	{
		// GET: api/Parent
		public List<TblParent> Get()
		{
			try
			{
				using (var unitOfWork = new UnitOfWork())
				{

					var parent = unitOfWork.Parents.GetAll(p => p.IsDeleted == false).ToList();
					return parent;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpGet]
		[Route("api/Parent/GetParentByParentId")]
		public ParentModelEntity GetParentByParentId(int id)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork())
				{

					ParentModelEntity objParentModelEntity = new ParentModelEntity();
					var parent = unitOfWork.GetParentByPerentId.ExecWithStoreProcedure("exec SP_GetParentByParentID @ParentId", new SqlParameter("ParentId", id)).FirstOrDefault();
					objParentModelEntity = MapperWrapper.Mapper.Map<ParentModelEntity>(parent);
					return objParentModelEntity;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// GET: api/Parent/5
		public ParentViewModel Get(int id)
		{
			using (var unitOfWork = new UnitOfWork())
			{
				ParentViewModel objParentViewModel = new ParentViewModel();
				if (id > 0)
				{


				}
				var lstLookups = unitOfWork.FillParentDropdowns.ExecWithStoreProcedure("exec SP_FillDropdown @type", new SqlParameter("Type", 1)).ToList();
				objParentViewModel.FillMaritalStauts = FilterDropDowns(lstLookups, 1);
				objParentViewModel.FillGender = FilterDropDowns(lstLookups, 2);
				objParentViewModel.FillRelationShip = FilterDropDowns(lstLookups, 3);
				objParentViewModel.FillCountries = FilterDropDowns(lstLookups, 4);
				objParentViewModel.FillStates = FilterDropDowns(lstLookups, 5);
				objParentViewModel.FillCites = FilterDropDowns(lstLookups, 6);
				return objParentViewModel;
			}
		}

		// POST: api/Parent
		public void Post(ParentViewModel objParentViewModel)
		{
			var objparent = MapperWrapper.Mapper.Map<TblParent>(objParentViewModel);
			objparent.CreatedDate = DateTime.Now;
			using (var unitOfWork = new UnitOfWork())
			{
				unitOfWork.Parents.Insert(objparent);
				unitOfWork.Commit();
			}
		}

		// PUT: api/Parent/5
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE: api/Parent/5
		public void Delete(int id)
		{
		}

		public IEnumerable<GeneralLookups> FilterDropDowns(IEnumerable<SP_FillDropdown_Result> obj, int type)
		{
			var lstValues = (from a in obj
							 where a.Type == type
							 select new GeneralLookups
							 {
								 Id = a.ID,
								 ExtraField = a.ExtraField,
								 Text = a.Text
							 });
			return lstValues;
		}
	}
}
