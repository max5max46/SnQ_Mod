using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class EnemyTypeClass
    {
        public enum EnemyType
        {
            Roamer,
            Charger,
            Lava
        }

        public static Enemy CreateEnemy(EnemyType enemyType, int x, int y, Map map, AttackMap attackMap, Render render)
        {
            switch (enemyType)
            {
                case EnemyType.Roamer:
                    return new Enemy(x, y, 2, 2, 1, Enemy.BEHAVIOUR_RANDOM, GameCharacter.CROSS_ATTACK, '0', false, enemyType.ToString(), map, attackMap, render);
                case EnemyType.Charger:
                    return new Enemy(x, y, 1, 1, 2, Enemy.BEHAVIOUR_CHASE, GameCharacter.SPACE_ATTACK, 'V', true, enemyType.ToString(), map, attackMap, render);
                case EnemyType.Lava:
                    return new Enemy(x, y, 1, 1, 3, Enemy.BEHAVIOUR_LAVA, GameCharacter.RING_ATTACK, '!', false, enemyType.ToString(), map, attackMap, render);
                default:
                    return new Enemy(x, y, 1, 2, 1, Enemy.BEHAVIOUR_RANDOM, GameCharacter.CROSS_ATTACK, '0', false, enemyType.ToString(), map, attackMap, render);
            }
        }
    }
}