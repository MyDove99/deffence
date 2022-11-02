using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState { SearchTarget = 0, AttackToTarget}

public class towerweapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab; //�߻�ü ������
    [SerializeField]
    public Transform spawnPoint; //�߻�ü ���� ��ġ
    [SerializeField]
    public float attackRate = 0.5f; //���ݼӵ�
    [SerializeField]
    public float attackRange = 2.0f; // ���ݹ���
    [SerializeField]
    public float attackDamage = 1;
    private float bassRate = 0;
    private float bassDamage = 0;
    [SerializeField]
    public skill skill;
    [SerializeField]
    private bool skillon; //ture �� ���� false�� ����
    [SerializeField]
    private int skillper; //��ų �ۼ�Ʈ
    [SerializeField]
    public bufflist[] towerlist = new bufflist[60];
    private WeaponState weaponState = WeaponState.SearchTarget; //Ÿ�� ������ ����
    public Transform attackTarget = null; //���� ���
    private enemyspawner enemyspawner; //���ӿ� �����ϴ� �� ���� ȹ���

    public void Setup(enemyspawner enemyspawner)
    {
        this.enemyspawner = enemyspawner;
        ChangeState(WeaponState.SearchTarget);
        //���� ���¸� WeaponState.SearchTarget���� ����
    }

    public void ChangeState(WeaponState newState)
    {
        StopCoroutine(weaponState.ToString());
        //������ ������̴� ���� ����
        weaponState = newState;
        //���º���
        StartCoroutine(weaponState.ToString());
        //���ο� ���� ���
    }

    private void Update()
    {

    }
    private void Start()
    {
        bassDamage = attackDamage; 
        bassRate = attackRate;
        clear();
    }

    private void RotateToTarget()
    {
        float dx = attackTarget.position.x - transform.position.x;
        float dy = attackTarget.position.y - transform.position.y;
        //�������κ����� �Ÿ��� ���������κ����� ������ �̿��� ��ġ�� ���ϴ� �� ��ǥ�� �̿�
        //x,y ������ ���ϱ�
        float degree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, degree);
        //x,y �������� �������� ���� ���ϱ�
        //������ radian �����̱� ������ Mathf.Rad2Deg �� ���� �� ������ ����
    }
    private IEnumerator SearchTarget()
    {
        while (true)
        {
            float closertDistSqr = Mathf.Infinity;
            //���� ������ �ִ� ���� ã������ ���� �Ÿ��� �ִ��� ũ�� ����
            for (int i = 0; i < enemyspawner.enemyList.Count; i++)
            {
                float distance = Vector3.Distance(enemyspawner.enemyList[i].transform.position, transform.position);
                if (distance <= attackRange && distance <= closertDistSqr)
                {
                    closertDistSqr = distance;
                    attackTarget = enemyspawner.enemyList[i].transform;
                }
            }
            if (attackTarget != null)
            {
                ChangeState(WeaponState.AttackToTarget);
            }
            yield return null;
        }
    }
    private IEnumerator AttackToTarget()
    {
        float distance = Vector3.Distance(attackTarget.position, transform.position);
        while (true)
        {
            if (attackTarget == null)//target�� �ִ��� �˻�
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            else if (distance > attackRange) //target�� ���ݹ����� �ִ��� �˻�
            {
                attackTarget = null;
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            else
            {
                if (skillon == true)
                {
                    int random = Random.Range(1, 101);
                    if (random <= skillper)
                    {
                        skill.skillon();
                    }
                    else
                    {
                        spawnProjectile();
                    }
                } else
                {
                    spawnProjectile();
                }
            }
            yield return new WaitForSeconds(attackRate);
        }
    }
    private void spawnProjectile()
    {
        GameObject clone = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<projectile1>().Setup(attackTarget, attackDamage);
        //������ �߻�ü���� ���ݴ�� ���� ����
    }
    public void buffOn(int check)
    {
        float temp1 = 0;
        float temp2 = 0;
        foreach(bufflist i in towerlist)
        {
             if(i.op == 0)
            {
                temp1 = temp1 + i.buff;
            }else if (i.op == 1)
            {
                temp2 = temp2 + i.buff;
            }
        }
        if(check == 0)
        {
            attackRate = bassRate - (bassRate*(temp1 / 100));
        }else if(check == 1)
        {
            attackDamage = bassDamage + (bassDamage * (temp2 / 100));
        }
    }
    public class bufflist
    {
        public string name;
        public float buff;
        public int op; // 0�̸� ���� 1�̸� ���ݷ�
        public bufflist(string name, float buff,int op)
        {
            this.name = name;
            this.buff = buff;
            this.op = op;
        }
    }
    public void clear()
    {
        for (int i = 0; i < towerlist.Length; i++)
        {
            towerlist[i] = new bufflist("", 0, 0);
        }
    }
}
