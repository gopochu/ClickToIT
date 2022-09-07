using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public int money;
    [SerializeField] int ClickCounter;
    public Text stringText;
    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        ClickCounter = PlayerPrefs.GetInt("Clicks");
    }
    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money++;
        Debug.Log(money);
        PlayerPrefs.SetInt("money",money);
        StartCoroutine(IdleFarm());
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
