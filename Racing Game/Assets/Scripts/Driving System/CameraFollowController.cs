using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public Transform ObjectToFollow;
    public Vector3 PosOffset;
    public Vector3 LookOffset;
    public float FollowSpeed;
    public float LookSpeed;

    public void LookAtTarget()
    {
        Vector3 lookPos = ObjectToFollow.transform.position +
                          ObjectToFollow.transform.forward * LookOffset.z +
                          ObjectToFollow.transform.right * LookOffset.x +
                          ObjectToFollow.transform.up * LookOffset.y;
        Vector3 lookDirection = lookPos - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, LookSpeed * Time.deltaTime);
    }

    public void MoveToTarget()
    {
        Vector3 targetPos = ObjectToFollow.transform.position +
                            ObjectToFollow.transform.forward * PosOffset.z +
                            ObjectToFollow.transform.right * PosOffset.x +
                            ObjectToFollow.transform.up * PosOffset.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, FollowSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }
}
