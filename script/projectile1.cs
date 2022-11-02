using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile1 : MonoBehaviour
{
    private enemymoving enemymoving;
    private Transform target;
    private float damage;
    [SerializeField]
    private int skill; // 0 이면 평타 1이면 스킬

    public void Setup(Transform target,float damage)
    {
        enemymoving = GetComponent<enemymoving>();
        this.target = target;
        this.damage = damage;
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

        //collision.GetComponent<enemy>().OnDie(); //적 사망 함수 호출
        collision.GetComponent<enemyhp01>().TakeDamage(damage,skill);
        Destroy(gameObject); //발사체 오브젝트 삭제
    }
}
