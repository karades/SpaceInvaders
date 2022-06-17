using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField]
    float shotSpeed = 5;

    float timerShot = 0;

    [SerializeField]
    GameObject BulletPrefab;

    ScoreManager scoreManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shot();
    }


    void shot()
    {
        timerShot += Time.deltaTime;

        if(timerShot > shotSpeed)
        {
            if (Random.Range(0f, 1f) < 0.1)
            {
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            }
            timerShot = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Die");
        }
    }
    public void GetHit()
    {
        Destroy(this.gameObject);
        //score
        ScoreManager.Instance.AddScore(100);


    }

}
