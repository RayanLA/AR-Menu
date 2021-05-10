using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Vuforia;

public class SelectionScript : MonoBehaviour
{
    public List<GameObject> virtualButtons;
    public List<GameObject> planes;
    public List<DishScript> dishList;
    
    private List<VirtualButtonBehaviour> ListButtonBehaviour;
    //private List<DishScript> instanceDishs;

    
    public void Awake()
    {
        foreach (var dish in dishList)
        {
            Instantiate(dish).gameObject.transform.parent = transform.root;
        }

        updateView();
    }

    public void Start()
    {
        
    }

    public void Update()
    {
    }

    public void updateView()
    {
        for (int i = 0; i < dishList.Count; i++)
        {
            Debug.Log(dishList[i].gameObject.name);
            if (i < virtualButtons.Count)
            {
                dishList[i].gameObject.transform.position = planes[i].transform.position;
            }
        }
    }
    

}
