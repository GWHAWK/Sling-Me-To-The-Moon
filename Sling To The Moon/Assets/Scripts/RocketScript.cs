using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject cam;

    public GameObject moon;

    private bool launched = false;

    float tiltAngle = 60.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            sling();
        }

        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("rHorizontal") * tiltAngle * -1;
        float tiltAroundX = Input.GetAxis("rVertical") * tiltAngle * -1;
        if (launched == true)
        {
            cam.transform.RotateAround(transform.position, Vector3.up, tiltAroundZ * 10 * Time.deltaTime);
            cam.transform.RotateAround(transform.position, Vector3.left, tiltAroundX * 10 * Time.deltaTime);
        }
    }


    private void sling()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        rb.AddForce(transform.forward * 100000);
        transform.parent = null;
        launched = true;
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Border"))
        {
            Debug.Log("asdkflj");
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
            cam.transform.LookAt(moon.transform);
        }


    }
}
