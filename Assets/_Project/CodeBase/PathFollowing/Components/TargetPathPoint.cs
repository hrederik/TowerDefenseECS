using System;
using Helpers.Tools.Codegen;

namespace PathFollowing.Components
{
    [Serializable, ProviderRequired]
    public struct TargetPathPoint
    {
        public int Index;
    }
}