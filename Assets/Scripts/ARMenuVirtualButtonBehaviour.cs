using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARMenuVirtualButtonBehaviour : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    }
    
    public SelectionScript selectionScript;
    public GameObject button;
    public Direction direction;
    
    private Color _initialColor;
    private VirtualButtonBehaviour _buttonBehaviour;

    void Awake()
    {
        _buttonBehaviour = button.GetComponent<VirtualButtonBehaviour>();
        _buttonBehaviour.RegisterOnButtonPressed(OnButtonPressed);
        _buttonBehaviour.RegisterOnButtonReleased(OnButtonReleased);
        _initialColor = this.button.transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
    }

    void OnButtonPressed(VirtualButtonBehaviour vbb)
    {
        Debug.Log("Button pressed");
        this.button.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.clear;
        if (direction == Direction.Left)
        {
            selectionScript.MoveLeft();
        }
        else
        {
            selectionScript.MoveRight();
        }
    }
    
    void OnButtonReleased(VirtualButtonBehaviour vbb)
    {
        Debug.Log("Button released");
        this.button.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = _initialColor;
    }
}
