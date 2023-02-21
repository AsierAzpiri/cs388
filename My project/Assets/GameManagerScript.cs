using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    Vector2 scores = Vector2.zero;
    public UnityEngine.UI.Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        // fix cam ratio
        Camera.main.aspect = 1280f / 800f;
        //scoreText = GameObject.Find("ScoreText").GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        // debug stuff
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AddScore(true);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            AddScore(false);
        // end of debug stuff

        // Going back ro main menu
        if (Input.GetKeyDown(KeyCode.Escape))
            UnityEditor.SceneManagement.EditorSceneManager.LoadScene(0);
#endif
    }

    public void AddScore(bool player1)
    {
        if(player1)
        {
            scores.x++;
            Debug.Log("ADDING SCORE TO PLAYER 1");
        }
        else
        {
            scores.y++;
            Debug.Log("ADDING SCORE TO PLAYER 2");
        }
        // all the logic when someone wins;
        if (scores.x > 4 || scores.y > 4)
            PlayerWon(player1);
        // update the canvas
        scoreText.text = scores.x + " - " + scores.y;
    }


    void PlayerWon(bool player1)
    {
        // all the logic when someone wins;

    }

}
