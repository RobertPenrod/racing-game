using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Car : MonoBehaviour
{
    public Vector3 centerOfMass;
    Rigidbody rb;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + centerOfMass, 0.25f);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.centerOfMass = centerOfMass;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.position = Vector3.zero + Vector3.up * 1f;
            transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
