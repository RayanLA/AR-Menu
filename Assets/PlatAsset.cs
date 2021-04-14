using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatAsset : MonoBehaviour
{
	//Paramètres 
	public string nom = "";
	public int prix = 0;
	public GameObject model3D;

	// Inner field
	


    // Start is called before the first frame update
    void Start()
    {
		GameObject _NomPlat = GameObject.Find("NomPlat"); 
    	_NomPlat.GetComponent<TextMesh>().text = nom; 
    	_NomPlat.GetComponent<TextMesh>().alignment = TextAlignment.Center; 
 
    	GameObject _prix = GameObject.Find("Prix"); 
    	_prix.GetComponent<TextMesh>().text = Convert.ToString(prix)+" €";  
    	_prix.GetComponent<TextMesh>().alignment = TextAlignment.Center;  
 
    	GameObject _model3D = GameObject.Find("Model3D"); 
    	//Replace existing object  
    	Quaternion rotation = _model3D.transform.rotation; 
        Vector3 position = _model3D.transform.position; 
    	GameObject temp = Instantiate(model3D, position, rotation);  
    	temp.transform.SetParent(_model3D.transform.parent); 
    	DestroyImmediate(_model3D); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
