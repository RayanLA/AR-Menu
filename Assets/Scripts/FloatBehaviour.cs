using UnityEngine;

public class FloatBehaviour : MonoBehaviour
{
    private Vector3 _position;
    
    public float degreesPerSecond = 5.0f;
    public float amplitude = 0.8f;
    public float frequency = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        _position = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f));
        
        // // Float up/down with a Sin()
        // Vector3 tempPos = _position;
        // tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
        //
        // transform.localPosition = tempPos;
    }
}
