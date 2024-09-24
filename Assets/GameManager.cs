using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [HeaderAttribute(" Score variables")]
    int score;
    public TextMeshProUGUI scoreText;

    public void CurrentScore(int numb)
    {
        score = score + numb;
        scoreText.text = "Score: " + score;

    }
    void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
