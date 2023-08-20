using System;
using Helpers.Tools.Codegen;

namespace Cooldown.Components
{
    [Serializable, ProviderRequired]
    public struct CooldownValue
    {
        public float Value;
    }
}