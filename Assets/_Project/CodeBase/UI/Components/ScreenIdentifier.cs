using System;
using Helpers.Tools.Codegen;

namespace UI.Components
{
    [Serializable, ProviderRequired]
    public struct ScreenIdentifier
    {
        public UIScreenIdentifiers Value;
    }
}