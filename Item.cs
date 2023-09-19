using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Item
    {
        private Map map;
        private AttackMap attackMap;
        private Player player;
        private Render render;

        private char character;

        private ConsoleColor color;

        private int cost;

        private bool aboutToBuy = false;

        private int x, y;

        private bool collected, hidden;

        private ItemTypeClass.ItemType Type;
        private string name;

        public Item(char character, ConsoleColor color, int x, int y, ItemTypeClass.ItemType Type, Render render, AttackMap attackMap, Map map, Player player, string name, int cost)
        {
            this.character = character;
            this.color = color;
            this.x = x;
            this.y = y;
            this.Type = Type;
            this.render = render;
            this.attackMap = attackMap;
            this.map = map;
            this.player = player;
            this.name = name;
            this.cost = cost;
            
            collected = false;

            if (Type == ItemTypeClass.ItemType.Gem)
                hidden = true;
            else hidden = false;
        }

        public void GetMap(Map map)
        {
            this.map = map;
        }
        public void GetAttackMap(AttackMap attackMap)
        {
            this.attackMap = attackMap;
        }
        public void GetPlayer(Player player)
        {
            this.player = player;
        }

        public void Draw()
        {
            if (collected || hidden)
                return;
            render.ChangeSpace(character, ConsoleColor.Black, color, x, y);
        }

        public void Update()
        {
            if (collected || hidden)
                return;
            if (attackMap.IsAttack(x, y))
                if (attackMap.PlayerAttackCheck(x, y))
                    if (map.GetChar(x, y) == 'x')
                    {
                        Collect(true);
                        return;
                    }
                    else
                        Collect(false);

            aboutToBuy = false;
        }

        private void Collect(bool inShop)
        {
            int coinAmount = 0;
            if (inShop)
            {
                if (aboutToBuy == true)
                    if (player.GetCoins() >= cost)
                    {
                        GameManager.playerUI.AddEvent("Player bought a " + name);
                        player.TakeCoins(cost);
                    }else
                    {
                        GameManager.playerUI.AddEvent("\"Sorry Bud, you don't have enough coins for that\" -ShopKeeper");
                        return;
                    }
                else
                {
                    GameManager.playerUI.AddEvent("\"That " + name + "? that will be " + cost + " coins\" -ShopKeeper");
                    aboutToBuy = true;
                    return;
                }

            }else

                if (Type == ItemTypeClass.ItemType.CoinBag)
                {
                    coinAmount = Global.random.Next(Global.COINBAG_RANGE) + Global.COINBAG_MIN;
                    GameManager.playerUI.AddEvent("Player collected a " + name + " worth " + coinAmount + " coins");
                }else
                    GameManager.playerUI.AddEvent("Player collected a " + name);


            switch (Type)
            {
                case ItemTypeClass.ItemType.HealthPickup:
                    player.Heal(Global.HEAL_SMALL);
                    break;
                case ItemTypeClass.ItemType.HealthPickupLarge:
                    player.Heal(Global.HEAL_LARGE);
                    break;
                case ItemTypeClass.ItemType.Spear:
                    player.ChangeAttackShape(Global.LONG_ATTACK);
                    break;
                case ItemTypeClass.ItemType.HulaHoop:
                    player.ChangeAttackShape(Global.RING_ATTACK);
                    break;
                case ItemTypeClass.ItemType.Bomb:
                    GameManager.enemyManager.Bomb();
                    break;
                case ItemTypeClass.ItemType.Boat:
                    player.getBoat();
                    break;
                case ItemTypeClass.ItemType.Gem:
                    GameManager.gameWin = true;
                    break;
                case ItemTypeClass.ItemType.CoinBag:
                    player.GiveCoins(coinAmount);
                    break;
            }
            collected = true;
        }

        public void Unhide()
        {
            if (hidden)
            {
                hidden = false;
                GameManager.playerUI.AddEvent("A " + name + " was revealed!");
            }
        }
    }
}