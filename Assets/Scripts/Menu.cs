using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private InputField nameFild;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Player_Name"))
            nameFild.text = PlayerPrefs.GetString("Player_Name");
    }
    public void OnEndEditName()
    {
        PlayerPrefs.SetString("Player_Name", nameFild.text);
    }
    public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }    
    public void OnClickExit()
    {
        Application.Quit();
    }
}
