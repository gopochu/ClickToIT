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
    public bool work;
    [SerializeField] int ClickCounter;
    public Text purposeText;
    public Text clickText;
    public Text moneyText;
    private void Start()
    {
        purpose = PlayerPrefs.GetInt("purpose");
        money = PlayerPrefs.GetInt("money");
        ClickCounter = PlayerPrefs.GetInt("Clicks");
        Debug.Log(work);
    }
    public void JobCheck()
    {
        //if (work == false)
        //    ClickCounter = 0;
        //Debug.Log(work);
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
        if (work == true)
        {
            ClickCounter++;
        }
            PlayerPrefs.SetInt("Clicks", ClickCounter);
    }
    public void WorkCompletionCheck()
    {
        if (purpose != 0 && ClickCounter != 0)
        {
            if (ClickCounter == purpose)
            {
                purpose = 0;
                marketing = 0;
                ClickCounter = 0;
                PlayerPrefs.SetInt("purpose", purpose);
                purposeText.text = purpose.ToString();
                work = false;
                Debug.Log(work);
                moneyForSecond = moneyForSecond + 5;
                StartCoroutine(IdleFarm());
            }
        }
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
    public void CreateProject()
    {
        if (complexity == 1)
            ApplyIndiProject();
        if (complexity == 2)
            ApplyAAProject();
        if (complexity == 3)
            ApplyAAAProject();
    }
    public void Marketing()
    {
        if (marketing == 1)
            moneyForSecond = moneyForSecond + 10;
        if (marketing == 2)
            moneyForSecond = moneyForSecond + 15;
        if (marketing == 3)
            moneyForSecond = moneyForSecond + 20;
        PlayerPrefs.SetInt("moneyForSecond", moneyForSecond);
    }
    public void Apply()
    {
        work = true;
        Debug.Log(work);
        CreateProject();
        Marketing();
    }
    public void ApplyIndiProject()
    {
        purpose = 20;
        PlayerPrefs.SetInt("purpose", purpose);
        purposeText.text = purpose.ToString();
    }
    public void ApplyAAProject()
    {
        purpose = 1000;
        PlayerPrefs.SetInt("purpose", purpose); 
        purposeText.text = purpose.ToString();
    }
    public void ApplyAAAProject()
    {
        purpose = 1500;
        PlayerPrefs.SetInt("purpose", purpose);
        purposeText.text = purpose.ToString();
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
        //JobCheck();
        WorkCompletionCheck();
        //purposeText.text = purpose.ToString();
        //clickText.text = ClickCounter.ToString();
        //moneyText.text = money.ToString();
    }
}