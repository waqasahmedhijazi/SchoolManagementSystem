using SchoolManagementSystem.Model.Context.Database;
using SchoolManagementSystem.Model.Pattern.Repositories;
using SchoolManagementSystem.ViewModel.ViewModel;
using SchoolManagementSystem.WebApi.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolManagementSystem.WebApi.Controllers
{
    public class CountryController : ApiController
    {
        // GET: api/Country
        public IEnumerable<TblGenCountry> Get()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {

                    var Countries = unitOfWork.Countries.GetAll(p => p.IsDeleted == false).ToList();
                    return Countries;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Country/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Country
        public void Post(CountryViewModel objCountryViewModel)
        {
            var objCountry = MapperWrapper.Mapper.Map<TblGenCountry>(objCountryViewModel);

            using (var unitOfWork = new UnitOfWork())
            {
                if (objCountryViewModel.CountryID > 0)
                {
                    unitOfWork.Countries.Update(objCountry);
                }
                else
                {
                    unitOfWork.Countries.Insert(objCountry);
                }
                unitOfWork.Commit();
            }
        }

        // PUT: api/Country/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Country/5
        public void Delete(int id)
        {
        }
    }
}
