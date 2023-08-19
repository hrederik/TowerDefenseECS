using System;
using Helpers.Tools.Codegen;
using UnityEngine;

namespace PathFollowing.Components
{
    [Serializable, ProviderRequired]
    public struct PathHolder
    {
        public Transform[] Path;
    }
}