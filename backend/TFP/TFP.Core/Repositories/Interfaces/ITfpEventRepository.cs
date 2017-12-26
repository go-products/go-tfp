using System.Collections.Generic;
using System.Linq;
using TFP.Domain.Entities;
using TFP.Models.ViewModels;

namespace TFP.Core.Repositories.Interfaces
{
    public interface ITfpEventRepository : IGenericRepository<TfpEvent>
    {
        IQueryable<TfpEvent> GetEvents();
    }
}
