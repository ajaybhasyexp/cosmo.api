using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface IGenericRepository<T> where T : Base
    {
        T Get(int id);

        List<T> GetAll();

        T Save(T branch);
    }
}
