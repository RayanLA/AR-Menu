using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDisplayScript : MonoBehaviour
{
    private DishScript _currInstance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DisplayObject(DishScript dish)
    {
        if (_currInstance != null)
        {
            //currInstance.gameObject.SetActive(false);
            Destroy(_currInstance.gameObject);
        }

        _currInstance = Instantiate(dish, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        _currInstance.transform.Find("PriceTemplate").gameObject.GetComponent<TextMesh>().text = ""; 
        _currInstance.transform.localScale = new Vector3(3.5f,3.5f,3.5f);
    }
}
