using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishScript : MonoBehaviour
{
    //Paramètres 
    public string nom = "<noname>";
    public double prix = 0;
    public GameObject prefab;
    
    // Start is called before the first frame update
    void Awake()
    {
        GameObject nameTemplate = gameObject.transform.Find("NameTemplate").gameObject; 
        nameTemplate.GetComponent<TextMesh>().text = Convert.ToString(nom);
        GameObject priceTemplate = gameObject.transform.Find("PriceTemplate").gameObject; 
        priceTemplate.GetComponent<TextMesh>().text = Convert.ToString(prix)+" €";  
        // priceTemplate.GetComponent<TextMesh>().alignment = TextAlignment.Center; 
        
        Vector3 position = gameObject.transform.position;
        Instantiate(prefab, position, Quaternion.identity, gameObject.transform);
        //o.transform.parent = transform.root;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
