using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private int currentIndex = 0;
    private bool isDrawing = false;

    public bool trigger1Pressed;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        
        trigger1Pressed  = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);
    }

    void Update()
    {
        // Check for controller input to start and end drawing
        if (trigger1Pressed == true) 
        {
            StartDrawing();
        }
        else if (trigger1Pressed == false) 
        {
            EndDrawing();
        }

        // If drawing, update line renderer with current controller position
        if (isDrawing)
        {
            Vector3 newPosition = transform.position;
            lineRenderer.positionCount = currentIndex + 1;
            lineRenderer.SetPosition(currentIndex, newPosition);
            currentIndex++;
        }
    }

    void StartDrawing()
    {
        // Start drawing by enabling line renderer and resetting current index
        isDrawing = true;
        lineRenderer.enabled = true;
        currentIndex = 0;
    }

    void EndDrawing()
    {
        // End drawing by disabling line renderer
        isDrawing = false;
        lineRenderer.enabled = false;
    }
}
