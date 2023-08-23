using System.Collections.Generic;
using UnityEngine;

namespace Common.MonoComponents
{
    public class Trigger : MonoBehaviour
    {
        public readonly List<EntityLink> EntitiesInTrigger = new(8);
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<EntityLink>(out var link)) 
                return;
            
            EntitiesInTrigger.Add(link);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent<EntityLink>(out var link)) 
                return;
            
            EntitiesInTrigger.Remove(link);
        }
    }
}