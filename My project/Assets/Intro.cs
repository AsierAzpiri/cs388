using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Fade", 2);
    }

    void Fade()
    {
        animator.Play("FadeOut");
        Invoke("Exit", 1);
    }
    void Exit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("0_MainMenu 1");
    }
}
