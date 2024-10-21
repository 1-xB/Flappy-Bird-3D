using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextScore : MonoBehaviour
{
    public int Score;
    [SerializeField] TMP_Text  scoreText;
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame

    public void IncreaseScore()
    {
        Score++;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score : " + Score.ToString();
    }
}
