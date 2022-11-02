using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile2 : MonoBehaviour
{
    private enemymoving enemymoving;
    private Transform target;
    private int damage;
    [SerializeField]
    private int skill; // 0 �̸� ��Ÿ 1�̸� ��ų
    private int slow; //�� ��ų�� �̵��ӵ� ���ҷ�
    private int slowtime; // ��ų�� ���� �ð�
    private string active = ""; //�ߵ���

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
            //�߻�ü�� target��ġ�� �̵�
        }
        else
        {
            Destroy(gameObject); // �߻�ü ������Ʈ ����
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("enemy")) return; //���� �ƴ� ���� �ε�����
        if (collision.transform != target) return; //���� target�� ���� �ƴҶ�
        target.gameObject.GetComponent<enemymoving>().slowlist(slow,slowtime,active);
        collision.GetComponent<enemyhp01>().TakeDamage(damage,skill);
        Destroy(gameObject); //�߻�ü ������Ʈ ����
    }
}
