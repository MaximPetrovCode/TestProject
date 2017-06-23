using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class followToObj : MonoBehaviour {

    public static string targetName = "Ball";

    public static string[] targets;
    public static int curentTarget = 0;
    public bool rotate = false;
    public float speedRotation;

    public float orbitDistance = 10.0f;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] targetsObjs = GameObject.FindGameObjectsWithTag("Ball").ToArray();
        string[] targets = new string[targetsObjs.Length];

        for (int i = 0; i < targetsObjs.Length; i++)
        {
            targets[i] = (string)targetsObjs[i].name;
            //print(targets[i]);
        }
        
        if(curentTarget < 0)
        {
            curentTarget = targets.Length - 1;
        }

        if(curentTarget == targets.Length)
        {
            curentTarget = 0;
        }

        targetName = targets[curentTarget];
       
    }

    public void rightButtonClick()
    {
        curentTarget++;
    }

    public void leftButtonClick()
    {
        curentTarget--;
    }

    private void LateUpdate()
    {
        Orbit();
    }


    void Orbit()
    {
        GameObject target = GameObject.Find(targetName);

        if (target.transform)
        {
            transform.position = target.transform.position + (transform.position - target.transform.position).normalized * orbitDistance;

            transform.LookAt(target.transform);
            if (rotate)
            {
                float mouseInputX = Input.GetAxis("Mouse X");
                float mouseInputY = Input.GetAxis("Mouse Y");
                Vector3 lookhere = new Vector3(-mouseInputY, mouseInputX, 0);



                transform.RotateAround(target.transform.position, lookhere, Time.deltaTime * speedRotation);

            }
        }
    }
}
