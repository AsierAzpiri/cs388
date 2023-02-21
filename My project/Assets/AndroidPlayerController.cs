using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlayerController : MonoBehaviour
{
#if UNITY_ANDROID
    public bool isLeft;

    public float speed = 10.0f;
    Vector3 tempPosition;
    public Vector2 verticalLimits = Vector2.zero;

    int versusMode;
    Transform ballRef;
    // Start is called before the first frame update
    void Start()
    {
        versusMode = PlayerPrefs.GetInt("Versus Mode");
        ballRef = GameObject.FindObjectOfType<BallController>().transform;
        tempPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        if (!isLeft && versusMode == 0)
            UpdateAI();
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate: " + gameObject.name);
        transform.position = tempPosition;
    }

    void UpdateAI()
    {
        tempPosition.y = ballRef.position.y;
    }

    void CheckMovement()
    {
        if (Input.touchCount == 0)
            return;

        for(int i = 0; i < Input.touchCount; i++)
        {
            if(isLeft && Input.touches[i].position.x < Screen.width / 2f)
            {
                if (Input.touches[i].position.y > Screen.height / 2f)
                    tempPosition += Vector3.up * speed * Time.deltaTime;
                else
                    tempPosition -= Vector3.up * speed * Time.deltaTime;
            }
            else if (versusMode == 1 && !isLeft && Input.touches[i].position.x > Screen.width / 2f)
            {
                if (Input.touches[i].position.y > Screen.height / 2f)
                    tempPosition += Vector3.up * speed * Time.deltaTime;
                else
                    tempPosition -= Vector3.up * speed * Time.deltaTime;
            }
        }

        tempPosition.y = Mathf.Clamp(tempPosition.y, verticalLimits.x, verticalLimits.y);
    }
#endif
}
