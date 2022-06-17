using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineMovement : MonoBehaviour
{
    [SerializeField]
    float lineSpeed=1;
    [SerializeField]
    GameObject[] linesOfEnemies;
    
    bool isGoingLeft;
    int[] enemiesInLine;
    float minMoveLimit = -6;
    float maxMoveLimit = 6;

    [SerializeField]
    PlayerController PlayerController;
    void Start()
    {
        enemiesInLine = new int[linesOfEnemies.Length];
        isGoingLeft = true ;

        for (int i = 0; i < linesOfEnemies.Length; i++)
        {
            Transform tempParent = linesOfEnemies[i].transform;
            enemiesInLine[i] = tempParent.childCount;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateEnemiesInLine(); //to optimize
        for (int i = 0; i < linesOfEnemies.Length; i++)
        {
            moveLine(i);
        }
        checkIfWin();
    }
    public void updateEnemiesInLine()
    {
        for (int i = 0; i < linesOfEnemies.Length; i++)
        {
            Transform tempParent = linesOfEnemies[i].transform;
            enemiesInLine[i] = tempParent.childCount;

        }
    }
    void checkIfWin()
    {
        int counter = 0;
        for (int i = 0; i < linesOfEnemies.Length; i++)
        {
            Transform tempParent = linesOfEnemies[i].transform;
            enemiesInLine[i] = tempParent.childCount;
            counter += enemiesInLine[i];
        }
        if (counter == 0)
        {
            ScoreManager.Instance.addHpScore(PlayerController.GetHP());
            ScoreManager.Instance.SetIsWin(1);
            ScoreManager.Instance.EndGame();
        }

    }
    void moveLine(int line)
    {
        Transform EnemyLine = linesOfEnemies[line].transform;

        if (isGoingLeft)
        {

            foreach (Transform enemy in EnemyLine)
            {

                Vector3 tempPosition = enemy.position;
                if (tempPosition.x <= minMoveLimit)
                {
                    isGoingLeft = false;
                    for (int i = 0; i < linesOfEnemies.Length; i++)
                    {
                        linesOfEnemies[i].transform.position -= new Vector3(0, 0.08f, 0);
                    }
                    break;
                }
                tempPosition.x -= lineSpeed * Time.deltaTime + (1 - (enemiesInLine[line]) / (enemiesInLine[line] + 1)) * Time.deltaTime; ;
                enemy.position = tempPosition;

            }
        }
        else
        {
            foreach (Transform enemy in EnemyLine)
            {

                Vector3 tempPosition = enemy.position;
                if (tempPosition.x >= maxMoveLimit)
                {
                    isGoingLeft = true;
                    for (int i = 0; i < linesOfEnemies.Length; i++)
                    {
                        linesOfEnemies[i].transform.position -= new Vector3(0, 0.08f, 0);
                    }
                    break;
                }
                tempPosition.x += lineSpeed * Time.deltaTime +(1- (enemiesInLine[line])/(enemiesInLine[line]+1))*Time.deltaTime;
                enemy.position = tempPosition;

            }
        }


    }
}
