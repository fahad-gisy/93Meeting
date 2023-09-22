using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private Transform TrianglePointer;

    public static Vector3 direction;

    // Update is called once per frame
    private void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;


        // Convert the mouse position from screen to world coordinates
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10.0f)); // 10.0f is the distance from the camera


        // Calculate the direction from the sprite to the mouse position
        direction = worldMousePosition - transform.position;

        // Calculate the angle between the direction and the sprite's forward vector
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        Debug.Log($"MousePosition: {mousePosition} | WorldMousePosition: {worldMousePosition} | Angle: {angle}");

        // Rotate the sprite around its Z-axis
        transform.rotation = Quaternion.Euler(0, 0, angle);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
        
        // Add offset to the pointer
        TrianglePointer.transform.position = Vector3.zero + direction.normalized;
    }
}
