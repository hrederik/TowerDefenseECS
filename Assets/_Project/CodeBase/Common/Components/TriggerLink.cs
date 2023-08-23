using System;
using Common.MonoComponents;
using Helpers.Tools.Codegen;

namespace Common.Components
{
    [Serializable, ProviderRequired]
    public struct TriggerLink
    {
        public Trigger Trigger;
    }
}