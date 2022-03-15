using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public class PositionComponent : IComponent
{
    public Vector3 Value;
}