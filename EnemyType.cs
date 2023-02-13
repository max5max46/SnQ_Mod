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
            Enemy1,
            Enemy2,
            Enemy3
        }

        public static EnemyClass CreateEnemy(EnemyType enemyType, int x, int y)
        {
            switch (enemyType)
            {
                case EnemyType.Enemy1:
                    return new EnemyClass(x, y, 2, 2, EnemyClass.BEHAVIOUR_RANDOM,'0');
                case EnemyType.Enemy2:
                    return new EnemyClass(x, y, 1, 1, EnemyClass.BEHAVIOUR_CHASE, 'V');
                case EnemyType.Enemy3:
                    return new EnemyClass(x, y, 1, 2, EnemyClass.BEHAVIOUR_RANDOM, '0');
                default:
                    return new EnemyClass(x, y, 1, 2, EnemyClass.BEHAVIOUR_RANDOM, '0');
            }
        }
    }
}