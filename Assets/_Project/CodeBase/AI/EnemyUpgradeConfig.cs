using StaticData;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "StaticData/EnemyUpgradeConfig", fileName = "EnemyUpgradeConfig", order = 0)]
    public class EnemyUpgradeConfig : BaseStaticData
    {
        public int BaseDamage;
        public int DamageIncreaseStep;
        
        [Space]
        public int BaseHealth;
        public int HealthIncreaseStep;
    }
}