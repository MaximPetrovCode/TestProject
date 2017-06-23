using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class touchObject : MonoBehaviour
{

    public string targetName = followToObj.targetName;
    public moveBall other;

    private void Start()
    {

    }
    
    void Update()
    {
        targetName = followToObj.targetName;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {

                if(hit.collider.name == targetName)
                {
                    //print(hit.collider.name);
                    makeMove tmpFind = GameObject.Find(targetName).GetComponent<makeMove>();
                    if (tmpFind.player == GameObject.Find(targetName))
                    {
                        tmpFind.current = 0;
                        tmpFind.actionState = true;
                    }
                                        
                }                
            }
        }

    }

}