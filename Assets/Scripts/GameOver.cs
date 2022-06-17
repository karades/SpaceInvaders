using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    [SerializeField]
    Text winloseText;
    [SerializeField]
    Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        if (ScoreManager.Instance.GetIsWin() == 1) winloseText.text = "You win!";
        else { winloseText.text = "You lost :("; }

        scoreText.text = "Score: " + ScoreManager.Instance.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif 
        Application.Quit();
    }


}
