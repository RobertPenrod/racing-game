using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float Torque;
    public float MaxTurnAngle = 90f;
    public bool IsPowered = false;
    public bool turns = false;

    float turnAngle = 0f;
    WheelCollider wheelCollider;
    [SerializeField] Transform wheelMesh;

    private void Awake()
    {
        wheelCollider = GetComponentInChildren<WheelCollider>();
    }

    public void Accelerate(float accelInput)
    {
        if (IsPowered)
            wheelCollider.motorTorque = accelInput * Torque;
        else
            wheelCollider.brakeTorque = 0;
    }

    public void Steer(float steerInput)
    {
        wheelCollider.steerAngle = steerInput * MaxTurnAngle;
    }

    void UpdateMesh()
    {
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheelMesh.position = pos;
        wheelMesh.rotation = rot;
    }

    private void Update()
    {
        float accelInput = Input.GetAxisRaw("Vertical");
        float steerInput = Input.GetAxisRaw("Horizontal");
        Accelerate(accelInput);
        if(turns)
            Steer(steerInput);
        UpdateMesh();
    }
}
