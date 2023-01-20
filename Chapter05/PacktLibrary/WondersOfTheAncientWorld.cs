using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.Shared
{
    // An enum type is a very efficient way of storing one or more choices 
    // because, internally, it uses integer values in combination with a lookup
    // table of string descriptions.
    [System.Flags]
    public enum WondersOfTheAncientWorld : byte
    {
        None = 0b_0000_0000,                        // 0
        GreatPyramidOfGiza = 0b_0000_0001,          // 1
        HangingGardensOfBabylon = 0b_0000_0010,     // 2
        StatueOfZeusAtOlympia = 0b_0000_0100,       // 4           
        TempleOfArtemiseAtEphesus = 0b_0000_1000,   // 8
        MausoleumAtHalicarnassus = 0b_0001_0000,    // 16
        ColossusOfRhodes = 0b_0010_0000,            // 32
        LighthouseOfAlexandria = 0b_0100_0000       // 64
    }
}
