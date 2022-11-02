using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile2 : MonoBehaviour
{
    private enemymoving enemymoving;
    private Transform target;
    private int damage;
    [SerializeField]
    private int skill; // 0 이면 평타 1이면 스킬
    private int slow; //이 스킬의 이동속도 감소량
    private int slowtime; // 스킬의 감소 시간
    private string active = ""; //발동자

    public void Setup(Transform target,int damage,int slow,int slowtime,string active)
    {
        enemymoving = GetComponent<enemymoving>();
        this.target = target;
        this.damage = damage;
        this.slow = slow;
        this.slowtime = slowtime;
        this.active = active;
    }

    // Update is called once per frame
    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            enemymoving.MoveTo(direction);
            //발사체를 target위치로 이동
        }
        else
        {
            Destroy(gameObject); // 발사체 오브젝트 삭제
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("enemy")) return; //적이 아닌 대상과 부딪히면
        if (collision.transform != target) return; //현재 target인 적이 아닐때
        target.gameObject.GetComponent<enemymoving>().slowlist(slow,slowtime,active);
        collision.GetComponent<enemyhp01>().TakeDamage(damage,skill);
        Destroy(gameObject); //발사체 오브젝트 삭제
    }
}
