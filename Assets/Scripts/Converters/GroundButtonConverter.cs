using UnityEngine;

namespace Converters
{
    public class GroundButtonConverter : GameObjectToEntityConverter
    {
        [SerializeField] private DoorConverter doorConverter;
        
        protected override void Convert(GameEntity entity)
        {
            base.Convert(entity);
            entity.AddGroundButton(doorConverter.gameObject);
        }
    }
}