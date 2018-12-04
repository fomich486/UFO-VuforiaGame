using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public static Score Instance;

    private int score = 0;
    [SerializeField]
    Text txtScore;
    [SerializeField]
    GameObject gameoverField;
    [SerializeField]
    Text messageBox;
    [SerializeField]
    GameObject joystick;
    [SerializeField]
    GameObject upButton;
    [SerializeField]
    GameObject downButton;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        SetScore(0);
    }
    public void SetScore(int add)
    {
        score += add;
        txtScore.text = string.Format("Score : {0}", score);
        if (score >= 10)
        {
            GameOver("Nice job!! Restart?");
        }
    }

    public void GameOver(string Message)
    {
        gameoverField.SetActive(true);
        upButton.SetActive(false);
        joystick.SetActive(false);
        if (downButton != null)
            downButton.SetActive(false);
        messageBox.text = Message;

    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Finish()
    {
        Application.Quit();
    }
}
