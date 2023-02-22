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
            Enemy3
        }

        public static EnemyClass CreateEnemy(EnemyType enemyType, int x, int y, Map map, AttackMap attackMap, Render render)
        {
            switch (enemyType)
            {
                case EnemyType.Roamer:
                    return new EnemyClass(x, y, 2, 2, 1, EnemyClass.BEHAVIOUR_RANDOM, GameCharacter.CROSS_ATTACK, '0', false, enemyType.ToString(), map, attackMap, render);
                case EnemyType.Charger:
                    return new EnemyClass(x, y, 1, 1, 2, EnemyClass.BEHAVIOUR_CHASE, GameCharacter.SPACE_ATTACK, 'V', true, enemyType.ToString(), map, attackMap, render);
                case EnemyType.Enemy3:
                    return new EnemyClass(x, y, 1, 2, 1, EnemyClass.BEHAVIOUR_RANDOM, GameCharacter.CROSS_ATTACK, '0', false, enemyType.ToString(), map, attackMap, render);
                default:
                    return new EnemyClass(x, y, 1, 2, 1, EnemyClass.BEHAVIOUR_RANDOM, GameCharacter.CROSS_ATTACK, '0', false, enemyType.ToString(), map, attackMap, render);
            }
        }
    }
}