using System;
using Helpers.Tools.Codegen;

namespace Currencies.Components
{
    [Serializable, ProviderRequired]
    public struct CoinsForKill
    {
        public int Value;
    }
}