using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isClick = false;
    public float maxDis = 2f;
    public Transform rightPos;
    public Transform leftPos;
    [HideInInspector]
    public SpringJoint2D sp;
    private Rigidbody2D rg;

    public GameObject boom;

    public LineRenderer right;
    public LineRenderer left;

    private TestMyTrail myTrail;

    private bool canMove = true;
    private void Awake()
    {
        sp = transform.GetComponent<SpringJoint2D>();
        rg = transform.GetComponent<Rigidbody2D>();
        myTrail = GetComponent<TestMyTrail>();
    }

    void Update()
    {
        if (isClick)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            if (Vector3.Distance(transform.position, rightPos.position) > maxDis)
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;
                transform.position = rightPos.position + pos * maxDis;
            }
            Line();
        }
    }

    private void OnMouseDown()
    {
        if (canMove)
        {
            isClick = true;
            rg.isKinematic = true;
        }

    }

    private void OnMouseUp()
    {
        if (canMove)
        {


            isClick = false;
            rg.isKinematic = false;
            Invoke("Fly", 0.1f);
            right.enabled = false;
            left.enabled = false;
            canMove = false;
        }
    }


    void Fly()
    {
        myTrail.StartTrails();
        sp.enabled = false;
        Invoke("Next", 5f);

    }

    void Line()
    {
        right.enabled = true;
        left.enabled = true;
        right.SetPosition(0, rightPos.position);
        right.SetPosition(1, transform.position);

        left.SetPosition(0, leftPos.position);
        left.SetPosition(1, transform.position);
    }

    void Next()
    {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameManager._instance.NextBird();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myTrail.ClearTrails();
    }

}
