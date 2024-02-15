using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI  testText, testText2; 
    
    // Start is called before the first frame update
    void Start()
    {
        testText.text = "Nothing to say yet";
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            //Draw a line
            testText.text = "button down";
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            testText.text = "button up";
            
        }

        GetContollerPosition();
    }
    
    //Get the position and rotation of the controller
    private void GetContollerPosition()
    {
        OVRPose objectPose = new OVRPose()
        
        {
            position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RHand),
            orientation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RHand)
        };

        //Convert the and rotation to world space
        OVRPose worldObjectPose = OVRExtensions.ToWorldSpacePose(objectPose);

        //GameObject.Instantiate((some object to instantiate), worldObjectPose.position, worldObjectPose.orientation);
        testText2.text = worldObjectPose.position.ToString() + worldObjectPose.orientation.ToString();
    }
}
