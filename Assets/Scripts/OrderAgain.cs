using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class OrderAgain : MonoBehaviour
{
    public ValidationCommande _ValidationCommande;
    private VirtualButtonBehaviour _buttonBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Awake()
    {
        _buttonBehaviour = gameObject.GetComponent<VirtualButtonBehaviour>();
        _buttonBehaviour.RegisterOnButtonPressed(OnButtonPressed);
    }
    
    void OnButtonPressed(VirtualButtonBehaviour vbb)
    {
        Debug.Log("Order again ");
        /*_ValidationCommande.displayMenus(true);
        transform.gameObject.SetActive(false);*/
    }
    
}
