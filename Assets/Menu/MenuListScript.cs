using System.Collections;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MenuListScript : MonoBehaviour
{
    public List<DishScript> dishList;
    public readonly List<DishScript> instanceList = new List<DishScript>();
    private bool _moving;

    private const float Speed = 4f;
    private float _currentSpeed = Speed;

    private readonly HashSet<DishScript> _displayedDishes = new HashSet<DishScript>();
    // Start is called before the first frame update
    public void Awake()
    {
        this.SetPositions();
        //this._moving = false;
        //UpdatePosition();
    }

    // Update is called once per frame
    public void Update()
    {
        //if (!_moving) return;
        //UpdatePosition();
    }

    private void SetPositions()
    {
        const float size = 10;
        const float gap = 0.5f;
        var nextPosition = gameObject.transform.localPosition;
        // nextPosition.x -= size / 2;
        nextPosition.z += size / 2;

        foreach (var currentDish in dishList)
        {
            // currentDish.transform.position = new Vector3(nextPosition, 0, 0);
            DishScript instance = Instantiate(currentDish, nextPosition, Quaternion.identity);
            instanceList.Add(instance);
            //nextPosition.x += (size + gap);
            instance.transform.parent = transform.root;
        }
    }

    private void UpdatePosition()
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
    }

    public void MoveLeft()
    {
        _moving = true;
        _currentSpeed = Speed;
    }
    
    public void MoveRight()
    {
        _moving = true;
        _currentSpeed = -Speed;
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
