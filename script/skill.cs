using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class skill : MonoBehaviour
{
    [SerializeField] public int skillnum;
    [SerializeField] public towerweapon towerweapon;
    [SerializeField] private GameObject skillPrefab; //스킬 프리팹
    [SerializeField] private int skillDmg;
    [SerializeField] private Vector2 Range; // 범위기 거리
    [SerializeField] private int slow; //이동속도 감소량
    [SerializeField] private int stun; //스턴스킬 여부 (기절 x 0 , 기절 1)
    [SerializeField] private int slowtime; //이동속도 감소 시간
    public LayerMask whatIsLayer;
    Transform target;
    Transform[] targetlist = new Transform[60];
    string active;
    public void skillon()
    {
        active = this.gameObject.name;
        target = towerweapon.attackTarget;
        switch (skillnum)
        {
            case 1: //단일 딜
                skill1();
                break;
            case 2: //광역 딜
                skill2();
                break;
            case 3://단일 이감
                skill3();
                break;
            case 4://광역 이감
                skill4();
                break;
        }
    }
    private void skill1()
    {
        GameObject clone = Instantiate(skillPrefab,towerweapon.spawnPoint.position, Quaternion.identity);
        clone.GetComponent<projectile1>().Setup(target, skillDmg);
        //생성된 발사체에게 공격대상 정보 제공
    }
    private void skill2()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(target.transform.position, Range, 0, whatIsLayer);
        for (int i = 0; i < hit.Length; ++i)
        {
            targetlist[i] = hit[i].gameObject.transform;
        }
        foreach(Transform enemy in targetlist)
        {
            if(enemy == null)
            {
                break;
            }
            else
            {
                GameObject clone = Instantiate(skillPrefab, towerweapon.spawnPoint.position, Quaternion.identity);
                clone.GetComponent<projectile1>().Setup(enemy, skillDmg);
            }
        }
    }
    private void skill3()
    {
        GameObject clone = Instantiate(skillPrefab, towerweapon.spawnPoint.position, Quaternion.identity);
        clone.GetComponent<projectile2>().Setup(target, skillDmg,slow,slowtime,active);
        //생성된 발사체에게 공격대상 정보 제공
    }
    private void skill4()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(target.transform.position, Range, 0, whatIsLayer);
        for (int i = 0; i < hit.Length; ++i)
        {
            targetlist[i] = hit[i].gameObject.transform;
        }
        foreach (Transform enemy in targetlist)
        {
            if (enemy == null)
            {
                break;
            }
            else
            {
                GameObject clone = Instantiate(skillPrefab, towerweapon.spawnPoint.position, Quaternion.identity);
                clone.GetComponent<projectile2>().Setup(enemy, skillDmg,slow,slowtime,active);
            }
        }
    }
}