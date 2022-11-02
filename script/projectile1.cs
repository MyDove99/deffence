using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile1 : MonoBehaviour
{
    private enemymoving enemymoving;
    private Transform target;
    private float damage;
    [SerializeField]
    private int skill; // 0 �̸� ��Ÿ 1�̸� ��ų

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

        //collision.GetComponent<enemy>().OnDie(); //�� ��� �Լ� ȣ��
        collision.GetComponent<enemyhp01>().TakeDamage(damage,skill);
        Destroy(gameObject); //�߻�ü ������Ʈ ����
    }
}
