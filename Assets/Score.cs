using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    Text text;
    public static int pelletAmount;


    void start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = pelletAmount.ToString();
    }
}
