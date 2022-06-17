using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject ShotPrefab;

    int hp = 3;

    [SerializeField]
    float shotSpeed = 1;

    float timerShot = 0;
    public float playerSpeed = 5f;

    float minMoveLimit = -6;
    float maxMoveLimit = 6;
    private void Awake()
    {
        hp = 3;
    }
    void Update()
    {
        handleMovement();
        shot();
    }

    void handleMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if(transform.position.x > minMoveLimit)
            {
                Vector3 position = transform.position;
                position.x -= playerSpeed * Time.deltaTime;
                transform.position = position;
            }
      
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < maxMoveLimit)
            {
                Vector3 position = transform.position;
                position.x += playerSpeed * Time.deltaTime;
                transform.position = position;
            }
        }

    }
    void shot()
    {
        timerShot += Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            if (timerShot >= shotSpeed)
            {
                Instantiate(ShotPrefab, transform.position ,Quaternion.identity);
                timerShot = 0;
            }
        }
    }

    public int GetHP()
    {
        return hp;
    }
    public void GetHit()
    {
        hp--;
        if (hp <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        ScoreManager.Instance.SetIsWin(0);
        ScoreManager.Instance.EndGame();
    }
}
