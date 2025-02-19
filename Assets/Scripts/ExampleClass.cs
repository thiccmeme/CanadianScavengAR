using UnityEngine;
using System.Collections;

// Input.GetTouch example.

public class ExampleClass : MonoBehaviour
{
    private Vector3 initialPosition;
    private float width;
    private float height;
    private bool isTouching = false;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        // Position used for the cube.
        initialPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 deltaPosition = touch.deltaPosition;
                deltaPosition.x = deltaPosition.x / width;
                deltaPosition.y = deltaPosition.y / height;
                Vector3 positionChange = new Vector3(-deltaPosition.x,0.0f ,deltaPosition.y);

                // Update the cube's position relative to its current position.
                transform.localPosition += positionChange;
            }
        }
    }
}