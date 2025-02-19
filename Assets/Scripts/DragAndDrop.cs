using System;
using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{ 
   Vector3 mousePosition;
   public Camera cam;

   private Vector3 GetMousePos()
   {
      return cam.WorldToScreenPoint(transform.position);
   }

   private void OnMouseDown()
   {
      mousePosition = Input.mousePosition - GetMousePos();
      Debug.Log("e");
   }

   private void OnMouseDrag()
   {
      transform.position = cam.ScreenToWorldPoint(Input.mousePosition - mousePosition);
   }

   private void OnEnable()
   {
      cam = FindFirstObjectByType<Camera>();
   }
}
