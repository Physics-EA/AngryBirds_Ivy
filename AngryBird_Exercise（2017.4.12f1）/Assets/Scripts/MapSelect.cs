using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour
{

    public int starsNum = 0;
    private bool isSelect = false;

    public GameObject locks;
    public GameObject stars;
    public GameObject panel;
    public GameObject map;

    public Text starsText;
    public  int startNum = 1;
    public  int endNum = 3;


    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("totalNum", 0) >= starsNum)
        {
            isSelect = true;
        }

        if (isSelect)
        {
            locks.SetActive(false);
            stars.SetActive(true);

            int count = 0;
            for (int i = startNum; i < endNum; i++)
            {
                count += PlayerPrefs.GetInt("level" + i.ToString(),0);
            }
            starsText.text = count.ToString()+"/9";
        }

    }

    // Update is called once per frame 
    void Update()
    {

    }

    public void Selected()
    {
        if (isSelect)
        {
            panel.SetActive(true);
            map.SetActive(false);

        }
    }

    public void PanelSelect()
    {
        panel.SetActive(false);
        map.SetActive(true);
    }
}
