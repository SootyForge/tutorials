using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // Target look object
    public bool hideCursor = false; // Is the cursor hidden?
    [Header("Settings")]
    public Vector3 offset;
    public Vector2 speed = new Vector2(120f, 120f); // X and Y speed of orbit
    public float minYLimit = 20f; // Limit in ° of rotation of y
    public float maxYLimit = 80f;
    public float minDistance = .5f;
    public float maxDistance = 15;
    [Header("Collision")]
    public bool collision = false; // Is collision enabled?
    public float castRadius = .4f; // Radius of SphereCast
    public float rayDistance = 1000f; // Distance the ray travels
    public LayerMask ignoreLayers; // Layers to ignore from collision

    private Vector3 originalOffset; // Record the original offset on Start
    private float distance; // Current distance of camera
    private Vector3 euler; // Current x and y rotation of camera

    // Use this for initialization
    void Start()
    {
        // Does the cursor need hiding?
        if(hideCursor)
        {
            // Hide the cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            // Unhide the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Calculate distance from target at the Start
        originalOffset = transform.position - target.position;
        rayDistance = originalOffset.magnitude; // Use distance for ray

        // Get eulerAngles of camera and store them
        euler = transform.eulerAngles;

        distance = originalOffset.magnitude;

    }

    // Update is called once per frame
    void Update()
    {
        // If right mouse button
        if(Input.GetMouseButton(1))
        {
            // Get Mouse X and Mouse Y
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            // Call Look()
            Look(mouseX, mouseY);
        }
    }

    void LateUpdate()
    {
        // Is target valid (not null) ?
        if(target)
        {
            //Vector3 worldOffset = transform.TransformDirection(offset);
            transform.position = target.position - transform.forward * distance;
        }
    }

    // Rotate the camera based on "Mouse X" and "Mouse Y"
    public void Look(float mouseX, float mouseY)
    {
        // Is target valid (not null) ?
        if(target)
        {
            // Modify pitch
            euler.x += mouseX * speed.x * Time.deltaTime;
            // Modify yaw
            euler.y -= mouseY * speed.y * Time.deltaTime;
            // Apply rotation
            transform.rotation = Quaternion.Euler(euler.y, euler.x, 0);
        }
    }
}
