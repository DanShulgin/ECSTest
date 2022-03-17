using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ButtonView : SelfInitializedView
{
    [FormerlySerializedAs("doorConverter")] [SerializeField] private DoorView doorView;
    
    private void Start()
    {
        LateInitialize();
    }
    
    private void LateInitialize()
    {
        Entity.AddGroundButton(doorView.Entity);
    }
}