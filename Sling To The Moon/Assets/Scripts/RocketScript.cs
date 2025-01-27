﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RocketScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject cam;
    public Transform yPivot;
    public GameObject particles;
    public GameObject hitparticles;
    public GameObject Backgorund;

    public GameObject moon;

    private int score;

    public TMP_Text scoreText;

    private bool launched = false;

    float tiltAngle = 60.0f;

    private bool finished = false;

    public TMP_Text finishedText;
    public TMP_Text lostText;

    void Start()
    {
        score = 0;
        particles.SetActive(false);
        hitparticles.SetActive(false);
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        if (Input.GetButtonDown("Jump"))
        {
            sling();
        }

        if (Input.GetButtonDown("Jump") && finished)
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            slingRight();
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            slingLeft();
        }

        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("rHorizontal") * tiltAngle * -1 * Input.GetAxis("Mouse X");
        float tiltAroundX = Input.GetAxis("rVertical") * tiltAngle * -1 * Input.GetAxis("Mouse Y");
        if (launched == true)
        {
            cam.transform.RotateAround(transform.position, Vector3.up, tiltAroundZ * 3f * Time.deltaTime);
            cam.transform.RotateAround(transform.position, Vector3.left, tiltAroundX * 3f * Time.deltaTime);
        }
    }


    private void sling()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        rb.AddForce(cam.transform.forward * 100000);
        transform.parent = null;
        launched = true;
        particles.SetActive(true);
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Border"))
        {
            lostText.gameObject.SetActive(true);
            Backgorund.SetActive(true);
            finished = true;
            launched = false;
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
            cam.transform.LookAt(moon.transform);
            
        }


        if (other.CompareTag("Moon"))
        {
            finishedText.gameObject.SetActive(true);
            Backgorund.SetActive(true);
            finished = true;
            launched = false;
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
            cam.transform.LookAt(moon.transform);
        }

    }


    void OnCollisionEnter(Collision collision)
    {
        score += 50;
        particles.SetActive(false);
        hitparticles.SetActive(true);
    }


    private void slingRight()
    {
        rb.AddForce(cam.transform.right * 100000);
    }


    private void slingLeft()
    {
        rb.AddForce(cam.transform.right * -100000);
    }
}
