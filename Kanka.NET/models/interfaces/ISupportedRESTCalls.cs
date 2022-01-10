using Kanka.NET.models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanka.NET.models.interfaces
{
    internal interface ISupportedRESTCalls
    {
        RestAction[] SupportedRESTCalls { get; }
    }
}