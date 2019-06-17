using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    private Animator anim;
    public GameObject pauseButton;

    private void Awake()
    {
        anim = transform.GetComponent<Animator>();
    }

    public void Retry()
    {

    }

    public void Pause()
    {
        anim.SetBool("isPause", true);
        pauseButton.SetActive(false);
    }

    public void Home()
    {

    }

    public void Resume()
    {
        Time.timeScale = 1;
        anim.SetBool("isPause", false);
    }

    public void PauseAnimEnd()
    {
        Time.timeScale = 0;
    }

    public void ResumeAnimEnd()
    {
        pauseButton.SetActive(true);
    }

}
