using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementGameobject : MonoBehaviour {

    public Transform[] wayPointBall;
    public GameObject[] pointObj;
    public static int current = 0;
    public float speed = 0.3f;
    public static bool actionState = false;


    // Use this for initialization
    void Start () {

        wayPointBall = new Transform[DataController.size];
        //pointObj = GameObject.FindGameObjectsWithTag("Point").ToArray();
        for (int i = 0; i < DataController.size; i++)
        {
            wayPointBall[i] = pointObj[i].transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (actionState == true)
        {
            stepForward();
        }
    }



    public void stepForward()
    {
        if (current == wayPointBall.Length)
        {
            if (actionState == true)
            {
                current = 0;
                for (int k = 0; k < wayPointBall.Length; k++)
                {
                    wayPointBall[k].position = (wayPointBall[k].position + transform.position);
                }

                actionState = false;
            }

        }
        else
        {
            if (transform.position != wayPointBall[current].position && actionState == true)
            {
                actionState = true;
                //print(wayPointBall[current]);
                //Vector3 dir = Vector3.MoveTowards(transform.position, wayPointBall[current].position, speed * Time.deltaTime);
                transform.Translate((wayPointBall[current].position) - transform.position);
                current = (current + 1);
            }
        }
    }

}
