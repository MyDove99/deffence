using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI texttimer;
    [SerializeField]
    private TextMeshProUGUI textmtimer;

    public float time;
     void Update()
    {
            time += Time.deltaTime;
            if (time < 60)
            {
                texttimer.text = ((int)time % 60).ToString();
            }
            else if (time > 60)
            {
                texttimer.text = ((int)time % 60).ToString();
                textmtimer.text = ((int)time / 60 % 60).ToString() + ":";
            }
    }
}
