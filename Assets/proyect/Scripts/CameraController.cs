using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Vector3 mouseOriginPoint;
    Vector3 offset;
    bool dragging;


    private void LateUpdate()
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * (Camera.main.orthographicSize*.1f),2.5f,50f);//change size of ortografic camera to do a zooming with the scroll

        if (Input.GetMouseButton(2))//button 2 is the scroll 
        {
            offset = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position); //it take the mouse position and less it to the camera position
            if (!dragging)
            {
                dragging = true;
                mouseOriginPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //here we get the origin point of the mouse 
            }
        }
        else
        {
            dragging = false;
            
        }
        if (dragging)
            Camera.main.transform.position = mouseOriginPoint - offset;
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
