using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        float randRotationSpeed = Random.Range(-rotationSpeed, rotationSpeed);
        gameObject.GetComponent<Rigidbody2D>().AddTorque(randRotationSpeed,ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
