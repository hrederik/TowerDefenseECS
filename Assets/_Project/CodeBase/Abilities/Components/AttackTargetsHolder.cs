using System.Collections.Generic;
using Leopotam.Ecs;

namespace Abilities.Components
{
    public struct AttackTargetsHolder : IEcsAutoReset<AttackTargetsHolder>
    {
        public List<EcsEntity> Targets;
        
        public void AutoReset(ref AttackTargetsHolder c)
        {
            c.Targets = new List<EcsEntity>(4);
        }
    }
}