using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ValidationCommande : MonoBehaviour
{
    private double montant = 0.0;
    private VirtualButtonBehaviour _buttonBehaviour;

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {}

    void Awake()
    {
        _buttonBehaviour = gameObject.GetComponent<VirtualButtonBehaviour>();
        _buttonBehaviour.RegisterOnButtonPressed(OnButtonPressed);
    }

    void OnButtonPressed(VirtualButtonBehaviour vbb)
    {
        Debug.Log("Commande passée ");
    }

    public double Montant
    {
        get => montant;
        set => montant = value;
    }


    public void updatePrice()
    {
        gameObject.transform.Find("MontantCommande").gameObject.GetComponent<TextMesh>().text = (montant).ToString() + " €";
    }
}
