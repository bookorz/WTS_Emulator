using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTS_Emulator.Comm
{
    interface IConnection
    {
        bool Send(object Message);
        bool SendHexData(object Message);
        void Start();
        void WaitForData(bool Enable);
    }
}
