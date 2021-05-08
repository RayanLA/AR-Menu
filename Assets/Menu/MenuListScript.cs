using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuListScript : MonoBehaviour
{
    public List<DishScript> dishList;
    
    // Start is called before the first frame update
    void Start()
    {
        this.setPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setPositions()
    {
        Vector3 nextPosition = gameObject.transform.localPosition;
        float width = 10;
        float gap = 0.5f;

        for (int i = 0; i < dishList.Count; i++)
        {
            var currentDish = dishList[i];
            // currentDish.transform.position = new Vector3(nextPosition, 0, 0);
            Instantiate(currentDish, nextPosition, Quaternion.identity);
            nextPosition.x += (width + gap);
        }
    }
}
