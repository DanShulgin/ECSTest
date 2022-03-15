using UnityEngine;

namespace Converters
{
    public class DoorConverter : GameObjectToEntityConverter
    {
        protected override void Convert(GameEntity entity)
        {
            base.Convert(entity);
            entity.AddMove(2.5f, 20f);
            entity.AddVelocity(Vector3.zero);
            entity.AddStoppingDistance(0.01f);
            entity.isDoor = true;
        }
    }
}