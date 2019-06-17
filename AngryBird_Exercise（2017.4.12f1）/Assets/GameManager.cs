using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Bird> birds;
    public List<Pig> pigs;

    public static GameManager _instance;

    private Vector3 originPos;
    public GameObject win;
    public GameObject lose;

    public GameObject[] stars;

    private void Awake()
    {
        _instance = this;
        if (birds.Count > 0)
        {
            originPos = birds[0].transform.position;
        }

    }


    void Start()
    {
        Initialized();
    }

  

    void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[i].transform.position = originPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
    }


    public void NextBird()
    {
        if (pigs.Count > 0)
        {
            if (birds.Count > 0)
            {
                Initialized();
            }
            else
            {
                lose.SetActive(true);
            }
        }
        else
        {
            win.SetActive(true);
        }
    }

    public void ShowStars()
    {
        StartCoroutine("show");
    }

    IEnumerator show()
    {
        for (int i = 0; i < birds.Count + 1; i++)
        {
            yield return new WaitForSeconds(0.2f);
            stars[i].SetActive(true);
        }
    }


    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    public void Home()
    {
        SceneManager.LoadScene(1);
    }
}
