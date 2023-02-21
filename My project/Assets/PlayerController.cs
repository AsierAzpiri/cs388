using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
#if UNITY_EDITOR
    public KeyCode upKey;
    public KeyCode downKey;

    public float speed = 10.0f;
    Vector3 tempPosition;
    public Vector2 verticalLimits = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start: " + gameObject.name);
        tempPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        transform.position = tempPosition;
        //Debug.Log("Update: " + gameObject.name);
    }

    private void LateUpdate()
    {
        //Debug.Log("LateUpdate: " + gameObject.name);
    }

    private void FixedUpdate()
    {
        
    }

    void CheckMovement()
    {

        if(Input.GetKey(upKey))
        {
            //Move upwards
            tempPosition += Vector3.up * speed * Time.deltaTime;
        }
        else if (Input.GetKey(downKey))
        {
            //Move downwards
            tempPosition -= Vector3.up * speed * Time.deltaTime;
        }

        tempPosition.y = Mathf.Clamp(tempPosition.y, verticalLimits.x, verticalLimits.y);
    }
#endif
}
