using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class touchObject : MonoBehaviour
{

    public string targetName;
    public moveBall other;

    private void Start()
    {

    }
    
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {

                if(hit.collider.name == targetName && moveBall.actionState==false)
                {
                    moveBall.current = 0;
                    moveBall.actionState = true;
                }                
            }
        }

    }

}