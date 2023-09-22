using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class NPCTypeClass
    {
        public enum NPCType
        {
            ShopKeep,
            Gambler,
            QuestDealer,
            Fisherman,
            Mayor,
            RetiredSoldier,
            OldHermit,
            GrassGuy,
            SandGuy,
            DockGuy,
            Sign,
            Journal
        }

        public static NPC CreateNPC(NPCType npcType, int x, int y, Map map, AttackMap attackMap, Render render)
        {
            switch (npcType)
            {
                case NPCType.ShopKeep:
                    return new ShopKeep(x, y, map, attackMap, render, NPCType.ShopKeep);
                case NPCType.Gambler:
                    return new Gambler(x, y, map, attackMap, render, NPCType.Gambler);
                case NPCType.QuestDealer:
                    return new QuestDealer(x, y, map, attackMap, render, NPCType.QuestDealer);
                case NPCType.Fisherman:
                    return new Fisherman(x, y, map, attackMap, render, NPCType.Fisherman);
                case NPCType.Mayor:
                    return new Mayor(x, y, map, attackMap, render, NPCType.Mayor);
                case NPCType.RetiredSoldier:
                    return new RetiredSoldier(x, y, map, attackMap, render, NPCType.RetiredSoldier);
                case NPCType.OldHermit:
                    return new OldHermit(x, y, map, attackMap, render, NPCType.OldHermit);
                case NPCType.GrassGuy:
                    return new GrassGuy(x, y, map, attackMap, render, NPCType.GrassGuy);
                case NPCType.SandGuy:
                    return new SandGuy(x, y, map, attackMap, render, NPCType.SandGuy);
                case NPCType.DockGuy:
                    return new DockGuy(x, y, map, attackMap, render, NPCType.DockGuy);
                case NPCType.Sign:
                    return new Sign(x, y, map, attackMap, render, NPCType.Sign);
                case NPCType.Journal:
                    return new Journal(x, y, map, attackMap, render, NPCType.Journal);
                default: return null;
            }
        }
    }
}