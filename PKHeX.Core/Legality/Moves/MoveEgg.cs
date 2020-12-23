﻿using System;
using System.Collections.Generic;
using static PKHeX.Core.Legal;

namespace PKHeX.Core
{
    public static class MoveEgg
    {
        public static int[] GetEggMoves(PKM pkm, int species, int form, GameVersion version)
        {
            int gen = pkm.Format <= 2 || pkm.VC ? 2 : pkm.Generation;
            if (!pkm.InhabitedGeneration(gen, species) || (pkm.PersonalInfo.Genderless && !FixedGenderFromBiGender.Contains(species)))
                return Array.Empty<int>();

            if (pkm.Version == 15 || pkm.GG)
                return Array.Empty<int>();

            if (version == GameVersion.Any)
                version = (GameVersion)pkm.Version;
            return GetEggMoves(gen, species, form, version);
        }

        public static int[] GetEggMoves(int gen, int species, int form, GameVersion version)
        {
            switch (gen)
            {
                case 1:
                case 2:
                    return (version == GameVersion.C ? EggMovesC : EggMovesGS)[species].Moves;
                case 3:
                    return EggMovesRS[species].Moves;
                case 4:
                    return version switch
                    {
                        GameVersion.HG => EggMovesHGSS[species].Moves,
                        GameVersion.SS => EggMovesHGSS[species].Moves,
                        _ => EggMovesDPPt[species].Moves
                    };
                case 5:
                    return EggMovesBW[species].Moves;
                case 6: // entries per species
                    return version switch
                    {
                        GameVersion.OR => EggMovesAO[species].Moves,
                        GameVersion.AS => EggMovesAO[species].Moves,
                        _ => EggMovesXY[species].Moves
                    };

                case 7: // entries per form if required
                    return version switch
                    {
                        GameVersion.US => GetFormEggMoves(species, form, EggMovesUSUM),
                        GameVersion.UM => GetFormEggMoves(species, form, EggMovesUSUM),
                        _ => GetFormEggMoves(species, form, EggMovesSM)
                    };

                case 8:
                    return version switch
                    {
                        _ => GetFormEggMoves(species, form, EggMovesSWSH)
                    };

                default:
                    return Array.Empty<int>();
            }
        }

        private static int[] GetFormEggMoves(int species, int form, IReadOnlyList<EggMoves7> table)
        {
            var entry = table[species];
            if (form > 0 && entry.FormTableIndex > species)
                entry = table[entry.FormTableIndex + form - 1];
            return entry.Moves;
        }

        internal static int[] GetRelearnLVLMoves(PKM pkm, int species, int form, int lvl, GameVersion version = GameVersion.Any)
        {
            if (version == GameVersion.Any)
                version = (GameVersion)pkm.Version;
            // A pkm can only have levelup relearn moves from the game it originated on
            // eg Plusle/Minun have Charm/Fake Tears (respectively) only in OR/AS, not X/Y
            switch (version)
            {
                case GameVersion.X:
                case GameVersion.Y:
                    return getMoves(LevelUpXY, PersonalTable.XY);
                case GameVersion.AS:
                case GameVersion.OR:
                    return getMoves(LevelUpAO, PersonalTable.AO);

                case GameVersion.SN:
                case GameVersion.MN:
                    if (species > MaxSpeciesID_7)
                        break;
                    return getMoves(LevelUpSM, PersonalTable.SM);
                case GameVersion.US:
                case GameVersion.UM:
                    return getMoves(LevelUpUSUM, PersonalTable.USUM);

                case GameVersion.SW:
                case GameVersion.SH:
                    return getMoves(LevelUpSWSH, PersonalTable.SWSH);
            }
            return Array.Empty<int>();

            int[] getMoves(IReadOnlyList<Learnset> moves, PersonalTable table) => moves[table.GetFormIndex(species, form)].GetMoves(lvl);
        }

        public static bool GetIsSharedEggMove(PKM pkm, int gen, int move)
        {
            if (gen < 8 || pkm.IsEgg)
                return false;
            var table = PersonalTable.SWSH;
            var entry = (PersonalInfoSWSH)table.GetFormEntry(pkm.Species, pkm.Form);
            var baseSpecies = entry.HatchSpecies;
            var baseForm = entry.HatchFormIndexEverstone;
            var egg = GetEggMoves(8, baseSpecies, baseForm, GameVersion.SW);
            return Array.Exists(egg, z => z == move);
        }
    }
}
