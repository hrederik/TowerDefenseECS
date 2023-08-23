using System;
using Helpers.Tools.Codegen;

namespace Damage.Components
{
    [Serializable, ProviderRequired]
    public struct BaseHealth
    {
        public int Value;
    }
}