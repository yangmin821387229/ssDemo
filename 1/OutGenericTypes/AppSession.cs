using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutGenericTypes
{
    public class AppSession : ISession
    {
        public string Id { get; set; }
        public IServer Server { get; set; }
    }
}