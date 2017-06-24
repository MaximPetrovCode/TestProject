using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class makeMove : MonoBehaviour {

    public Transform[] wayPointBall;
    public GameObject[] pointObj;
    public int current = 0;
    public float speed;
    public bool actionState;
    public GameObject player;
    public Vector3 startPosition;

    // Use this for initialization
    void Start () {
		player = (GameObject)this.gameObject;

        startPosition = player.transform.position;
        print(startPosition);

        
    }
	
	// Update is called once per frame
	void Update () {


        pointObj = GameObject.FindGameObjectsWithTag("Point" + transform.name).ToArray();
        wayPointBall = new Transform[pointObj.Length];

        //print(pointObj.Length);
        //print(wayPointBall.Length);

        for (int i = 0; i < wayPointBall.Length; i++)
        {
            wayPointBall[i] = pointObj[i].transform;
        }

        

        if (actionState == true)
        {
            stepForward();
        }
    }


    public void stepForward()
    {
        
        
            Vector3 distance = wayPointBall[wayPointBall.Length - 1].position - wayPointBall[0].position;

                

            if (current == wayPointBall.Length)
            {
                //actionState = false;
                if (actionState == true)
                {
                    current = 0;
                    for (int k = 0; k < wayPointBall.Length; k++)
                    {
                        wayPointBall[k].position = (wayPointBall[k].position + distance);
                    }
                    
                    actionState = false;
                }

            }
            else
            {
            if (player.transform.position != wayPointBall[current].position && actionState == true)
                {
                    actionState = true;
                    player.transform.Translate((wayPointBall[current].position) - player.transform.position);
                    //player.transform.position += ((wayPointBall[current].position) - player.transform.position)*12*Time.deltaTime;
                    //player.transform.position = Vector3.MoveTowards(player.transform.position, wayPointBall[current].position, speed * Time.deltaTime);
                    current = (current + 1);
                }
            }
        
        //print(distance);
       
    }

    
    public void changeSpeed(float newspeed)
    {
        speed = newspeed;
    }
    


}
