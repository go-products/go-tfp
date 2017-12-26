using AutoMapper;
using TFP.Domain.Entities;
using TFP.Models.ViewModels;

namespace TFP.Core.Mapping
{
    public class TfpEventsMap : Profile
    {
        public TfpEventsMap()
        {
            CreateMap<TfpEvent, TfpEventViewModel>().ReverseMap();
        }
    }
}
