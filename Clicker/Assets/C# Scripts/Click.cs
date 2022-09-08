using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public int moneyForSecond;
    public int complexity;
    public int marketing;
    public int money;
    public int purpose;
    public bool work = false;
    [SerializeField] int ClickCounter;
    public Text purposeText;
    public Text clickText;
    public Text moneyText;
    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        ClickCounter = PlayerPrefs.GetInt("Clicks");
    }
    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money = money + moneyForSecond;
        Debug.Log(money);
        PlayerPrefs.SetInt("money",money);
        StartCoroutine(IdleFarm());
    }
    public void ButtonClick()
    {
        ClickCounter++;
        PlayerPrefs.SetInt("Clicks", ClickCounter);
    }
    public void Post()
    {
        if (work == false)
            marketing = 1;
    }
    public void Video()
    {
        if (work == false)
            marketing = 2;
    }
    public void Stream()
    {
        if (work == false)
            marketing = 3;
    }
    public void IndiProject()
    {
        if (work == false)
            complexity = 1;
    }
    public void AAProject()
    {
        if (work == false)
            complexity = 2;
    }
    public void AAAProject()
    {
        if (work == false)
            complexity = 3;
    }
    public void Apply()
    {
        ClickCounter = 0;
        work = true;
        if (complexity == 1)
            ApplyIndiProject();
    }
    public void ApplyIndiProject()
    {
        purpose = 500;
        ClickCounter = 0;
        purposeText.text = purpose.ToString();
        if (ClickCounter == 30)
        {
            work = false;
            moneyForSecond = moneyForSecond + 5;
        }
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
        purposeText.text = purpose.ToString();
        clickText.text = ClickCounter.ToString();
        moneyText.text = money.ToString();
    }
}