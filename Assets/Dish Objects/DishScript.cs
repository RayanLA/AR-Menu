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
        //prefab.transform.localScale = new Vector3(1, 1, 1);

        // Change la taille
        //Vector3 targetSize = Vector3.one * 10.0f;

        //Debug.Log(prefab.gameObject.GetComponent<Renderer>().bounds);
        // Mesh m = prefab.GetComponent<MeshFilter>().sharedMesh;
        // Bounds meshBounds = m.bounds;
        // Vector3 meshSize = meshBounds.size;
        // float xScale = targetSize.x / meshSize.x * 100;
        // float yScale = targetSize.y / meshSize.y * 100;
        // float zScale = targetSize.z / meshSize.z * 100;
        // prefab.transform.localScale = new Vector3(xScale, yScale, zScale);

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
        Vector3 position = gameObject.transform.position;
        GameObject o = Instantiate(prefab, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
