using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gold : MonoBehaviour
{
    [SerializeField]
    private timer timer;
    [SerializeField]
    private int currentgold = 12;
    [SerializeField]
    private int currentsilver = 1;
    int stage = 0;
    [SerializeField]
    public int currenttree = 0;
    [SerializeField]
    public int currentkey = 0;
    [SerializeField]
    public int currentcrystal = 0;
    public int Currentgold
    {
        set => currentgold = Mathf.Max(0, value);
        get => currentgold;
    }
    public int Currentsilver
    {
        set => currentsilver = Mathf.Max(0, value);
        get => currentsilver;
    }
    // Update is called once per frame
    void Update()
    {
        int time = (int)timer.time;
        if (time == 9 + (30 * stage))
        {
            currentgold += 2;
            stage += 1;
        }
    }
}
