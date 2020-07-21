using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VFlightNetwork.Data.Enums.Aircraft
{
    public enum AircraftSize
    {
        [Description("Light")]
        L,
        [Description("Medium")]
        M,
        [Description("Heavy")]
        H,
        [Description("Jumbo")]
        J
    }
}
