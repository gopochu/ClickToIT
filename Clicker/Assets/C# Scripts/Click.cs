using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public int potentiallyEarning;
    public int purpose = 0;
    public Text purposeText;
    public int marketing;
    public Text marketingText;
    public int hard;
    public int moneyForSecond;
    public int money;
    public bool work;
    [SerializeField] int ClickCounter;
    public Text clickText;
    private void Start()
    {
        purpose = PlayerPrefs.GetInt("purpose");
        money = PlayerPrefs.GetInt("money");
        ClickCounter = PlayerPrefs.GetInt("Clicks");
        Debug.Log(work);
    }
    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money = money + moneyForSecond;
        PlayerPrefs.SetInt("money",money);
        StartCoroutine(IdleFarm());
    }
    public void ButtonClick()
    {
        ClickCounter++;
        PlayerPrefs.SetInt("ClickCounter", ClickCounter);
    }
    public void WorkCompletionCheck()
    {
        if(ClickCounter == purpose)
        {
            work = false;
            ClickCounter = 0;
            purpose = 0;
        }
    }
    public void Apply()
    {
        if (work == false)
        {
            if (hard != 0)
            {
                CheckHard();
                if (marketing != 0)
                {
                    CheckMarketing();
                    work = true;
                }
            }
        }
    }
    public void CheckHard()
    {
        if (hard == 1)
        {
            purpose = 20;
            PlayerPrefs.SetInt("purpose", purpose);
            purposeText.text = purpose.ToString();
        }
        else if (hard == 2)
        {
            purpose = 30;
            PlayerPrefs.SetInt("purpose", purpose);
            purposeText.text = purpose.ToString();
        }
        else if (hard == 3)
        {
            purpose = 40;
            PlayerPrefs.SetInt("purpose", purpose);
            purposeText.text = purpose.ToString();
        }
    }
    public void CheckMarketing()
    {
        if(marketing == 1)
        {
            potentiallyEarning = 50;
        }
        else if(marketing == 2)
        {
            potentiallyEarning = 100;
        }
        else if(marketing == 3)
        {
            potentiallyEarning = 150;
        }
    }
    public void Indi()
    {
        if(work == false)
        {
            purpose = 1;
        }
    }
    public void AA()
    {
        if (work == false)
        {
            purpose = 2;
        }
    }
    public void AAA()
    {
        if (work == false)
        {
            purpose = 3;
        }
    }
    public void Post()
    {
        if (work == false)
        {
            marketing = 1;
        }
    }
    public void Video()
    {
        if (work == false)
        {
            marketing = 2;
        }
    }
    public void Stream()
    {
        if (work == false)
        {
            marketing = 3;
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
        WorkCompletionCheck();
        clickText.text = ClickCounter.ToString();
    }
}