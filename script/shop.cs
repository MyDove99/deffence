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
        if (subject == 0) // �⺻����
        {
            int rare = 0;
            if (goldprice > gold.Currentgold)
            {
                notice.warning("!��尡 �����մϴ�!");
                return;
            }
            if (gold.Currentsilver > 0)
            { gold.Currentsilver -= silverprice; rare = 1; }
            else
            { gold.Currentgold -= goldprice; rare = 0; }
            towerspawner.SpawnTower(rare);
        }else if(subject == 1) // �ϵ�
        {
            if(treeprice > gold.currenttree){ notice.warning("!������ �����մϴ�!"); return; }
            else
            {
                if (random < 91)
                {
                    gold.currenttree -= treeprice;
                    towerspawner.SpawnTower(0);
                }
                else { notice.warning("!���� ����!"); return; }
            }
        } else if (subject == 2)// �ߵ�
        {
            if (treeprice > gold.currenttree) { notice.warning("!������ �����մϴ�!"); return; }
            else
            {
                if (random < 71)
                {
                    gold.currenttree -= treeprice;
                    towerspawner.SpawnTower(1);
                }
                else { notice.warning("!���� ����!"); return; }
            }
        } else if (subject == 3) // ��
        {
            if (treeprice > gold.currenttree) { notice.warning("!������ �����մϴ�!"); return; }
            else
            {
                if (random < 51)
                {
                    gold.currenttree -= treeprice;
                    towerspawner.SpawnTower(2);
                }
                else { notice.warning("!���� ����!"); return; }
            }
        } else if (subject == 4) // ���� ����
        {
            if (treeprice > gold.currenttree && goldprice > gold.Currentgold) { return; }
            else
            {
                gold.Currentgold -= goldprice;
                gold.currenttree -= treeprice;
                gold.currentkey = gold.currentkey + 1;
            }
        } else if (subject == 5) // ���� �̱�
        {
            if (treeprice > gold.currentcrystal ) { notice.warning("!ũ����Ż�� �����մϴ�!"); return; }
            else
            {
                gold.currentcrystal -= treeprice;
                towerspawner.SpawnTower(3);
            }
        } else if (subject == 6) // Ű ���
        {
            if (treeprice > gold.currentkey) { notice.warning("!���谡 �����մϴ�!"); return; }
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
