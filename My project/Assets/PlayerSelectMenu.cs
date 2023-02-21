using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectMenu : MonoBehaviour
{
    public Animator animator;

    public void SelectSinglePlayer()
    {
        Debug.Log("Button");
        DontDestroyOnLoad(this);
        animator.Play("FadeOut");
        Invoke("LoadNextScreen", 1);
        PlayerPrefs.SetInt("Versus Mode", 0);
    }

    public void SelectMultiPlayer()
    {
        DontDestroyOnLoad(this);
        animator.Play("FadeOut");
        Invoke("LoadNextScreen", 1);
        PlayerPrefs.SetInt("Versus Mode", 1);
    }

    private void LoadNextScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
