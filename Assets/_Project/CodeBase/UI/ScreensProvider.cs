using System;
using System.Collections.Generic;
using System.Linq;
using StaticData;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(menuName = "StaticData/ScreensProvider", fileName = "ScreensProvider", order = 0)]
    public class ScreensProvider : BaseStaticData, IInitialize
    {
        [SerializeField] private ScreenInfo[] _screenInfos;
        private Dictionary<UIScreenIdentifiers, ScreenInfo> _screenInfosMap;

        public void Init()
        {
            _screenInfosMap = _screenInfos.ToDictionary(x => x.Identifier, y => y);
        }

        public bool TryGet(UIScreenIdentifiers identifier, out ScreenInfo screenInfo)
        {
            return _screenInfosMap.TryGetValue(identifier, out screenInfo);
        }
    }

    [Serializable]
    public struct ScreenInfo
    {
        public UIScreenIdentifiers Identifier;
        public GameObject Prefab;
    }
}