using System;
using System.Collections.Generic;
using System.Text;
using ESD6NL.DriverSystem.BLL.Interfaces;
using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;

namespace ESD6NL.DriverSystem.BLL.Implementations
{
    public class RowService : IRowService
    {
        private IRowRepository _repo;

        public RowService(IRowRepository repo)
        {
            _repo = repo;
        }
        public Row getSpecificRow(int rowId)
        {
            return _repo.findRowById(rowId);
        }
    }
}
