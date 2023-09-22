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

        private enum ShopState
        {
            Field,
            NonRestock,
            Restocks
        }

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
                    switch (map.GetChar(x, y))
                    {
                        case 'x':
                            Collect(ShopState.NonRestock); return;
                        case 'r':
                            Collect(ShopState.Restocks); return;
                        default:
                            Collect(ShopState.Field); break;
                    }

            aboutToBuy = false;
        }

        private void Collect(ShopState shopState)
        {
            int coinAmount = 0;
            if (shopState == ShopState.NonRestock || shopState == ShopState.Restocks)
            {
                if (aboutToBuy == true)
                    if (player.GetCoins() >= cost)
                    {
                        if (Type == ItemTypeClass.ItemType.CoinBag)
                        {
                            coinAmount = Global.random.Next(Global.COINBAG_RANGE) + Global.COINBAG_MIN;
                            GameManager.playerUI.AddEvent("Player bought a " + name + " worth " + coinAmount + " coins");
                        }
                        else
                            GameManager.playerUI.AddEvent("Player bought a " + name);
                        player.TakeCoins(cost);
                    }else
                    {
                        GameManager.playerUI.AddEvent("You wanted the " + name + ", but didn't have enough");
                        return;
                    }
                else
                {
                    if (shopState == ShopState.Restocks)
                        GameManager.playerUI.AddEvent("Try to buy the " + name + " worth " + cost + " coins? (Restocks)");
                    else
                        GameManager.playerUI.AddEvent("Try to buy the " + name + " worth " + cost + " coins? (Limited)");
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

            if (shopState == ShopState.Restocks) {
                aboutToBuy = false; return;
            }else
                collected = true;
        }

        public void Unhide()
        {
            if (hidden)
            {
                hidden = false;
                GameManager.playerUI.AddEvent("You killed all the Elites!");
            }
        }
    }
}