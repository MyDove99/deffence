using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class shop : MonoBehaviour
{
    [SerializeField] private gold gold;
    [SerializeField] private towerspawner towerspawner;
    public int goldprice;
    public int silverprice;
    public int treeprice;
    [SerializeField] private int subject;
    [SerializeField] private int towernum;
    private notice notice;
    public void OnMouseDown()
    {
        int random = Random.Range(1, 101);
        if (subject == 0) // 기본구입
        {
            int rare = 0;
            if (goldprice > gold.Currentgold)
            {
                notice.warning("!골드가 부족합니다!");
                return;
            }
            if (gold.Currentsilver > 0)
            { gold.Currentsilver -= silverprice; rare = 1; }
            else
            { gold.Currentgold -= goldprice; rare = 0; }
            towerspawner.SpawnTower(rare);
        }else if(subject == 1) // 하도
        {
            if(treeprice > gold.currenttree){ notice.warning("!나무가 부족합니다!"); return; }
            else
            {
                if (random < 91)
                {
                    gold.currenttree -= treeprice;
                    towerspawner.SpawnTower(0);
                }
                else { notice.warning("!도박 실패!"); return; }
            }
        } else if (subject == 2)// 중도
        {
            if (treeprice > gold.currenttree) { notice.warning("!나무가 부족합니다!"); return; }
            else
            {
                if (random < 71)
                {
                    gold.currenttree -= treeprice;
                    towerspawner.SpawnTower(1);
                }
                else { notice.warning("!도박 실패!"); return; }
            }
        } else if (subject == 3) // 고도
        {
            if (treeprice > gold.currenttree) { notice.warning("!나무가 부족합니다!"); return; }
            else
            {
                if (random < 51)
                {
                    gold.currenttree -= treeprice;
                    towerspawner.SpawnTower(2);
                }
                else { notice.warning("!도박 실패!"); return; }
            }
        } else if (subject == 4) // 열쇠 구매
        {
            if (treeprice > gold.currenttree && goldprice > gold.Currentgold) { return; }
            else
            {
                gold.Currentgold -= goldprice;
                gold.currenttree -= treeprice;
                gold.currentkey = gold.currentkey + 1;
            }
        } else if (subject == 5) // 히든 뽑기
        {
            if (treeprice > gold.currentcrystal ) { notice.warning("!크리스탈이 부족합니다!"); return; }
            else
            {
                gold.currentcrystal -= treeprice;
                towerspawner.SpawnTower(3);
            }
        } else if (subject == 6) // 키 사용
        {
            if (treeprice > gold.currentkey) { notice.warning("!열쇠가 부족합니다!"); return; }
            else
            {
                gold.currentkey -= treeprice;
                towerspawner.unitspawn(0,towernum);
            }
        }
    }
    private void Start()
    {
        notice = GameObject.Find("noticeImage").GetComponent<notice>();
    }
    void Update()
    {
        
    }
}
