﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTS_Emulator.Comm
{
    interface IConnectionReport
    {
        void On_Connection_Message(object Msg);
        void On_Connection_Connecting(string Msg);
        void On_Connection_Connected(object Msg);
        void On_Connection_Disconnected(string Msg);
        void On_Connection_Error(string Msg);
    }
}
