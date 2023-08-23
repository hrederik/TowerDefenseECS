using System;
using Helpers.Tools.Codegen;
using TMPro;

namespace UI.Components
{
    [Serializable, ProviderRequired]
    public struct TextLink
    {
        public TMP_Text Text;
    }
}