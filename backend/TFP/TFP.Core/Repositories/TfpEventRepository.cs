using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TFP.Core.Repositories.Interfaces;
using TFP.Domain.Entities;
using TFP.Models.ViewModels;

namespace TFP.Core.Repositories
{
    public class TfpEventRepository : GenericRepository<TfpEvent>, ITfpEventRepository
    {
        public TfpEventRepository(DbContext context) : base(context)
        {

        }

        public IQueryable<TfpEvent> GetEvents()
        {
            return DbSet.AsQueryable();
        }

        
    }
}
