using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotationSpeed = 20;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, Time.deltaTime * rotationSpeed, 0);
    }
}
