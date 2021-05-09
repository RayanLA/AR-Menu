using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Vuforia;

public class SelectionScript : MonoBehaviour
{
    public MenuListScript menuListScript;

    private List<Vector3> _positions = new List<Vector3>();
    private int windowBegin = 0;
    private float windowLeft = 0.0f;
    private float windowRight = 0.0f;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 pos = transform.GetChild(i).transform.position;
            _positions.Add(new Vector3(pos.x, pos.y, pos.z));
            menuListScript.instanceList[i].gameObject.transform.position = pos;
            menuListScript.instanceList[i].gameObject.SetActive(true);
            Debug.Log("i = " + i + " posx = " + pos.x);
            if (i == 0)
            {
                windowRight = pos.x; 
            }
            if (i == 3)
            {
                windowLeft = pos.x; 
            }
            
        }

        for (int i = 4; i < menuListScript.instanceList.Count; i++)
        {
            menuListScript.instanceList[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SetPositions()
    {
        print(windowBegin);
        for (int i = 0; i < menuListScript.instanceList.Count; i++)
        {
            float posX = menuListScript.instanceList[i].gameObject.transform.position[0];
            if (posX<=windowLeft && posX>=windowRight-7)
            {//element se trouve dans la fenêtre 
                menuListScript.instanceList[i].gameObject.SetActive(true);
            }
            else
            {//element ne se trouve pas dans la fenêtre et ne doit pas être affiché
                Debug.Log(posX + ";    " + windowLeft + ";     " + windowRight);
                menuListScript.instanceList[i].gameObject.SetActive(false);
            }
        }
    }

    

    public void MoveLeft()
    {
        Vector3 currentPos = new Vector3();
        Vector3 previousPos = menuListScript.instanceList[menuListScript.instanceList.Count-1].gameObject.transform.position;
        for (int i = 0; i < menuListScript.instanceList.Count; i++)
        {
            currentPos = menuListScript.instanceList[i].gameObject.transform.position;
            menuListScript.instanceList[i].gameObject.transform.position = previousPos;
            previousPos = currentPos;
        }
        SetPositions();
        Debug.Log("moveLeft");
    }
    
    public void MoveRight()
    {
        var last = menuListScript.instanceList[menuListScript.instanceList.Count];
        menuListScript.instanceList.RemoveAt(menuListScript.instanceList.Count);
        menuListScript.instanceList.Insert(0, last);
        SetPositions();
        Debug.Log("moveRight");
    }

}
