using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class moveBall : MonoBehaviour {

    public Transform[] wayPointBall;
    public GameObject[] pointObj;
    public static int current = 0;
    //public float speed = 0.3f;
    public float speed;
    public static bool actionState = false;



	// Use this for initialization
	void Start () {


        wayPointBall = new Transform[DataController.size];

        pointObj = GameObject.FindGameObjectsWithTag("Point").ToArray();
        
        
        for(int i = 0; i<DataController.size; i++)
        {
            wayPointBall[i] = pointObj[i].transform;
            //wayPointBall[i].position += GameObject.Find("").transform.position;
            //print(wayPointBall[i].position);
        }
        

	}


    
    // Update is called once per frame
    public void Update()
    {
        
            
        if(actionState == true)
        {
            stepForward();
        }
    
    }


    public void changeSpeed(float newspeed)
    {
        
        speed = newspeed;
    }

    public void stepForward()
    {
        //print(actionState);

        if (current == wayPointBall.Length)
        {
            //actionState = false;
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
                print(speed);
                //Vector3 dir = Vector3.MoveTowards(transform.position, wayPointBall[current].position, speed * Time.deltaTime);
                transform.Translate((wayPointBall[current].position) - transform.position);
                current = (current + 1);



            }
            /*
            else if (actionState == false)
            {
                //current = (current + 1) % wayPointBall.Length; //for circle
                //current = (current + 1);
                actionState = false;
            }
            */
        }
    }
    
}