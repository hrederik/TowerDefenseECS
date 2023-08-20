using System;
using System.Collections.Generic;
using Common.MonoComponents;
using Helpers.Tools.Codegen;

namespace Abilities.Components
{
    [Serializable, ProviderRequired]
    public struct AbilitiesHolder
    {
        public List<EntityLink> Abilities;
    }
}