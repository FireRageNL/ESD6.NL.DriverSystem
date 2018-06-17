using System;
using System.Collections.Generic;
using System.Text;
using ESD6NL.DriverSystem.Entities;

namespace ESD6NL.DriverSystem.DAL.Interfaces
{
    public interface IRowRepository : IGenericRepository<Row>
    {
        Row findRowById(int id);
    }
}
