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
    private List<Vector3> _positions = new List<Vector3>();

    private const float Speed = 4f;
    private float _currentSpeed = Speed;
    private int currentIndex = 0;

    private readonly HashSet<DishScript> _displayedDishes = new HashSet<DishScript>();
    
    
    // Start is called before the first frame update
    public void Start()
    {
        this.InitInstances();
        /*for (int i = 0; i < 4; i++)
        {   
            Vector3 pos = transform.parent.GetChild(3).GetChild(i).transform.position;
            _positions.Add(new Vector3(pos.x, pos.y, pos.z));
            
            /*
            instanceList[i].gameObject.transform.position = pos;
            instanceList[i].gameObject.SetActive(true);#1#
        }*/

        Debug.Log(_positions);
    }
    
    public List<Vector3> Positions
    {
        get => _positions;
        set => _positions = value;
    }

    // Update is called once per frame
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

        DisplayDish();
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
    
    int mod(int n, int x)
    {
        return ((n%x)+x)%x;
    }

    private void DisplayDish()
    {
        for (int i = 0; i < instanceList.Count; i++)
        {
            int idx = mod (currentIndex + i, instanceList.Count) ;
            Debug.Log(">>>>>>>" + idx + " "+currentIndex + i + " " + currentIndex + " " + i  );
            if (i < 4)
            {
                instanceList[idx].gameObject.transform.position = _positions[i];
                Debug.Log(_positions[i].x + " " +_positions[i].y );
                instanceList[idx].gameObject.SetActive(true);
            }
            else
            {
                instanceList[idx].gameObject.SetActive(false);
            }
        }
    }

    public void MoveLeft()
    {
        /*Vector3 currentPos = new Vector3();
        
        Vector3 previousPos = instanceList[instanceList.Count-1].gameObject.transform.position;
        for (int i = 0; i < instanceList.Count; i++)
        {
            currentPos = instanceList[i].gameObject.transform.position;
            instanceList[i].gameObject.transform.position = previousPos;
            previousPos = currentPos;
        }*/
        Debug.Log("MoveLeft");
        this.currentIndex--;
        this.DisplayDish();
        
    }
    
    public void MoveRight()
    {
        /*Vector3 currentPos = new Vector3();
        Vector3 previousPos = instanceList[0].gameObject.transform.position;
        for (int i = instanceList.Count-1; i >= 0; i--)
        {
            currentPos = instanceList[i].gameObject.transform.position;
            instanceList[i].gameObject.transform.position = previousPos;
            previousPos = currentPos;
        }*/
        Debug.Log("MoveRight");
        this.currentIndex++;
        this.DisplayDish();
        

    }

    public bool Moving
    {
        get => _moving;
        set => _moving = value;
    }
}
