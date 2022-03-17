using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ButtonView : SelfInitializedView
{
    [FormerlySerializedAs("doorConverter")] [SerializeField] private DoorView doorView;
        
    protected override void LateInitialize()
    {
        base.LateInitialize();
        Entity.AddGroundButton(doorView.Entity);
    }
}