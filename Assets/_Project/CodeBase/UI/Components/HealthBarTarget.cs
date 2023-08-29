using System;
using Common.MonoComponents;
using Helpers.Tools.Codegen;

namespace UI.Components
{
    [Serializable, ProviderRequired]
    public struct HealthBarTarget
    {
        public EntityLink TargetLink;
    }
}