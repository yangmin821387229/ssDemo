using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutGenericTypes
{
    public class TelnetServer : AppServer
    {
        public override void Connect()
        {
            Connect(new TelnetSession());
        }
    }
}