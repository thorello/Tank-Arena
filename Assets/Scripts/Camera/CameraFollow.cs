using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float pLerp = .02f;
    public float rLerp = .01f;

    public Transform target;

    //public float smoothSpeed = 0.1f;





    public void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, target.position, pLerp);
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, rLerp);
    }
}

