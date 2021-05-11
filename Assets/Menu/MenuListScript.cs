using System.Collections;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class MenuListScript : MonoBehaviour
{
    public List<DishScript> dishList;
    public int displayCount = 4; // fenetre des plats affichés
    public float gap = 0.5f; // ecart entre les prefabs de plat affichés
    public float dishSize = 10; // largeur du prefab d'un plat
    
    private readonly List<DishScript> _instanceList = new List<DishScript>();
    private int _currentIndex = 0;
    
    public void Awake()
    {
        for (int i = 0; i < dishList.Count; i++)
        {
            DishScript instance = Instantiate(dishList[i]);//, gameObject.transform.localPosition, Quaternion.identity);
            _instanceList.Add(instance);
            instance.transform.parent = transform.root;
            instance.name = "Dish "+i;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.MoveLeft();
        }
        this.DisplayDish();
    }

    private void DisplayDish()
    {
        var position = this.gameObject.transform.localPosition;
        position.x += dishSize / 2;
        position.z += dishSize / 2;
        for (int i = 0; i < _instanceList.Count; i++)
        {
            if (this._currentIndex <= i && i < this._currentIndex + this.displayCount)
            {
                var curInstance = this._instanceList[i];
                curInstance.gameObject.SetActive(true);
                curInstance.transform.position = position;
                position.x += (dishSize + gap);
            }
            else
            {
                _instanceList[i].gameObject.SetActive(false);
            }
        }
    }

    public void MoveLeft()
    {
        if (this._currentIndex > 0)
        {
            this._currentIndex--;
        }
    }
    
    public void MoveRight()
    {
        if (_currentIndex < dishList.Count - displayCount)
        {
            this._currentIndex++;
        }
    }

    
    public DishScript Select(int index)
    {
        //index entre 0 et 3
        return this.dishList[_currentIndex + index];
    }

}
