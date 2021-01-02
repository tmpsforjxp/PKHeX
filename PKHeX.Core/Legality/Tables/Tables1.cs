﻿using System.Collections.Generic;

namespace PKHeX.Core
{
    public static partial class Legal
    {
        internal const int MaxSpeciesID_1 = 151;
        internal const int MaxMoveID_1 = 165;
        internal const int MaxItemID_1 = 255;
        internal const int MaxAbilityID_1 = 0;

        internal static readonly ushort[] Pouch_Items_RBY =
        {
            000,001,002,003,004,005,006,            010,011,012,013,014,015,
            016,017,018,019,020,                                029,030,031,
            032,033,034,035,036,037,038,039,040,041,042,043,    045,046,047,
            048,049,    051,052,053,054,055,056,057,058,    060,061,062,063,
            064,065,066,067,068,069,070,071,072,073,074,075,076,077,078,079,
            080,081,082,083,

            // ...

            196,197,198,199,200,201,202,203,204,205,206,207,
            208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223,
            224,225,226,227,228,229,230,231,232,233,234,235,236,237,238,239,
            240,241,242,243,244,245,246,247,248,249,250,
        };

        internal static readonly byte[] MovePP_RBY =
        {
            0,
            35, 25, 10, 15, 20, 20, 15, 15, 15, 35, 30, 05, 10, 30, 30, 35, 35, 20, 15, 20, 20, 10, 20, 30, 05, 25, 15, 15, 15, 25, 20, 05, 35, 15, 20, 20, 20, 15, 30, 35, 20, 20, 30, 25, 40, 20, 15, 20, 20, 20,
            30, 25, 15, 30, 25, 05, 15, 10, 05, 20, 20, 20, 05, 35, 20, 25, 20, 20, 20, 15, 20, 10, 10, 40, 25, 10, 35, 30, 15, 20, 40, 10, 15, 30, 15, 20, 10, 15, 10, 05, 10, 10, 25, 10, 20, 40, 30, 30, 20, 20,
            15, 10, 40, 15, 20, 30, 20, 20, 10, 40, 40, 30, 30, 30, 20, 30, 10, 10, 20, 05, 10, 30, 20, 20, 20, 05, 15, 10, 20, 15, 15, 35, 20, 15, 10, 20, 30, 15, 40, 20, 15, 10, 05, 10, 30, 10, 15, 20, 15, 40,
            40, 10, 05, 15, 10, 10, 10, 15, 30, 30, 10, 10, 20, 10, 10, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00,
            00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00,
            00, 00, 00, 00, 00, 00
        };

        internal static bool TransferSpeciesDefaultAbilityGen1(int species)
        {
            System.Diagnostics.Debug.Assert(species <= (uint)MaxSpeciesID_1);
            return species is (int)Species.Gastly or (int)Species.Haunter or (int)Species.Gengar
                or (int)Species.Koffing or (int)Species.Weezing
                or (int)Species.Mew;
        }

        internal static readonly int[] TMHM_RBY =
        {
            005, 013, 014, 018, 025, 092, 032, 034, 036, 038,
            061, 055, 058, 059, 063, 006, 066, 068, 069, 099,
            072, 076, 082, 085, 087, 089, 090, 091, 094, 100,
            102, 104, 115, 117, 118, 120, 121, 126, 129, 130,
            135, 138, 143, 156, 086, 149, 153, 157, 161, 164,

            015, 019, 057, 070, 148
        };
        
        internal static readonly HashSet<int> FutureEvolutionsGen1 = new()
        {
            (int)Species.Crobat,
            (int)Species.Bellossom,
            (int)Species.Politoed,
            (int)Species.Espeon,
            (int)Species.Umbreon,
            (int)Species.Slowking,
            (int)Species.Steelix,
            (int)Species.Scizor,
            (int)Species.Kingdra,
            (int)Species.Porygon2,
            (int)Species.Blissey,
            (int)Species.Magnezone,
            (int)Species.Lickilicky,
            (int)Species.Rhyperior,
            (int)Species.Tangrowth,
            (int)Species.Electivire,
            (int)Species.Magmortar,
            (int)Species.Leafeon,
            (int)Species.Glaceon,
            (int)Species.PorygonZ,
            (int)Species.Sylveon,
        };
    }
}
