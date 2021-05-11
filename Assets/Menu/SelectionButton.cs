using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SelectionButton : MonoBehaviour
{
    public int selectionIndex;
    public Display display;
    
    void Awake()
    {
        var _buttonBehaviour = GetComponent<VirtualButtonBehaviour>();
        _buttonBehaviour.RegisterOnButtonPressed(OnButtonPressed);
    }

    void OnButtonPressed(VirtualButtonBehaviour vbb)
    {
        display.displayObject(selectionIndex);
    }
}
