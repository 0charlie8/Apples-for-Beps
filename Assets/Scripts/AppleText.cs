using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AppleText : MonoBehaviour
{
    public static int apples;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = apples.ToString();
    }
}
