using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    [SerializeField] int ClickCounter;
    public Text stringText;
    public void ButtonClick()
    {
        ClickCounter++;
    }

    void Update()
    {
        stringText.text = ClickCounter.ToString();
    }
}
