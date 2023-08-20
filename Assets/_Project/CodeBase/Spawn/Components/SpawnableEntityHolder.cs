using System;
using Helpers.Tools.Codegen;
using UnityEngine;

namespace Spawn.Components
{
    [Serializable, ProviderRequired]
    public struct SpawnableEntityHolder
    {
        public GameObject Prefab;
    }
}