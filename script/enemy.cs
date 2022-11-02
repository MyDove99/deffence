using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy : MonoBehaviour
{
    private int waypointcount; //�̵���� ����
    private Transform[] waypoints; //�̵���� ����
    private int currentIndex = 0; //���� ��ǥ���� �ε��� 
    private enemymoving movement2D; //������Ʈ �̵� ����
    private enemyspawner enemyspawner; //���� ������ enemyspawner���� ����
    // Start is called before the first frame update

    public void Setup (enemyspawner enemyspawner, Transform[] waypoints)
    {
        movement2D = GetComponent<enemymoving>();
        this.enemyspawner = enemyspawner;

        waypointcount = waypoints.Length;
        this.waypoints = new Transform[waypointcount];
        this.waypoints = waypoints;
        //�� �̵� ��� waypoins ���� ����

        transform.position = waypoints[currentIndex].position;
        // ���� ��ġ�� ù��° waypoint ��ġ�� ����

        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        NextMoveTo(); // ���� �̵� ���� ����

        while (true)
        {

            if(Vector3.Distance(transform.position,waypoints[currentIndex].position)<0.02f * movement2D.MoveSpeed)
            {
                NextMoveTo();
                //���� �̵� ���� ����
            }
            // ���� ������ġ�� ��ǥ��ġ�� �Ÿ��� 0.02f * movement2d.movespeed���� ������ if�� ����
            // if���� �Ȱɸ��� ������Ʈ�� �߻� ����
            yield return null;
        }
    }

    private void NextMoveTo()
    {
        if(currentIndex<waypointcount - 1) // �̵��� waypoints�� �����ִٸ�
        {
            transform.position = waypoints[currentIndex].position;
            //���� ��ġ�� ��Ȯ�ϰ� ��ǥ��ġ�� ����
            currentIndex++;
            Vector3 direcion = (waypoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direcion);
            // �̵� ���� ���� => ���� ��ǥ����(waypoints)
        }
        else if(currentIndex == 3)
        {
            transform.position = waypoints[currentIndex].position;
            currentIndex = 0;
            Vector3 direcion = (waypoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direcion);
        }
        else
        {
            OnDie();
        }
    }
    public void OnDie()
    {
        enemyspawner.DestroyEnemy(this);
        //enemyspawner���� ����Ʈ�� �� ������ �����ϱ� ������
        //enemyspawner���� ������ ������ �� �ʿ��� ó���� �ϵ��� destroy�Լ� ȣ��
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
