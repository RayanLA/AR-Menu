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
        for (int i = 0; i < menuListScript.instanceList.Count; i++)
        {
            if (i < 4)
            { 
                menuListScript.instanceList[i].gameObject.transform.position = Vector3.MoveTowards(menuListScript.instanceList[i].gameObject.transform.position, _positions[i], Time.deltaTime);
                menuListScript.instanceList[i].gameObject.SetActive(false);
            }
            else
            {
                menuListScript.instanceList[i].gameObject.SetActive(false);
            }
        }
        menuListScript.instanceList[j].gameObject.SetActive(true);
    }
    

    public int j = 0;
    public void MoveLeft()
    {
        /*var first = menuListScript.instanceList[0];
        menuListScript.instanceList.RemoveAt(0);
        menuListScript.instanceList.Add(first);*/
        j = (1+j)%4;
        Debug.Log(j);
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
