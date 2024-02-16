using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI  testText, testText2; 
    private LineRenderer lineRenderer;
    private int currentIndex = 0;
    private bool isDrawing = false;

    // Start is called before the first frame update
    void Start()
    {
        testText.text = "Nothing to say yet";
        
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
    }
    
    //Get the position and rotation of the controller
    private void DrawLine()
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
        
        
        
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            isDrawing = true;
            testText.text = "button pressed, isDrawing is:  " + isDrawing.ToString();
        }

        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            isDrawing = false;
            testText.text = "button lifted, isDrawing is:  " + isDrawing.ToString();
        }

        if (isDrawing)
        {
            Vector3 newPosition = worldObjectPose.position; // Use controller position for drawing
            lineRenderer.positionCount = currentIndex + 1;
            lineRenderer.SetPosition(currentIndex, newPosition);
            currentIndex++;
        }
    }

  
}
