using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    [SerializeField] int ClickCounter;
    public Text stringText;
    private void Start()
    {
        ClickCounter = PlayerPrefs.GetInt("Clicks");
    }
    public void ButtonClick()
    {
        ClickCounter++;
        PlayerPrefs.SetInt("Clicks", ClickCounter);
    }
    public void ToShop()
    {
        SceneManager.LoadScene(1);
    }
    public void ToMainScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ToProjects()
    {
        SceneManager.LoadScene(2);
    }
    public void ToFrelance()
    {
        SceneManager.LoadScene(3);
    }

    void Update()
    {
        stringText.text = ClickCounter.ToString();
    }
}
