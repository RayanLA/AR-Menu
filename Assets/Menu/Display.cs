using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Display : MonoBehaviour
{
    public MenuListScript menu;
    private DishScript currInstance;
    void Update()
    {
    }

    public void displayObject(int index)
    {
        if (currInstance != null)
        {
            //currInstance.gameObject.SetActive(false);
            Destroy(currInstance.gameObject);
        }
        currInstance = Instantiate(menu.Select(index));
        currInstance.transform.parent = transform;
        currInstance.transform.localPosition = gameObject.transform.localPosition;
        currInstance.transform.localScale = new Vector3(4, 4, 4);
    }
}
