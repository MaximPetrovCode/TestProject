using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour {

    public Transform target;
    public bool orbitY;

    void Update()
    {
        target = GameObject.Find(followToObj.targetName).transform;

        if (target)
        {
            transform.LookAt(target);
            if (orbitY)
            {
                transform.RotateAround(target.position, Vector3.up, Time.deltaTime * 30);
            }
        }
        
    }
}
