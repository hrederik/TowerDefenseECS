using System;
using Helpers.Tools.Codegen;
using UnityEngine.UI;

namespace UI.Components
{
    [Serializable, ProviderRequired]
    public struct ButtonLink
    {
        public Button Button;
    }
}