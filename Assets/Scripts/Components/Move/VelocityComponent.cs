using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Event(EventTarget.Self)]
public class VelocityComponent : IComponent
{ 
    public Vector3 Value;
}