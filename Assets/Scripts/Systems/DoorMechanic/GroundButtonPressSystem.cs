using System.Collections.Generic;
using Configs;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Systems.DoorMechanic
{
    public class GroundButtonPressSystem : IExecuteSystem
    {
        private Contexts _contexts;
        private IGroup<GameEntity> _groundButtons;
        private readonly DoorConfig _doorConfig;

        public GroundButtonPressSystem(Contexts contexts, DoorConfig doorConfig)
        {
            _contexts = contexts;
            _groundButtons = contexts.game.GetGroup(GameMatcher.GroundButton);
            _doorConfig = doorConfig;
        }

        public void Execute()
        {
            foreach (var entity in _groundButtons.GetEntities())
            {
                var dir = _contexts.game.playerEntity.position.Value - entity.position.Value;
                var magnitude = dir.magnitude;
                if (magnitude < 1f)
                {
                    var buttonComponent = entity.groundButton;
                    var doorEntity = buttonComponent.Door;
                    
                    if (!doorEntity.isOpened)
                    {
                        doorEntity.isOpened = true;
                        doorEntity.AddMoveTargetPosition(doorEntity.position.Value - Vector3.up * _doorConfig.downMoveDistance);
                    }
                }
            }
        }
    }
}