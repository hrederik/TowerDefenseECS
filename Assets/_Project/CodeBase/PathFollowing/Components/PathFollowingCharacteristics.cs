using System;
using Helpers.Tools.Codegen;

namespace PathFollowing.Components
{
    [Serializable, ProviderRequired]
    public struct PathFollowingCharacteristics
    {
        public float Speed;
        public float RotationSpeed;
    }
}