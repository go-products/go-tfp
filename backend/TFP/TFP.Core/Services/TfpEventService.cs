using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TFP.Core.Inrerfaces;
using TFP.Core.UnitOfWork;
using TFP.Domain.Entities;
using TFP.Models.ViewModels;

namespace TFP.Core.Services
{
    public class TfpEventService : ITfpEventService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;

        public TfpEventService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<TfpEventViewModel> GetEvents()
        {
            var events = autoMapper.Map<IQueryable<TfpEvent>, IEnumerable<TfpEventViewModel>>(unitOfWork.TfpEventRepository.GetEvents());
            return events;
        }

        public void CreateEvent(TfpEventViewModel model)
        {
            var ev = autoMapper.Map<TfpEvent>(model);
            unitOfWork.TfpEventRepository.Add(ev);
            
            unitOfWork.Save();
        }
    }
}
