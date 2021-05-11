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
    public MainDisplayScript mainDisplay;
    public List<DishScript> plats;
    public List<DishScript> desserts;
    
    private List<DishScript> _dishList;
    private List<VirtualButtonBehaviour> _buttonBehaviours;
    private int _currentIndex = 0;
    public enum Lists
    {
        Plats, Desserts
    }

    private Lists _currentList = Lists.Plats;

    private readonly List<DishScript> _platsInstances = new List<DishScript>();
    private readonly List<DishScript> _dessertsInstances = new List<DishScript>();
    //private List<DishScript> instanceDishs;

    
    public void Awake()
    {
        _dishList = plats;
        foreach (var dish in plats)
        {
            DishScript dishInstance = Instantiate(dish, transform.root, true);
            _platsInstances.Add(dishInstance);
        }
        foreach (var dish in desserts)
        {
            DishScript dishInstance = Instantiate(dish, transform.root, true);
            _dessertsInstances.Add(dishInstance);
        }
        for (int i =0; i < 4; i++)
        {
            var buttonBehaviour = virtualButtons[i].GetComponent<VirtualButtonBehaviour>();
            var buttonIndex = i;
            buttonBehaviour.RegisterOnButtonPressed(behaviour =>
            {
                Debug.Log(behaviour.VirtualButtonName);
                mainDisplay.DisplayObject(_dishList[mod(buttonIndex + _currentIndex, _dishList.Count)]);
            });
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
        for (int i = 0; i < _dishList.Count; i++)
        {
            if (_currentList == Lists.Plats)
            {
                int index = mod(i + _currentIndex, _platsInstances.Count);
                if (i < planes.Count)
                {
                    _platsInstances[index].transform.position = planes[i].transform.position;
                    _platsInstances[index].gameObject.SetActive(true);
                }
                else
                {
                    _platsInstances[index].gameObject.SetActive(false);
                }
            }
            else
            {
                int index = mod(i + _currentIndex, _dessertsInstances.Count);
                if (i < planes.Count)
                {
                    _dessertsInstances[index].transform.position = planes[i].transform.position;
                    _dessertsInstances[index].gameObject.SetActive(true);
                }
                else
                {
                    _dessertsInstances[index].gameObject.SetActive(false);
                }
            }
        }
        
        foreach (var instance in _currentList == Lists.Plats ? _dessertsInstances : _platsInstances)
        {
            instance.gameObject.SetActive(false);
        }
    }

    public Lists SwitchList()
    {
        _currentList = _currentList == Lists.Plats ? Lists.Desserts : Lists.Plats;
        _dishList = _currentList == Lists.Plats ? plats : desserts;
        UpdateView();
        mainDisplay.Hide();
        return _currentList;
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
