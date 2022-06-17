using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : MonoBehaviour
{

    [SerializeField]
    float shotspeed = 3f;

    [SerializeField]
    bool isPlayer = true;

    float timeAlive = 1;
    float timer = 0;
    Vector3 position;
    // Update is called once per frame

    private void Start()
    {
        position = transform.position;
    }
    void Update()
    {
        if (isPlayer)
        {
            position += Vector3.up * shotspeed*Time.deltaTime;
            transform.position = position;
        }
        else
        {
            position -= Vector3.up * shotspeed * Time.deltaTime;
            transform.position = position;
        }
        timer += Time.deltaTime;
        if (timer > timeAlive)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isPlayer)
        {
            collision.gameObject.SendMessage("GetHit");
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy" && isPlayer)
        {

            collision.gameObject.SendMessage("GetHit");
            Destroy(this.gameObject);
        }
        else { }


    }
}
