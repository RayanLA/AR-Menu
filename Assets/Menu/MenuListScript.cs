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
    public readonly List<DishScript> instanceList = new List<DishScript>();
    private bool _moving;

    private const float Speed = 4f;
    private float _currentSpeed = Speed;
    private int currentIndex = 0;

    private readonly HashSet<DishScript> _displayedDishes = new HashSet<DishScript>();
    // Start is called before the first frame update
    public void Awake()
    {
        this.InitInstances();
        //this._moving = false;
        //UpdatePosition();
    }

    // Update is called once per frame
    public void Update()
    {
        //if (!_moving) return;
        //UpdatePosition();
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

    private void InitInstances()
    {
        foreach (var currentDish in dishList)
        {
            DishScript instance = Instantiate(currentDish, gameObject.transform.localPosition, Quaternion.identity);
            instanceList.Add(instance);
            instance.transform.parent = transform.root;
        }
    }

    /*private void UpdatePosition()
    {
        foreach (var currentDish in instanceList)
        {
            currentDish.gameObject.transform.position += new Vector3(_currentSpeed * Time.deltaTime, 0, 0);
            if (currentDish.gameObject.transform.position.x < transform.position.x - 10 || currentDish.gameObject.transform.position.x > transform.position.x + 25)
            {
                currentDish.gameObject.SetActive(false);
                _displayedDishes.Remove(currentDish);
            }
            else
            {
                currentDish.gameObject.SetActive(true);
                _displayedDishes.Add(currentDish);
            }
        }
    }*/

    private void DisplayDish()
    {
        var position = this.gameObject.transform.localPosition;
        position.x += dishSize / 2;
        position.z += dishSize / 2;
        for (int i = 0; i < instanceList.Count; i++)
        {
            if (this.currentIndex <= i && i < this.currentIndex + this.displayCount)
            {
                var curInstance = this.instanceList[i];
                curInstance.gameObject.SetActive(true);
                curInstance.transform.position = position;
                position.x += (dishSize + gap);
            }
            else
            {
                instanceList[i].gameObject.SetActive(false);
            }
        }
    }

    public void MoveLeft()
    {
        /*_moving = true;
        _currentSpeed = Speed;*/
        if (this.currentIndex > 0)
        {
            this.currentIndex--;
        }
    }
    
    public void MoveRight()
    {
        // _moving = true;
        // _currentSpeed = -Speed;
        if (currentIndex < dishList.Count - displayCount)
        {
            this.currentIndex++;
        }
    }

    public void StopMoving()
    {
        _moving = false;
    }

    public bool Moving
    {
        get => _moving;
        set => _moving = value;
    }
}
