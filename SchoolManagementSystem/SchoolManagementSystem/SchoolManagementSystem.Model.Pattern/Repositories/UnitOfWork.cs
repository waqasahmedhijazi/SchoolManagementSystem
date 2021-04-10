using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.Model.Context.Database;
using SchoolManagementSystem.Model.Pattern.Interfaces;

namespace SchoolManagementSystem.Model.Pattern.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private SchoolManagementSystemEntities _dbContext;
        private BaseRepository<TblParent> _parents;
        private BaseRepository<TblGenMaritalStaut> _maritalStaut;
        private BaseRepository<TblGenGender> _parentGender;
        private BaseRepository<TblGenRelationShip> _relationShip;
        private BaseRepository<TblGenCountry> _countries;
        private BaseRepository<TblGenState> _states;
        private BaseRepository<TblGenCity> _cities;
        private BaseRepository<SP_FillDropdown_Result> _fillParentDropdowns;
        private BaseRepository<SP_GetParentByParentID_Result> _getParentByParentId;

        public UnitOfWork()
        {
            _dbContext = new SchoolManagementSystemEntities();
            _dbContext.Configuration.ProxyCreationEnabled = false;
        }

        public IBaseRepository<TblParent> Parents
        {
            get
            {
                return _parents ??
                    (_parents = new BaseRepository<TblParent>(_dbContext));
            }
        }

        public IBaseRepository<TblGenMaritalStaut> MaritalStaut
        {
            get
            {
                return _maritalStaut ??
                    (_maritalStaut = new BaseRepository<TblGenMaritalStaut>(_dbContext));
            }
        }

        public IBaseRepository<TblGenGender> ParentGender
        {
            get
            {
                return _parentGender ??
                    (_parentGender = new BaseRepository<TblGenGender>(_dbContext));
            }
        }

        public IBaseRepository<TblGenRelationShip> RelationShip
        {
            get
            {
                return _relationShip ??
                    (_relationShip = new BaseRepository<TblGenRelationShip>(_dbContext));
            }
        }

        public IBaseRepository<TblGenCountry> Countries
        {
            get
            {
                return _countries ??
                    (_countries = new BaseRepository<TblGenCountry>(_dbContext));
            }
        }

        public IBaseRepository<TblGenState> States
        {
            get
            {
                return _states ??
                    (_states = new BaseRepository<TblGenState>(_dbContext));
            }
        }

        public IBaseRepository<TblGenCity> Cities
        {
            get
            {
                return _cities ??
                    (_cities = new BaseRepository<TblGenCity>(_dbContext));
            }
        }

        public IBaseRepository<SP_FillDropdown_Result> FillParentDropdowns
        {
            get
            {
                return _fillParentDropdowns ??
                    (_fillParentDropdowns = new BaseRepository<SP_FillDropdown_Result>(_dbContext));
            }
        }

        public IBaseRepository<SP_GetParentByParentID_Result> GetParentByPerentId
        {
            get
            {
                return _getParentByParentId ??
                    (_getParentByParentId = new BaseRepository<SP_GetParentByParentID_Result>(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        #region IDisposable Support  
        private bool _disposedValue = false; // To detect redundant calls  

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
            {
                //dispose managed state (managed objects).  
            }

            // free unmanaged resources (unmanaged objects) and override a finalizer below.  
            // set large fields to null.  

            _disposedValue = true;
        }

        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.  
        // ~UnitOfWork() {  
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.  
        //   Dispose(false);  
        // }  

        // This code added to correctly implement the disposable pattern.  
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.  
            Dispose(true);
            // uncomment the following line if the finalizer is overridden above.  
            // GC.SuppressFinalize(this);  
        }
        #endregion
    }
}
