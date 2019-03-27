using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutGenericTypes
{
    public interface ISession
    {
        string Id { get; set; }
        IServer Server { get; set; }
    }
}