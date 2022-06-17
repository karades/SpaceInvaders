using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    Text scoreText;

    [SerializeField]
    Text hpText;

    [SerializeField]
    PlayerController PlayerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.GetScore().ToString();
        hpText.text = "HP: " + PlayerController.GetHP().ToString();
    }
}
