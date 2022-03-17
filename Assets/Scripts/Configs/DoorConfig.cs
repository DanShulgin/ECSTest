using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "DoorConfig", menuName = "ScriptableObject/DoorConfig", order = 0)]
    public class DoorConfig : ScriptableObject
    {
        public float stoppingDistance = 0.01f;
        public float speed = 2.5f;
        public float acceleration = 20f;
        public float downMoveDistance = 2.5f;
    }
}