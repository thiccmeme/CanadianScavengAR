using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.Touch;

public class DragObject : MonoBehaviour
{
    private Transform pickedObject = null;
    private Vector3 lastPlanePoint;
    public Camera cam;

    private void OnEnable()
    {
        TouchSimulation.Enable();
    }
    
    

    // Update is called once per frame
    void Update()
    {
        Plane targetPlane = new Plane(transform.up, transform.position);

        foreach (Touch touch in Input.touches)
        {
            // Gets the ray at position where the screen is touched
            Ray ray = cam.ScreenPointToRay(touch.position);
            
            Debug.Log("touch");

            // Gets the position of ray along plane
            float dist = 0.0f;

            // Intersects ray with the plane. Sets dist to distance along the ray where intersects
            targetPlane.Raycast(ray, out dist);

            // Returns point dist along the ray.
            Vector3 planePoint = ray.GetPoint(dist);

            // True if finger touch began. If ray intersects collider, set pickedObject to transform of collider object
            if (touch.phase == TouchPhase.Began)
            {
                // Struct used to get info back from a raycast
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit, 1000))
                { // True when Ray intersects collider. If true, hit contains additional info about where collider was hit
                        pickedObject = hit.transform;
                    lastPlanePoint = planePoint;
                }
                else
                {
                    pickedObject = null;
                }
                // Move Object when finger moves after object selected.
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (pickedObject != null)
                {
                    pickedObject.position += planePoint - lastPlanePoint;
                    lastPlanePoint = planePoint;
                }
                // Set pickedObject to null after touch ends.
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                pickedObject = null;
            }
        }
    }
} 