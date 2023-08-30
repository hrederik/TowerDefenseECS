using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/StaticDataProvider", fileName = "StaticDataProvider", order = 0)]
    public class StaticDataProvider : ScriptableObject
    {
        [SerializeField] private BaseStaticData[] _staticData;
        private Dictionary<Type, BaseStaticData> _staticDataMap;

        public void Init()
        {
            for (var i = 0; i < _staticData.Length; i++)
            {
                if (_staticData[i] is IInitialize initialize)
                    initialize.Init();
            }

            _staticDataMap = _staticData.ToDictionary(key => key.GetType(), value => value);
        }

        public bool TryGetData<T>(out T data)
        {
            data = default;
            
            if (!_staticDataMap.TryGetValue(typeof(T), out var baseData)) return false;
            if (baseData is not T concreteData) return false;

            data = concreteData;
            return true;
        }
    }
}