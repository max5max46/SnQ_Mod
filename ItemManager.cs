using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class ItemManager
    {
        List<Item> Items = new List<Item>();

        public void AddItem(ItemTypeClass.ItemType type, int x, int y, Render render, AttackMap attackMap, Map map, Player player)
        {
            Items.Add(ItemTypeClass.CreateItem(type, x, y, render, attackMap, map, player));
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
    }
}