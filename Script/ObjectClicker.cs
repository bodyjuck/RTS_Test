using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectClicker : MonoBehaviour
{
    public GameObject seleceTarget;
    public GameSetControll gamesetcontroll;

    public Ray ray;
    public RaycastHit hit;

    public int whatSelece = 1;

    void Start()
    {
        
        seleceTarget = GameObject.Find("Selece Target");
        gamesetcontroll = GetComponent<GameSetControll>();

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                
                if (hit.transform != null)
                {
                    if (hit.transform.name == "Enemy POS 1")
                    {
                        whatSelece = 0;
                        seleceTarget.transform.position = gamesetcontroll.posEnemy.Pos[0].transform.position;
                        
                    }
                    else if (hit.transform.name == "Enemy POS 2")
                    {
                        whatSelece = 1;
                        seleceTarget.transform.position = gamesetcontroll.posEnemy.Pos[1].transform.position;
                        
                    }
                    else if (hit.transform.name == "Enemy POS 3")
                    {
                        whatSelece = 2;
                        seleceTarget.transform.position = gamesetcontroll.posEnemy.Pos[2].transform.position;
                        
                    }

                    
                }
            }
        } 
    }

    public void rePOS()
    {
        seleceTarget.transform.position = gamesetcontroll.posEnemy.Pos[0].transform.position;
    }

    
}
