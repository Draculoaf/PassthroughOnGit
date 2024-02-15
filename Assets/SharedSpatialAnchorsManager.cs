using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SharedSpatialAnchorsManager : MonoBehaviour
{
    [SerializeField] private GameObject RHObject, LHObject;
    
    void Update()
    {
        bool trigger1Pressed = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);
        bool trigger2Pressed = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);
    
        if (trigger1Pressed)
        {
            GenerateObject(true);
        }
        if (trigger2Pressed)
        {
            GenerateObject(false);
        }
    }
    
    private void GenerateObject(bool isLeft)
    {
        OVRPose objectPose = new OVRPose()
        {
            position = OVRInput.GetLocalControllerPosition(isLeft ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch),
            orientation = OVRInput.GetLocalControllerRotation(isLeft ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch)
        };
    
        OVRPose worldObjectPose = OVRExtensions.ToWorldSpacePose(objectPose);
    
        GameObject.Instantiate((isLeft ? LHObject : RHObject), worldObjectPose.position, worldObjectPose.orientation);

       
    }

    

}