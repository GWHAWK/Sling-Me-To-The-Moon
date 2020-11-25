using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingScript : MonoBehaviour
{

    public GameObject rocket;
    public Camera cam;


    public Transform xPivot;
    public Transform yPivot;

    public float maxRotation = 90f;
    public float minRotation = 348f;

    float smooth = 5.0f;
    float tiltAngle = 60.0f;


    public float rotationSpeed = 60f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);


    }
}
