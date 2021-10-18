using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Car : MonoBehaviour
{
    public float BoostForce;
    public Vector3 CenterOfMass;
    Rigidbody rb;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + CenterOfMass, 0.25f);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.centerOfMass = CenterOfMass;
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

        if(Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(transform.forward * BoostForce);
        }
    }
}
