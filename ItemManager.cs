using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Text_Based_RPG
{
    internal class ItemManager
    {
        List<Item> Items = new List<Item>();

        Render render;
        AttackMap attackMap;
        Map map;
        Player player;

        public ItemManager(Render render, AttackMap attackMap, Map map, Player player)
        {
            this.render = render;
            this.attackMap = attackMap;
            this.map = map;
            this.player = player;
        }

        public void AddItem(ItemTypeClass.ItemType type, int x, int y, int cost)
        {
            Items.Add(ItemTypeClass.CreateItem(type, x, y, render, attackMap, map, player, cost));
        }

        public void Update()
        {
            foreach (Item item in Items)
                item.Update();
        }

        public void Draw()
        {
            foreach (Item item in Items)
                item.Draw();
        }

        public void ShowHidden()
        {
            foreach (Item item in Items)
                item.Unhide();
        }

        public void InitItems()
        {
            string[] mapString = File.ReadAllLines("Items.txt");
            char[,] itemMap = new char[mapString.GetLength(0), mapString[0].Length];

            for (int i = 0; i < mapString.GetLength(0); i++)
                for (int j = 0; j < mapString[0].Length; j++)
                    itemMap[i, j] = mapString[i][j];

            for (int i = 0; i < itemMap.GetLength(0); i++)
                for (int j = 0; j < itemMap.GetLength(1); j++)
                {
                    switch (itemMap[i, j])
                    {
                        case Global.GEM_CHAR:
                            AddItem(ItemTypeClass.ItemType.Gem, j, i, Global.GEM_COST);
                            break;
                        case Global.BOAT_CHAR:
                            AddItem(ItemTypeClass.ItemType.Boat, j, i, Global.BOAT_COST);
                            break;
                        case Global.HULA_CHAR:
                            AddItem(ItemTypeClass.ItemType.HulaHoop, j, i, Global.HULA_COST);
                            break;
                        case Global.SPEAR_CHAR:
                            AddItem(ItemTypeClass.ItemType.Spear, j, i, Global.SPEAR_COST);
                            break;
                        case Global.BOMB_CHAR:
                            AddItem(ItemTypeClass.ItemType.Bomb, j, i, Global.BOMB_COST);
                            break;
                        case Global.HEALTH_CHAR:
                            AddItem(ItemTypeClass.ItemType.HealthPickup, j, i, Global.HEALTH_COST);
                            break;
                        case Global.HEALTH_CHAR2:
                            AddItem(ItemTypeClass.ItemType.HealthPickupLarge, j, i, Global.HEALTH_COST2);
                            break;
                        case Global.COINBAG_CHAR:
                            AddItem(ItemTypeClass.ItemType.CoinBag, j, i, Global.COINBAG_COST);
                            break;
                    }
                }
        }
    }
}