using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Item
    {
        public const int HEAL_SMALL = 2;

        private Map map;
        private AttackMap attackMap;
        private Player player;

        private char character;

        private ConsoleColor color;

        private int x, y;

        private bool collected;

        private ItemTypeClass.ItemType Type;

        public Item(char character, ConsoleColor color, int x, int y, ItemTypeClass.ItemType Type)
        {
            this.character = character;
            this.color = color;
            this.x = x;
            this.y = y;
            this.Type = Type;

            collected = false;
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

        public void Draw(Render render)
        {
            render.ChangeSpace(character, ConsoleColor.Black, color, x, y);
        }

        public void Update()
        {
            if (attackMap.IsAttack(x, y))
                if (attackMap.AttackSource(x, y))
                    Collect();
        }

        private void Collect()
        {
            switch (Type)
            {
                case ItemTypeClass.ItemType.HealthPickup:
                    player.Heal(HEAL_SMALL);
                    break;
                case ItemTypeClass.ItemType.Spear:
                    player.ChangeAttackShape(GameCharacter.LONG_ATTACK);
                    break;
                case ItemTypeClass.ItemType.Bomb:
                    GameManager.enemyManager.Bomb();
                    break;
            }
        }
    }
}