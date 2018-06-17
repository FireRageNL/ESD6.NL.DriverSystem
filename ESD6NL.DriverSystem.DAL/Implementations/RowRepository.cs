using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESD6NL.DriverSystem.DAL.Implementations
{
    public class RowRepository : GenericRepository<Row>, IRowRepository
    {
        public RowRepository(DriverSystemContext context) : base(context)
        {
        }

        public Row findRowById(int id)
        {
            return _context.Row.Where(x => x.rowId == id).Include(y => y.navigatedRoutes).SingleOrDefault();
        }
    }
}
