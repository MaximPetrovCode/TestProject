﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class moveBall : MonoBehaviour {

    public Transform[] wayPointBall;
    public GameObject[] pointObj;
    public static int current = 0;
    public float speed = 0.3f;
    public static bool actionState;



	// Use this for initialization
	void Start () {        

	}


    
    // Update is called once per frame
    public void Update()
    {
        pointObj = GameObject.FindGameObjectsWithTag("Point" + transform.name).ToArray();
        wayPointBall = new Transform[pointObj.Length];

        print(pointObj.Length);
        print(wayPointBall.Length);

        for (int i = 0; i < DataController.size; i++)
        {
            wayPointBall[i] = pointObj[i].transform;
            //print(wayPointBall[i].position);
        }

        if (actionState == true)
        {
            stepForward();
        }
    
    }

    /*
    public void changeSpeed(float newspeed)
    {
        
        speed = newspeed;
    }
    */

    public void stepForward()
    {
        if (current == wayPointBall.Length)
        {
            //actionState = false;
            if (actionState == true)
            {
                current = 0;
                for (int k = 0; k < wayPointBall.Length; k++)
                {
                    wayPointBall[k].position = (wayPointBall[k].position);
                }

                actionState = false;
            }

        }
        else
        {
            if (transform.position != wayPointBall[current].position && actionState == true)
            {
                actionState = true;
                transform.Translate((wayPointBall[current].position) - transform.position);
                current = (current + 1);
            }
        }
    }
    
}