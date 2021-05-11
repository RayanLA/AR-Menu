using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SwitchScript : MonoBehaviour
{
    public SelectionScript selectionScript;
    
    private VirtualButtonBehaviour _buttonBehaviour;

   void Awake()
    {
        _buttonBehaviour = gameObject.GetComponent<VirtualButtonBehaviour>();
        _buttonBehaviour.RegisterOnButtonPressed(OnButtonPressed);
    }

    void OnButtonPressed(VirtualButtonBehaviour vbb)
    {
        if (selectionScript.SwitchList() == SelectionScript.Lists.Plats)
        {
            gameObject.transform.Find("SwitchText").gameObject.GetComponent<TextMesh>().text = "Desserts";
        }
        else
        {
            gameObject.transform.Find("SwitchText").gameObject.GetComponent<TextMesh>().text = "Plats";
        }
    }
}
