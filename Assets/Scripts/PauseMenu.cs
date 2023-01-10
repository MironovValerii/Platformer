using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private int sound;
    public GameObject ImageSours;
    public GameObject ImageSours1;
    void Start()
    {
        gameObject.SetActive(false);
        if (PlayerPrefs.HasKey("Sound"))
            sound = PlayerPrefs.GetInt("Sound");
        if (sound == 0)
        {
            ImageSours.SetActive(false);
            ImageSours1.SetActive(true);
        }
        else if (sound == 1)
        {
            ImageSours.SetActive(true);
            ImageSours1.SetActive(false);
        }
    }

    public void OnClickPlay()
    {
        gameObject.SetActive(false);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }
    public void Sound()
    {
        if (sound == 0)
        {
            sound += 1;
            ImageSours.SetActive(true);
            ImageSours1.SetActive(false);
        }
        else if (sound == 1)
        {
            ImageSours.SetActive(false);
            ImageSours1.SetActive(true);
            sound -= 1;
        }
        PlayerPrefs.SetInt("Sound", sound);
    }
    public void OnExitMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OnClickExit1()
    {
        Application.Quit();
    }
}
