using StaticData;
using UnityEngine;

namespace Spawn
{
    [CreateAssetMenu(menuName = "StaticData/Configs/SpawnConfig", fileName = "SpawnConfig", order = 0)]
    public class SpawnConfig : BaseStaticData
    {
        public int UpperWaveBoundOffset;
        public float EnemyDelay;
        public float WaveDelay;
    }
}