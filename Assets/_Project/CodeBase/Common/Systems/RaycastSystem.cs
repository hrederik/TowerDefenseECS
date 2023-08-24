using Common.Messages;
using Common.MonoComponents;
using Helpers;
using Helpers.Extensions;
using Leopotam.Ecs;
using UnityEngine;

namespace Common.Systems
{
    public class RaycastSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        
        public void Run()
        {
            if (!Input.GetMouseButtonDown(0)) 
                return;

            var ray = CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (!Physics.Raycast(ray, out var hit, 100))
                return;
            
            if (!hit.transform.gameObject.TryGetComponent<EntityLink>(out var entityLink))
                return;
            
            world.Message(new EntitySelectedByRaycastEvent
            {
                EntityLink = entityLink
            });
        }
    }
}