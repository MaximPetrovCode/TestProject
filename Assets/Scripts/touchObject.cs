using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class touchObject : MonoBehaviour
{

    public string targetName = followToObj.targetName;
    public moveBall other;

    private float doubleClickTime = 1.0f;
    private float lastClickTime = -10f;

    private void Start()
    {

    }
    
    void Update()
    {

        targetName = followToObj.targetName;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Input.GetMouseButtonDown(0))
        {
            float timeDelta = Time.time - lastClickTime;

            if (timeDelta < doubleClickTime)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.name == targetName)
                    {

                        makeMove tmpFind = GameObject.Find(targetName).GetComponent<makeMove>();
                        if (tmpFind.player == GameObject.Find(targetName))
                        {
                            tmpFind.player.transform.position = tmpFind.startPosition;
                            tmpFind.current = 0;
                            tmpFind.actionState = false;
                        }
                    }
                }

                Debug.Log("double click" + timeDelta);
                lastClickTime = 0;
            }
            else
            {
                lastClickTime = Time.time;
            }
            

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.name == targetName)
                {
                        //print(hit.collider.name);
                        makeMove tmpFind = GameObject.Find(targetName).GetComponent<makeMove>();
                        if (tmpFind.player == GameObject.Find(targetName) && tmpFind.actionState == false)
                        {
                            tmpFind.current = 0;
                            tmpFind.actionState = true;
                        }
                }                
            }
        }

    }

}