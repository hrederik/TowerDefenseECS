using StaticData;
using UnityEngine;

namespace SceneLoading
{
    [CreateAssetMenu(menuName = "StaticData/Configs/ScenesConfig", fileName = "ScenesConfig", order = 0)]
    public class ScenesConfig : BaseStaticData
    {
        public string GameSceneName;
    }
}