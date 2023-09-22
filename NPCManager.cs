using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Text_Based_RPG
{
    internal class NPCManager
    {
        private Render render;
        private Map map;
        private AttackMap attackMap;
        private Player player;
        private ItemManager itemManager;
        private char[,] npcMap;

        public NPCManager(AttackMap attackMap, Player player, Render render, Map map, ItemManager itemManager)
        {
            this.attackMap = attackMap;
            this.player = player;
            this.render = render;
            this.map = map;
            this.itemManager = itemManager;

            string[] mapString = File.ReadAllLines("NPCs.txt");
            npcMap = new char[mapString.GetLength(0), mapString[0].Length];

            for (int i = 0; i < mapString.GetLength(0); i++)
                for (int j = 0; j < mapString[0].Length; j++)
                    npcMap[i, j] = mapString[i][j];
        }

        List<NPC> npcs = new List<NPC>();

        public void AddNPC(NPCTypeClass.NPCType Type, int x, int y)
        {
            npcs.Add(NPCTypeClass.CreateNPC(Type, x, y, map, attackMap, render));
        }

        public void Update()
        {
            foreach (NPC npc in npcs)
            {
                npc.Update();
            }
        }

        public void Draw()
        {
            foreach (NPC npc in npcs)
            {
                
                npc.Draw();
            }
        }

        public void NPCInteract()
        {
            foreach (NPC npc in npcs)
            {
                if (attackMap.IsAttack(npc.GetPos()[0], npc.GetPos()[1]) && attackMap.PlayerAttackCheck(npc.GetPos()[0], npc.GetPos()[1]))
                {
                    npc.Interact();
                }
            }
        }

        public void InitNPCs()
        {
            for (int i = 0; i < npcMap.GetLength(0); i++)
                for (int j = 0; j < npcMap.GetLength(1); j++)
                {
                    switch (npcMap[i, j])
                    {
                        case Global.QUEST_CHAR:
                            AddNPC(NPCTypeClass.NPCType.QuestDealer, j, i);
                            break;
                        case Global.SHOP_CHAR:
                            AddNPC(NPCTypeClass.NPCType.ShopKeep, j, i);
                            break;
                        case Global.GAMBLER_CHAR:
                            AddNPC(NPCTypeClass.NPCType.Gambler, j, i);
                            break;
                        case Global.FISHERMAN_CHAR:
                            AddNPC(NPCTypeClass.NPCType.Fisherman, j, i);
                            break;
                        case Global.MAYOR_CHAR:
                            AddNPC(NPCTypeClass.NPCType.Mayor, j, i);
                            break;
                        case Global.SOLDIER_CHAR:
                            AddNPC(NPCTypeClass.NPCType.RetiredSoldier, j, i);
                            break;
                        case Global.HERMIT_CHAR:
                            AddNPC(NPCTypeClass.NPCType.OldHermit, j, i);
                            break;
                        case Global.GRASSGUY_CHAR:
                            AddNPC(NPCTypeClass.NPCType.GrassGuy, j, i);
                            break;
                        case Global.SANDGUY_CHAR:
                            AddNPC(NPCTypeClass.NPCType.SandGuy, j, i);
                            break;
                        case Global.DOCKGUY_CHAR:
                            AddNPC(NPCTypeClass.NPCType.DockGuy, j, i);
                            break;
                        case Global.SIGN_CHAR:
                            AddNPC(NPCTypeClass.NPCType.Sign, j, i);
                            break;
                        case Global.JOURNAL_CHAR:
                            AddNPC(NPCTypeClass.NPCType.Journal, j, i);
                            break;
                    }
                }
        }

        public bool IsNPCHere(int x, int y)
        {
            switch (npcMap[y, x])
            {
                case Global.QUEST_CHAR:
                case Global.SHOP_CHAR:
                case Global.GAMBLER_CHAR:
                case Global.FISHERMAN_CHAR:
                case Global.MAYOR_CHAR:
                case Global.SOLDIER_CHAR:
                case Global.HERMIT_CHAR:
                case Global.GRASSGUY_CHAR:
                case Global.SANDGUY_CHAR:
                case Global.DOCKGUY_CHAR:
                case Global.SIGN_CHAR:
                case Global.JOURNAL_CHAR:
                    return true;
                default: 
                    return false;
            }
        }
    }
}