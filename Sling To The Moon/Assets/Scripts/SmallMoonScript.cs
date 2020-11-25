using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMoonScript : MonoBehaviour
{

    public GameObject BigMoon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(BigMoon.transform.position, Vector3.left, 30 * Time.deltaTime);
    }
}
