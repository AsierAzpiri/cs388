using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScriptManager : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 scores = new Vector2(0,0);
    public GameObject gameManager;
    public GameObject bol;
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text playerWonText;
    public Animator animator;

    private 

    void Start()
    {
        Camera.main.aspect = 1280f / 800f;
    }
#if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AddScore(true);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            AddScore(false);
    }
#endif

    public void AddScore(bool player)
    {
        if (player)
            scores.y++;
        else
            scores.x++;

        scoreText.text = scores.x + " - " + scores.y;

        if ((scores.x == 5 || scores.y == 5))
            PlayerWon(player);
    }

    void PlayerWon(bool player)
    {
        if (player)
            playerWonText.text = "Right player won!";
        else
            playerWonText.text = "Left player won!";

        bol.GetComponent<BallController>().stopBall();

        Invoke("Fade", 1);
        Invoke("Reload", 2);
    }

    void Fade()
    {
        animator.Play("FadeOut");
    }
    void Reload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("1_PlayerSelect");
    }

}
