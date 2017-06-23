using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using System;

public class DataController : MonoBehaviour {

    public string filePathName = "ball_path";
    public static int size;
    //public Transform[] points;

    [Serializable]
    public class RootJson
    {
        public double[] x;
        public double[] y;
        public double[] z;
    }


    
    // Use this for initialization
    void Start ()
    {
        TextAsset asset = Resources.Load(Path.Combine("",filePathName)) as TextAsset;
        RootJson json = JsonUtility.FromJson<RootJson>(asset.text);


        size = json.x.Length;
        GameObject[] points = new GameObject[size];
        GameObject tmpObj = new GameObject();

        GameObject wayPointsBall = new GameObject("wayPoints"+transform.name);

        for (int i = 0; i<json.x.Length; i++)
        {

            Vector3 tempPos = new Vector3((float)json.x[i], (float)json.y[i], (float)json.z[i]);

            GameObject go = Instantiate(tmpObj, tempPos, Quaternion.identity) as GameObject;
            go.name = "Point" + i;
            go.tag = "Point"+transform.name;
            points[i] = go;
            points[i].transform.parent = wayPointsBall.transform;
            //print(points[i].transform.position);
            
        }

        GameObject.Destroy(tmpObj);
        
    }


    public static int getSize(Transform[] array)
    {
        return array.Length;
    }

    void Update()
    {

    }

}

