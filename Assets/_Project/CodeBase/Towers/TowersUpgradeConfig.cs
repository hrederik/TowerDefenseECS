using StaticData;
using UnityEngine;

namespace Towers
{
    [CreateAssetMenu(menuName = "StaticData/Configs/TowersUpgradeConfig", fileName = "TowersUpgradeConfig", order = 0)]
    public class TowersUpgradeConfig : BaseStaticData
    {
        public int BaseDamage;
        public int DamageStep;
        
        [Space]
        public int BasePrice;
        public int PriceIncreaseStep;
    }
}