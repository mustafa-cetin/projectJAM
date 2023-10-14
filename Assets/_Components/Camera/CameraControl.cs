using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed = 5.0f; // Adjust this to change the camera movement speed
    public float boundary = 5.0f; // Adjust this to set the boundary limit for the camera
    public float smoothTime = 0.3f; // Adjust this to change the smoothness of the camera movement
    public float zoomSpeed = 2.0f; // Adjust this to change the zoom speed
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 targetPosition = transform.position;

        // Moving up and down
        if (Mathf.Abs(verticalInput) > 0)
        {
            targetPosition += transform.up * verticalInput * speed * Time.deltaTime;
        }

        // Moving left and right
        if (Mathf.Abs(horizontalInput) > 0)
        {
            targetPosition += transform.right * horizontalInput * speed * Time.deltaTime;
        }

        // Clamping the camera within the boundary
        targetPosition.x = Mathf.Clamp(targetPosition.x, -boundary, boundary);
        targetPosition.y = Mathf.Clamp(targetPosition.y, -boundary, boundary);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    
        
        // Zooming in and out with the mouse scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scroll * zoomSpeed, 5f, 15f);
        }
    }


}
