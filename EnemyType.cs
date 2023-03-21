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
            Lava,
            Swimmer
        }

        public static Enemy CreateEnemy(EnemyType enemyType, int x, int y, Map map, AttackMap attackMap, Render render)
        {
            switch (enemyType)
            {
                case EnemyType.Roamer:
                    return new Roamer(x, y, map, attackMap, render, EnemyType.Roamer);
                case EnemyType.Charger:
                    return new Charger(x, y, map, attackMap, render, EnemyType.Charger);
                case EnemyType.Lava:
                    return new Lava(x, y, map, attackMap, render, EnemyType.Lava);
                case EnemyType.Swimmer:
                    return new Swimmer(x, y, map, attackMap, render, EnemyType.Swimmer);
                default:
                    return new Roamer(x, y, map, attackMap, render, EnemyType.Roamer);
            }
        }
    }
}