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

        public NPCManager(AttackMap attackMap, Player player, Render render, Map map, ItemManager itemManager)
        {
            this.attackMap = attackMap;
            this.player = player;
            this.render = render;
            this.map = map;
            this.itemManager = itemManager;
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

        public void Bomb()
        {
            foreach (NPC npc in npcs)
                npc.TakeDamageDirect(Global.SMALL_BOMB_DAMAGE);
        }

        public void DamageNPCs()
        {
            foreach (NPC npc in npcs)
            {
                if (attackMap.IsAttack(npc.GetPos()[0], npc.GetPos()[1]) && attackMap.PlayerAttackCheck(npc.GetPos()[0], npc.GetPos()[1]))
                {
                    npc.TakeDamage(attackMap.AttackStrength(npc.GetPos()[0], npc.GetPos()[1]));
                }
            }
        }

        public void InitNPCs()
        {
            string[] mapString = File.ReadAllLines("NPCs.txt");
            char[,] npcMap = new char[mapString.GetLength(0), mapString[0].Length];

            for (int i = 0; i < mapString.GetLength(0); i++)
                for (int j = 0; j < mapString[0].Length; j++)
                    npcMap[i, j] = mapString[i][j];
            
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
                        case Global.SIGN_CHAR:
                            AddNPC(NPCTypeClass.NPCType.Sign, j, i);
                            break;
                    }
                }
        }
    }
}