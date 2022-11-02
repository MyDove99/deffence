using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public int compensationgold;
    public int compensationtree;
    private timer timer;
    private gold gold;
    private float time;
    private float alive;

    // Start is called before the first frame update
    void Awake()
    {
        gold = GameObject.Find("PlayerStats").GetComponent<gold>();
        timer  = GameObject.Find("PanelInfoUI").GetComponent<timer>();
        time = timer.time;
        alive = timer.time;
    }

    // Update is called once per frame
    void Update()
    {
        time = timer.time;
        if(time == alive + 30)
        {
        }
    }
    private void OnDestroy()
    {
        gold.Currentgold = gold.Currentgold + compensationgold;
        gold.currenttree = gold.currenttree + compensationtree;
    }
}
