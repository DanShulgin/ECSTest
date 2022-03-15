using UnityEngine;

namespace Converters
{
    public class PlayerConverter : GameObjectToEntityConverter
    {
        protected override void Convert(GameEntity entity)
        {
            base.Convert(entity);
            entity.AddMove(5f);
            entity.isMoveCommandListener = true;
        }
    }
}