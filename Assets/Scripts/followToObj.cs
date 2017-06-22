using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followToObj : MonoBehaviour {

    public string targetName = "Ball";
    

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        GameObject target = GameObject.Find(targetName);
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z - 10);
    }
}
