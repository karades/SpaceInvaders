using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;

    public static ScoreManager Instance { get { return _instance; } }

    int score = 0;
    int isWin = 0;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    private void Update()
    {

    }
    public void AddScore(int addedScore)
    {
        score += addedScore;
    }
    public void ResetScore()
    {
        score = 0;
    }
    public int GetScore()
    {
        return score;
    }
    public int GetIsWin()
    {
        return isWin;
    }
    public void SetIsWin(int result)
    {
        isWin = result;
    }
    public void addHpScore(int hp)
    {
        score += hp * 250;
    }
    public void EndGame()
    {

        SceneManager.LoadScene("GameOver");
    }

}
