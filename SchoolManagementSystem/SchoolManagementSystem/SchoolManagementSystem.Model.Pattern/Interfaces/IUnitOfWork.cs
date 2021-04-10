using SchoolManagementSystem.Model.Context.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model.Pattern.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<TblParent> Parents { get; }
        void Commit();

    }
}
