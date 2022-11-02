using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class towerspawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] notowerPrefab;
    [SerializeField]
    private GameObject[] ratowerPrefab;
    [SerializeField]
    private GameObject[] uniquePrefab;
    [SerializeField]
    private GameObject[] epicPrefab;
    [SerializeField]
    private enemyspawner enemyspawner; //현재 맵에 존재하는 적 리스트 정보를 얻음
    [SerializeField]
    private int towerBuildGold = 1;
    [SerializeField]
    private gold playerGold;
    public tower[] towerlist; // 타워 객체 리스트
    public tile[] tilelist = new tile[52]; // 타워 객체 리스트
    public GameObject selecttower; //선택한 타워 정보
    private notice notice;
    public void unitspawn(int rare,int num) // rare은 0=노말 1=레어 2=유니크 3=에픽 / 타워 번호
    {
        GameObject clone1 =  null;
        Vector3 pos = new Vector3(0,0);
        string name = towerlist[num].name;
        for (int i = 0; i < tilelist.Length; i++)
        {
            if (tilelist[i].towername == "")
            {
                tilelist[i].towername = name;
                pos = tilelist[i].tiletransform;
                if (rare == 0)
                {
                    clone1 = Instantiate(notowerPrefab[num], pos, Quaternion.identity);
                }
                else if (rare == 1)
                {
                    clone1 = Instantiate(ratowerPrefab[num - notowerPrefab.Length], pos, Quaternion.identity);
                }
                else if (rare == 2)
                {
                    clone1 = Instantiate(uniquePrefab[num - ratowerPrefab.Length - notowerPrefab.Length], pos, Quaternion.identity);
                }
                else if (rare == 3)
                {
                    clone1 = Instantiate(uniquePrefab[num - ratowerPrefab.Length - notowerPrefab.Length - uniquePrefab.Length], pos, Quaternion.identity);
                }
                clone1.GetComponent<towerweapon>().Setup(enemyspawner);
                tilelist[i].tower = clone1;
                towerlist[num].ea += 1;
                break;
            }
        }
        notice.textadd(name + "가 생성되었습니다.");
    }
    public void createdelete(int num1, int num2)
    {
        for (int i=0; i<tilelist.Length; i++)
        {
            if (towerlist[num1].name == tilelist[i].towername)
            {
                tilelist[i].towername = "";
                Destroy(tilelist[i].tower);
                tilelist[i].tower = null;
                towerlist[num1].ea -= 1;
                break;
            }
        }
        for (int i = 0; i < tilelist.Length; i++)
        {
            if (towerlist[num2].name == tilelist[i].towername)
            {
                tilelist[i].towername = "";
                Destroy(tilelist[i].tower);
                tilelist[i].tower = null;
                towerlist[num2].ea -= 1;
                break;
            }
        }
    }
    public void SpawnTower(int rare)
    {
        int towernum = 0;
        if (rare == 1)
        {
            towernum = Random.Range(9, 21);
            unitspawn(1, towernum);
        } else if(rare == 0)
        {
            towernum = Random.Range(0, 9);
            unitspawn(0, towernum);
        } else if (rare == 2)
        {
            towernum = Random.Range(21, 36);
            unitspawn(2, towernum);
        } else if (rare == 3)
        {
            towernum = Random.Range(36, 54);
            unitspawn(3, towernum);
        }
    }
    public void createspawn(int num,int num1,int num2)
    {
        int rare = 0;
        createdelete(num1,num2);
        if (notowerPrefab.Length <= num) { rare = 1; }
        else if(notowerPrefab.Length + ratowerPrefab.Length <= num) { rare = 2; }
        unitspawn(rare, num);
    }
    public void Sell()
    {
        for (int i = 0; i < towerlist.Length; i++)
        {
            if(selecttower.name == towerlist[i].name)
            {
                int sell = Random.Range(1, 101);
                if (selecttower.tag == "nomaltower")
                {
                    if (sell < 70)
                    {
                        playerGold.Currentgold += 1;
                    }
                } else if (selecttower.tag == "raretower")
                {
                    if (sell < 60)
                    {
                        playerGold.Currentgold += 2;
                    }
                } else if (selecttower.tag == "unique")
                {
                    if (sell < 50)
                    {
                        playerGold.Currentgold += 1;
                    }
                }else if (selecttower.tag == "epic")
                {
                    if (sell < 40)
                    {
                        playerGold.Currentgold += 2;
                    }
                }
                Destroy(selecttower);
            }
        }
    }
    public class tower {
        public string name;
        public int ea;
        public tower(string name, int ea)
        {
            this.name = name;
            this.ea = ea;
        }
    }
    public class tile
    {
        public int tilenum;
        public string towername;
        public Vector3 tiletransform;
        public GameObject tower;
        public tile(int num,string name,Vector3 transform,GameObject tower)
        {
            this.tilenum = num;
            this.towername = name;
            this.tiletransform = transform;
            this.tower = tower;
        }
    }
    public void Start()
    {
        int r= 0,u=0,e=0;
        towerlist = new tower[notowerPrefab.Length + ratowerPrefab.Length + uniquePrefab.Length + epicPrefab.Length];
        for(int i=0; i<towerlist.Length; i++)
        {
            if(i < notowerPrefab.Length) 
            {
                towerlist[i] = new tower(notowerPrefab[i].name, 0);
            }else if (i < notowerPrefab.Length + ratowerPrefab.Length)
            {
                towerlist[i] = new tower(ratowerPrefab[r].name, 0);
                r++;
            }
            else if (i < notowerPrefab.Length + ratowerPrefab.Length + uniquePrefab.Length)
            {
                towerlist[i] = new tower(uniquePrefab[u].name, 0);
                u++;
            }
            else if (i < notowerPrefab.Length + ratowerPrefab.Length + uniquePrefab.Length + epicPrefab.Length)
            {
                towerlist[i] = new tower(epicPrefab[e].name, 0);
                e++;
            }
        }
        for (int i = 0; i < tilelist.Length; i++)
        {
            tilelist[i] = new tile(i,"", GameObject.Find("tilewall " + (i + 1)).transform.position,null);
        }
        notice = GameObject.Find("noticeImage").GetComponent<notice>();
    }
}