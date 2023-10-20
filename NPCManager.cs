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
        private struct NPCStats
        {
            public string name;
            public char characterOnNPCMap;
            public char character;
            public string[] dialogue;
        }

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

        private void AddNPC(int x, int y, NPCStats NPC)
        {
            npcs.Add(new NPC(x, y, map, attackMap, render, NPC.character, NPC.name, NPC.dialogue));
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
            NPCStats[] NPCs = InitEachNPC();

            for (int i = 0; i < npcMap.GetLength(0); i++)
                for (int j = 0; j < npcMap.GetLength(1); j++)
                    foreach (NPCStats NPC in NPCs)
                        if (npcMap[i, j] == NPC.characterOnNPCMap)
                            AddNPC(j, i, NPC);
        }

        private NPCStats[] InitEachNPC()
        {
            string txtNPCs;
            string[] txtEachNPC;
            string[] txtNPCStats;
            NPCStats[] NPCs;
            int NPCIndex = 0;

            txtNPCs = File.ReadAllText("EachNPC.txt");
            txtEachNPC = txtNPCs.Split('{');
            NPCs = new NPCStats[txtEachNPC.GetLength(0) - 1];

            foreach (string txtNPC in txtEachNPC)
            {
                if (txtNPC.Contains('}'))
                {
                    txtNPCStats = txtNPC.Split('[');
                    foreach (string txtNPCStat in txtNPCStats)
                    {
                        if (txtNPCStat.Contains(']'))
                        {
                            switch (txtNPCStat.ToLower())
                            {
                                case string s when s.Contains("name"):
                                    if (txtNPCStat.IndexOf('(') != -1 && txtNPCStat.IndexOf(')') != -1)
                                        NPCs[NPCIndex].name = txtNPCStat.Substring(txtNPCStat.IndexOf('(') + 1, txtNPCStat.IndexOf(')') - (txtNPCStat.IndexOf('(') + 1));
                                    break;

                                case string s when s.Contains("symbol used in npc map"):
                                    if (txtNPCStat.IndexOf('(') != -1 && txtNPCStat.IndexOf(')') != -1)
                                        NPCs[NPCIndex].characterOnNPCMap = txtNPCStat.Substring(txtNPCStat.IndexOf('(') + 1, txtNPCStat.IndexOf(')') - (txtNPCStat.IndexOf('(') + 1))[0];
                                    break;

                                case string s when s.Contains("symbol used in gameplay"):
                                    if (txtNPCStat.IndexOf('(') != -1 && txtNPCStat.IndexOf(')') != -1)
                                        NPCs[NPCIndex].character = txtNPCStat.Substring(txtNPCStat.IndexOf('(') + 1, txtNPCStat.IndexOf(')') - (txtNPCStat.IndexOf('(') + 1))[0];
                                    break;

                                case string s when s.Contains("dialogue"):

                                    int dialogueIndex = 0;
                                    string[] dialogue = txtNPCStat.Split('(');
                                    NPCs[NPCIndex].dialogue = new string[dialogue.GetLength(0) - 1];

                                    foreach (string line in dialogue)
                                    {
                                        if (line.Contains(')'))
                                        {
                                            if (line.IndexOf(')') != -1)
                                                NPCs[NPCIndex].dialogue[dialogueIndex] = line.Substring(0, line.IndexOf(')'));
                                            dialogueIndex++;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    NPCIndex++;
                }
            }

            return NPCs;
        }

    }
}