using System;
using Helpers.Tools.Codegen;
using UnityEngine;

namespace Common.Components
{
    [Serializable, ProviderRequired]
    public struct GameObjectLink
    {
        public GameObject GameObject;
    }
}