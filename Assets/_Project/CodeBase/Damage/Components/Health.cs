using System;
using Helpers.Tools.Codegen;

namespace Damage.Components
{
    [Serializable, ProviderRequired]
    public struct Health
    {
        public int Value;
    }
}