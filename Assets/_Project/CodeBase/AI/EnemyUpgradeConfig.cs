using StaticData;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(menuName = "StaticData/EnemyUpgradeConfig", fileName = "EnemyUpgradeConfig", order = 0)]
    public class EnemyUpgradeConfig : BaseStaticData
    {
        public int DamageIncreaseStep;
        public int HealthIncreaseStep;
    }
}