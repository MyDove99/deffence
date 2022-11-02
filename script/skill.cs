using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class skill : MonoBehaviour
{
    [SerializeField] public int skillnum;
    [SerializeField] public towerweapon towerweapon;
    [SerializeField] private GameObject skillPrefab; //��ų ������
    [SerializeField] private int skillDmg;
    [SerializeField] private Vector2 Range; // ������ �Ÿ�
    [SerializeField] private int slow; //�̵��ӵ� ���ҷ�
    [SerializeField] private int stun; //���Ͻ�ų ���� (���� x 0 , ���� 1)
    [SerializeField] private int slowtime; //�̵��ӵ� ���� �ð�
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
            case 1: //���� ��
                skill1();
                break;
            case 2: //���� ��
                skill2();
                break;
            case 3://���� �̰�
                skill3();
                break;
            case 4://���� �̰�
                skill4();
                break;
        }
    }
    private void skill1()
    {
        GameObject clone = Instantiate(skillPrefab,towerweapon.spawnPoint.position, Quaternion.identity);
        clone.GetComponent<projectile1>().Setup(target, skillDmg);
        //������ �߻�ü���� ���ݴ�� ���� ����
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
        //������ �߻�ü���� ���ݴ�� ���� ����
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