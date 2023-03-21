using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class ItemTypeClass
    {
        public enum ItemType
        {
            HealthPickup,
            Spear,
            Bomb,
            Boat,
            HealthPickupLarge
        }

        public static Item CreateItem(ItemType itemType, int x, int y, Render render, AttackMap attackMap, Map map, Player player)
        {
            switch (itemType)
            {
                case ItemType.HealthPickup:
                    return new Item('♥', ConsoleColor.Magenta, x, y, itemType, render, attackMap, map, player, "health pickup");
                case ItemType.HealthPickupLarge:
                    return new Item('♥', ConsoleColor.Red, x, y, itemType, render, attackMap, map, player, "large health pickup");
                case ItemType.Spear:
                    return new Item('↑', ConsoleColor.Gray, x, y, itemType, render, attackMap, map, player, "spear");
                case ItemType.Bomb:
                    return new Item('B', ConsoleColor.White, x, y, itemType, render, attackMap, map, player, "bomb");
                case ItemType.Boat:
                    return new Item('U', ConsoleColor.Yellow, x, y, itemType, render, attackMap, map, player, "boat");
                default:
                    return new Item('♥', ConsoleColor.Magenta, x, y, itemType, render, attackMap, map, player, "health pickup");
            }
        }
    }
}