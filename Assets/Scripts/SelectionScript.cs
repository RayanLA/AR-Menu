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
    private int _currentIndex = 0;

    private readonly List<DishScript> _dishInstances = new List<DishScript>();
    //private List<DishScript> instanceDishs;

    
    public void Awake()
    {
        foreach (var dish in dishList)
        {
            DishScript dishInstance = Instantiate(dish, transform.root, true);
            _dishInstances.Add(dishInstance);
        }

        UpdateView();
    }

    public void Start()
    {
        
    }

    public void Update()
    {
    }

    public void UpdateView()
    {
        for (int i = 0; i < dishList.Count; i++)
        {
            int index = mod(i + _currentIndex, _dishInstances.Count);
            Debug.Log(_dishInstances[index].gameObject.name);
            if (i < planes.Count)
            {
                _dishInstances[index].transform.position = planes[i].transform.position;
                _dishInstances[index].gameObject.SetActive(true);
            }
            else
            {
                _dishInstances[index].gameObject.SetActive(false);
            }
        }
    }

    public void MoveLeft()
    {
        _currentIndex--;
        UpdateView();
    }
    
    public void MoveRight()
    {
        _currentIndex++;
        UpdateView();
    }
    
    int mod(int n, int x)
    {
        return ((n%x)+x)%x;
    }
    
}
