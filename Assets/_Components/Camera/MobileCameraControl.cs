using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCameraControl : MonoBehaviour
{
    private Vector3 touchStart;

    private new Camera camera;
    [SerializeField]
    private float boundary;

     [SerializeField]
    private float zoomOutMax;
     [SerializeField]
    private float zoomOutMin
    ;[SerializeField]
   // private float zoomSpeed;
    void Start()
    {
        camera=GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart=camera.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount==2)
        {
            Touch touchZero=Input.GetTouch(0);
            Touch touchOne=Input.GetTouch(1);
            Vector2 touchZeroPrevPos=touchZero.position-touchZero.deltaPosition;
            Vector2 touchOnePrevPos=touchOne.position-touchOne.deltaPosition;
            float prevMagnitude=(touchZeroPrevPos-touchOnePrevPos).magnitude;
            float currentMagnitude=(touchZero.position-touchOne.position).magnitude;

            float difference=currentMagnitude-prevMagnitude;
            Zoom(difference*0.01f);

        }
        if (Input.GetMouseButton(0))
        {
            Vector3 position=transform.position;
            Vector3 direction=touchStart-camera.ScreenToWorldPoint(Input.mousePosition);
            position+=direction;
             position.x = Mathf.Clamp(position.x, -boundary, boundary);
             position.y = Mathf.Clamp(position.y, -boundary, boundary);
             transform.position=position;
        }
        Zoom(Input.GetAxis("Mouse ScrollWheel")*2);

    }
    void Zoom(float increment){
        camera.orthographicSize=Mathf.Clamp(camera.orthographicSize-increment,zoomOutMin,zoomOutMax);
    }

}
