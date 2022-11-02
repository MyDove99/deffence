using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState { SearchTarget = 0, AttackToTarget}

public class towerweapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab; //발사체 프리팹
    [SerializeField]
    public Transform spawnPoint; //발사체 생성 위치
    [SerializeField]
    public float attackRate = 0.5f; //공격속도
    [SerializeField]
    public float attackRange = 2.0f; // 공격범위
    [SerializeField]
    public float attackDamage = 1;
    private float bassRate = 0;
    private float bassDamage = 0;
    [SerializeField]
    public skill skill;
    [SerializeField]
    private bool skillon; //ture 면 있음 false면 없음
    [SerializeField]
    private int skillper; //스킬 퍼센트
    [SerializeField]
    public bufflist[] towerlist = new bufflist[60];
    private WeaponState weaponState = WeaponState.SearchTarget; //타워 무기의 상태
    public Transform attackTarget = null; //공격 대상
    private enemyspawner enemyspawner; //게임에 존재하는 적 정보 획득용

    public void Setup(enemyspawner enemyspawner)
    {
        this.enemyspawner = enemyspawner;
        ChangeState(WeaponState.SearchTarget);
        //최초 상태를 WeaponState.SearchTarget으로 설정
    }

    public void ChangeState(WeaponState newState)
    {
        StopCoroutine(weaponState.ToString());
        //이전에 재생중이던 상태 종료
        weaponState = newState;
        //상태변경
        StartCoroutine(weaponState.ToString());
        //새로운 상태 재생
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
        //원점으로부터의 거리와 수평축으로부터의 각도를 이용해 위치를 구하는 극 좌표계 이용
        //x,y 변위값 구하기
        float degree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, degree);
        //x,y 변위값을 바탕으로 각도 구하기
        //각도가 radian 단위이기 때문에 Mathf.Rad2Deg 를 곱해 도 단위를 구함
    }
    private IEnumerator SearchTarget()
    {
        while (true)
        {
            float closertDistSqr = Mathf.Infinity;
            //제일 가까이 있는 적을 찾기위해 최초 거리를 최대한 크게 설정
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
            if (attackTarget == null)//target이 있는지 검사
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            else if (distance > attackRange) //target이 공격범위에 있는지 검사
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
        //생성된 발사체에게 공격대상 정보 제공
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
        public int op; // 0이면 공속 1이면 공격력
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
