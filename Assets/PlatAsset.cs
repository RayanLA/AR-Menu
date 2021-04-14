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
    	GameObject _prix = GameObject.Find("Prix");
    	_prix.GetComponent<TextMesh>().text = Convert.ToString(prix)+" €"; 
    	GameObject _model3D = GameObject.Find("Model3D");
    	_model3D = Instantiate(model3D); 
            //Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
