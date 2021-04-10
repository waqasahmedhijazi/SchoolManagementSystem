﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolManagementSystem.Model.Context.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SchoolManagementSystemEntities : DbContext
    {
        public SchoolManagementSystemEntities()
            : base("name=SchoolManagementSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblGenCity> TblGenCities { get; set; }
        public virtual DbSet<TblGenCountry> TblGenCountries { get; set; }
        public virtual DbSet<TblGenGender> TblGenGenders { get; set; }
        public virtual DbSet<TblGenMaritalStaut> TblGenMaritalStauts { get; set; }
        public virtual DbSet<TblGenRelationShip> TblGenRelationShips { get; set; }
        public virtual DbSet<TblGenState> TblGenStates { get; set; }
        public virtual DbSet<TblParent> TblParents { get; set; }
        public virtual DbSet<View_GetParentByParentID> View_GetParentByParentID { get; set; }
    
        public virtual ObjectResult<SP_FillDropdown_Result> SP_FillDropdown(Nullable<int> type)
        {
            var typeParameter = type.HasValue ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_FillDropdown_Result>("SP_FillDropdown", typeParameter);
        }
    
        public virtual ObjectResult<SP_GetParentByParentID_Result> SP_GetParentByParentID(Nullable<int> parentID)
        {
            var parentIDParameter = parentID.HasValue ?
                new ObjectParameter("ParentID", parentID) :
                new ObjectParameter("ParentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetParentByParentID_Result>("SP_GetParentByParentID", parentIDParameter);
        }
    }
}
