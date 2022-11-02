using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passive : MonoBehaviour
{
    [SerializeField] public int skillnum = 0;
    [SerializeField] private float amorbreak = 0;
    [SerializeField] public int slow = 0;
    [SerializeField] private float buff = 0;
    public LayerMask enemylist;
    public LayerMask towerlist;
    private Vector2 Range = new Vector2(10000,10000);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (skillnum == 1) //전체 깍
        {
            Collider2D[] hit = Physics2D.OverlapBoxAll(this.transform.position, Range, 0, enemylist);
            for (int i = 0; i < hit.Length; ++i)
            {
                for (int j = 0; j < hit[i].gameObject.GetComponent<enemyhp01>().towerlists.Length; j++)
                {
                    if (hit[i].gameObject.GetComponent<enemyhp01>().towerlists[j].name == this.gameObject.name)
                    {
                        break;
                    }
                    else if (hit[i].gameObject.GetComponent<enemyhp01>().towerlists[j].name == "")
                    {
                        hit[i].gameObject.GetComponent<enemyhp01>().towerlists[j].name = this.gameObject.name;
                        hit[i].gameObject.GetComponent<enemyhp01>().towerlists[j].def = amorbreak;
                        hit[i].gameObject.GetComponent<enemyhp01>().amorbreak();
                        break;
                    }
                }
            }
        }else if(skillnum==3) // 공속증가
        {
            Collider2D[] hit = Physics2D.OverlapBoxAll(this.transform.position, Range, 0, towerlist);
            foreach(Collider2D i in hit)
            {
                for(int j=0; j<i.gameObject.GetComponent<towerweapon>().towerlist.Length; j++)
                {
                    if(i.gameObject.GetComponent<towerweapon>().towerlist[j].name == this.gameObject.name)
                    {
                        break;
                    }else if(i.gameObject.GetComponent<towerweapon>().towerlist[j].name == "")
                    {
                        i.gameObject.GetComponent<towerweapon>().towerlist[j].name = this.gameObject.name;
                        if (skillnum == 3) { i.gameObject.GetComponent<towerweapon>().towerlist[j].op = 0; } //공속
                        else if(skillnum ==4) { i.gameObject.GetComponent<towerweapon>().towerlist[j].op = 1; } //공격력
                        i.gameObject.GetComponent<towerweapon>().towerlist[j].buff = buff;
                        i.gameObject.GetComponent<towerweapon>().buffOn(0);
                        break;
                    }
                }
            }
        }
    }
    private void OnDestroy()
    {
        if(skillnum == 1)
        {
            Collider2D[] hit = Physics2D.OverlapBoxAll(this.transform.position, Range, 0, enemylist);
            for (int i = 0; i < hit.Length; ++i)
            {
                hit[i].gameObject.GetComponent<enemyhp01>().listdelete(this.gameObject.name);
            }
        }else if (skillnum == 2)
        {
            Collider2D[] hit = Physics2D.OverlapBoxAll(this.transform.position, Range, 0, enemylist);
            for (int i = 0; i < hit.Length; ++i)
            {
                hit[i].gameObject.GetComponent<enemymoving>().deletelist();
            }
        }
        else
        {
            Collider2D[] hit = Physics2D.OverlapBoxAll(this.transform.position, Range, 0, towerlist);
            foreach(Collider2D i in hit)
            {
                i.gameObject.GetComponent<towerweapon>().clear();
            }
        }
    }
}
