using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Data.Abstractions.Repositories
{
    public interface IBatchRepository
    {
        Batch Save(Batch course);

        List<Batch> GetAll();

        Batch Get(int id);
    }
}
