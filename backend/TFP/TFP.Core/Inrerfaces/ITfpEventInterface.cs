using System;
using System.Collections.Generic;
using System.Text;
using TFP.Domain.Entities;

namespace TFP.Core.Inrerfaces
{
    public interface ITfpEventInterface
    {
        IEnumerable<TfpEvent> GetTfp();

    }
}
