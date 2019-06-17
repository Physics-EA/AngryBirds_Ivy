using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float maxSpeed = 10;
    public float minSpeed = 5;
    private SpriteRenderer render;
    public Sprite hurt;
    public GameObject boom;
    public GameObject score;
    public bool isPig;


    void Start()
    {
        render = transform.GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            Dead();
        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude <= maxSpeed)
        {
            render.sprite = hurt;
        }
    }

    void Dead()
    {
        if (isPig)
        {
            GameManager._instance.pigs.Remove(this);
        }

        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);


        GameObject go = Instantiate(score, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
        Destroy(go, 1.5f);
    }
}
