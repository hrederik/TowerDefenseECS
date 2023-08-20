using UnityEngine;

namespace Spawn.Messages
{
    public struct SpawnRequest
    {
        public GameObject Prefab;
        public Vector3? Position;
        public Quaternion? Rotation;
        public Transform Parent;
    }
}