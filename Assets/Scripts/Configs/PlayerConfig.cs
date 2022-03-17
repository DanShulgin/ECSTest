using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObject/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public float stoppingDistance = 0.05f;
        public float alignToVelocitySpeed = 10f;
        public float speed = 5f;
        public float acceleration = 10f;
    }
}