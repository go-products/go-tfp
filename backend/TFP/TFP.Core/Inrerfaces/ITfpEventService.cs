using System.Collections.Generic;
using TFP.Models.ViewModels;

namespace TFP.Core.Inrerfaces
{
    public interface ITfpEventService
    {
        IEnumerable<TfpEventViewModel> GetEvents();
        void CreateEvent(TfpEventViewModel model);
    }
}
