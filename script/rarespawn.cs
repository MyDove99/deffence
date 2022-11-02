using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rarespawn : MonoBehaviour
{
    [SerializeField]
    private towerspawner towerspawner;
    public int rare;
    public int num1 = 0;
    public int num2 = 0;
    private int warningnum = 0;
    private notice notice;
    private void Start()
    {
        notice = GameObject.Find("noticeImage").GetComponent<notice>();
    }
    private void warning(int num1)
    {
        notice.warning(towerspawner.towerlist[num1].name + " 가(이) 부족합니다! ");
    }
    public void spawn()
    {
        if (rare == 9)
        {
            if (towerspawner.towerlist[0].ea > 1)
            {
                num1 = 0; num2 = 0;
            }
            else { warning(0); return;  }
        }
        else if (rare == 10)
        {
            if (towerspawner.towerlist[1].ea > 1)
            {
                num1 = 1; num2 = 1;
            }
            else { warning(1); return;  }
        }
        else if(rare == 11)
        {
            if (towerspawner.towerlist[2].ea > 0 && towerspawner.towerlist[5].ea > 0)
            {
                num1 = 2; num2 =5;
            }
            else {
                if(towerspawner.towerlist[2].ea == 0)
                {
                    warningnum = 2;
                }
                else
                {
                    warningnum = 5;
                }
                warning(warningnum);
                return; 
            }
        }
        else if(rare == 12)
        {
            if (towerspawner.towerlist[1].ea > 0 && towerspawner.towerlist[8].ea > 0)
            {
                num1 = 1; num2 = 8;
            }
            else
            {
                if (towerspawner.towerlist[1].ea == 0)
                {
                    warningnum = 1;
                }
                else
                {
                    warningnum = 8;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 13)
        {
            if (towerspawner.towerlist[3].ea > 1)
            {
                num1 = 3; num2 = 3;
            }
            else { warning(3); return; }
        }
        else if(rare == 14)
        {
            if (towerspawner.towerlist[4].ea > 1)
            {
                num1 = 4; num2 = 4;
            }
            else { warning(4); return; }
        }
        else if(rare == 15)
        {
            if (towerspawner.towerlist[5].ea > 0 && towerspawner.towerlist[0].ea > 0)
            {
                num1 = 0; num2 = 5;
            }
            else
            {
                if (towerspawner.towerlist[0].ea == 0)
                {
                    warningnum = 0;
                }
                else
                {
                    warningnum = 5;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 16)
        {
            if (towerspawner.towerlist[4].ea > 0 && towerspawner.towerlist[7].ea > 0)
            {
                num1 = 4; num2 = 7;
            }
            else
            {
                if (towerspawner.towerlist[4].ea == 0)
                {
                    warningnum = 4;
                }
                else
                {
                    warningnum = 7;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 17)
        {
            if (towerspawner.towerlist[6].ea > 1)
            {
                num1 = 6; num2 = 6;
            }
            else { warning(6); return; }
        }
        else if(rare == 18)
        {
            if ( towerspawner.towerlist[8].ea > 0 && towerspawner.towerlist[2].ea > 0)
            {
                num1 = 8; num2 = 2;
            }
            else
            {
                if (towerspawner.towerlist[2].ea == 0)
                {
                    warningnum = 2;
                }
                else
                {
                    warningnum = 8;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 19)
        {
            if (towerspawner.towerlist[6].ea > 0 && towerspawner.towerlist[3].ea > 0)
            {
                num1 = 6; num2 = 3;
            }
            else
            {
                if (towerspawner.towerlist[6].ea == 0)
                {
                    warningnum = 6;
                }
                else
                {
                    warningnum = 3;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 20)
        {
            if (towerspawner.towerlist[7].ea > 1)
            {
                num1 = 7; num2 = 7;
            }
            else { warning(7); return; }
        }
        else if(rare == 21)
        {
            if (towerspawner.towerlist[9].ea > 0 && towerspawner.towerlist[15].ea > 0)
            {
                num1 = 9; num2 = 15;
            }
            else
            {
                if (towerspawner.towerlist[9].ea == 0)
                {
                    warningnum = 9;
                }
                else
                {
                    warningnum = 15;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 22)
        {
            if (towerspawner.towerlist[11].ea > 0 && towerspawner.towerlist[18].ea > 0)
            {
                num1 = 11; num2 = 18;
            }
            else
            {
                if (towerspawner.towerlist[11].ea == 0)
                {
                    warningnum = 11;
                }
                else
                {
                    warningnum = 18;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 23)
        {
            if (towerspawner.towerlist[10].ea > 0 && towerspawner.towerlist[12].ea > 0)
            {
                num1 = 10; num2 = 12;
            }
            else
            {
                if (towerspawner.towerlist[10].ea == 0)
                {
                    warningnum = 10;
                }
                else
                {
                    warningnum = 12;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 24)
        {
            if (towerspawner.towerlist[12].ea > 0 && towerspawner.towerlist[20].ea > 0)
            {
                num1 = 12; num2 = 20;
            }
            else
            {
                if (towerspawner.towerlist[12].ea == 0)
                {
                    warningnum = 12;
                }
                else
                {
                    warningnum = 20;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 25)
        {
            if (towerspawner.towerlist[11].ea > 0 && towerspawner.towerlist[10].ea > 0)
            {
                num1 = 11; num2 = 10;
            }
            else
            {
                if (towerspawner.towerlist[11].ea == 0)
                {
                    warningnum = 11;
                }
                else
                {
                    warningnum = 10;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 26)
        {
            if (towerspawner.towerlist[13].ea > 0 && towerspawner.towerlist[19].ea > 0)
            {
                num1 = 13; num2 = 19;
            }
            else
            {
                if (towerspawner.towerlist[13].ea == 0)
                {
                    warningnum = 13;
                }
                else
                {
                    warningnum = 19;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 27)
        {
            if (towerspawner.towerlist[14].ea > 0 && towerspawner.towerlist[16].ea > 0)
            {
                num1 = 14; num2 = 16;
            }
            else
            {
                if (towerspawner.towerlist[14].ea == 0)
                {
                    warningnum = 14;
                }
                else
                {
                    warningnum = 16;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 28)
        {
            if (towerspawner.towerlist[15].ea > 0 && towerspawner.towerlist[11].ea > 0)
            {
                num1 = 15; num2 = 11;
            }
            else
            {
                if (towerspawner.towerlist[15].ea == 0)
                {
                    warningnum = 15;
                }
                else
                {
                    warningnum = 11;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 29)
        {
            if (towerspawner.towerlist[16].ea > 0 && towerspawner.towerlist[13].ea > 0)
            {
                num1 = 16; num2 = 13;
            }
            else
            {
                if (towerspawner.towerlist[16].ea == 0)
                {
                    warningnum = 16;
                }
                else
                {
                    warningnum = 13;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 30)
        {
            if (towerspawner.towerlist[15].ea > 0 && towerspawner.towerlist[14].ea > 0)
            {
                num1 = 15; num2 = 14;
            }
            else
            {
                if (towerspawner.towerlist[15].ea == 0)
                {
                    warningnum = 15;
                }
                else
                {
                    warningnum = 14;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 31)
        {
            if (towerspawner.towerlist[18].ea > 0 && towerspawner.towerlist[9].ea > 0)
            {
                num1 = 18; num2 = 9;
            }
            else
            {
                if (towerspawner.towerlist[18].ea == 0)
                {
                    warningnum = 18;
                }
                else
                {
                    warningnum = 9;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 32)
        {
            if (towerspawner.towerlist[18].ea > 0 && towerspawner.towerlist[12].ea > 0)
            {
                num1 = 18; num2 = 12;
            }
            else
            {
                if (towerspawner.towerlist[18].ea == 0)
                {
                    warningnum = 18;
                }
                else
                {
                    warningnum = 12;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 33)
        {
            if (towerspawner.towerlist[19].ea > 0 && towerspawner.towerlist[17].ea > 0)
            {
                num1 = 19; num2 = 17;
            }
            else
            {
                if (towerspawner.towerlist[19].ea == 0)
                {
                    warningnum = 19;
                }
                else
                {
                    warningnum = 17;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 34)
        {
            if (towerspawner.towerlist[17].ea > 0 && towerspawner.towerlist[19].ea > 0)
            {
                num1 = 17; num2 = 19;
            }
            else
            {
                if (towerspawner.towerlist[19].ea == 0)
                {
                    warningnum = 19;
                }
                else
                {
                    warningnum = 17;
                }
                warning(warningnum);
                return;
            }
        }
        else if(rare == 35)
        {
            if (towerspawner.towerlist[20].ea > 0 && towerspawner.towerlist[16].ea > 0)
            {
                num1 = 20; num2 = 16;
            }
            else
            {
                if (towerspawner.towerlist[20].ea == 0)
                {
                    warningnum = 20;
                }
                else
                {
                    warningnum = 16;
                }
                warning(warningnum);
                return;
            }
        }
        towerspawner.createspawn(rare, num1,num2);
    }
}
