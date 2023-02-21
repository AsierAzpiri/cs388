using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControllerScript : MonoBehaviour
{
    public UnityEngine.UI.Text inputText;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        inputText.text = "press Space to continue";
#endif
#if UNITY_ANDROID
        inputText.text = "touch the screen to continue";
#endif
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("FadeOut");
            Invoke("Exit", 1);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        #endif
        #if UNITY_ANDROID
        if(Input.touchCount == 1)
        {
            animator.Play("FadeOut");
            Invoke("Exit", 1);
        }
        if (Input.touchCount == 2)
            Application.Quit();
        #endif
    }

    private void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.SceneManagement.EditorSceneManager.LoadScene(2);
        #endif
        #if UNITY_ANDROID
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        #endif
    }
}
