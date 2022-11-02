using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyhpviewer : MonoBehaviour
{
    private enemyhp01 enemyhp;
    private Slider hpslider;

    public void Setup(enemyhp01 enemyhp)
    {
        this.enemyhp = enemyhp;
        hpslider = GetComponent<Slider>();
    }
    private void Update()
    {
        hpslider.value = enemyhp.Currenthp / enemyhp.Maxhp;
    }
}
