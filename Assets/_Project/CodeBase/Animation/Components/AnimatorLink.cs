using System;
using Helpers.Tools.Codegen;
using UnityEngine;

namespace Animation.Components
{
    [Serializable, ProviderRequired]
    public struct AnimatorLink
    {
        public Animator Animator;
    }
}