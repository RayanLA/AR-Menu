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
    void Start()
    {
        prefab.transform.localScale = new Vector3(1, 1, 1);
        GameObject o = Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);

        
        
        
        //Texte
        // var theText = new GameObject();
        // var textMesh = theText.AddComponent<TextMesh>();
        // var meshRenderer = theText.AddComponent<MeshRenderer>();
        // textMesh.text = dishName;
        //     
        //     
        // var name = dishName;
        // TextMesh name3d = new TextMesh();
        // name3d.text = name;
        //
        // Instantiate(theText, new Vector3(0, 0, (float)2), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
