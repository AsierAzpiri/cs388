using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text inputText;
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        inputText.text = "Not Android";
#endif
#if UNITY_ANDROID
        inputText.text = "Android";
#endif
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Space))
                UnityEditor.SceneManagement.EditorSceneManager.LoadScene("SampleScene");

            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
#endif
#if UNITY_ANDROID
            if (Input.touchCount == 1)
                Application.Quit();
#endif
    }
}
