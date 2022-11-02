using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy : MonoBehaviour
{
    private int waypointcount; //이동경로 개수
    private Transform[] waypoints; //이동경로 정보
    private int currentIndex = 0; //현재 목표지점 인덱스 
    private enemymoving movement2D; //오브젝트 이동 제어
    private enemyspawner enemyspawner; //적의 삭제를 enemyspawner에서 삭제
    // Start is called before the first frame update

    public void Setup (enemyspawner enemyspawner, Transform[] waypoints)
    {
        movement2D = GetComponent<enemymoving>();
        this.enemyspawner = enemyspawner;

        waypointcount = waypoints.Length;
        this.waypoints = new Transform[waypointcount];
        this.waypoints = waypoints;
        //적 이동 경로 waypoins 정보 설정

        transform.position = waypoints[currentIndex].position;
        // 적의 위치를 첫번째 waypoint 위치로 설정

        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        NextMoveTo(); // 다음 이동 방향 설정

        while (true)
        {

            if(Vector3.Distance(transform.position,waypoints[currentIndex].position)<0.02f * movement2D.MoveSpeed)
            {
                NextMoveTo();
                //다음 이동 방향 설정
            }
            // 적의 현재위치와 목표위치의 거리가 0.02f * movement2d.movespeed보다 작을때 if문 실행
            // if문에 안걸리는 오브젝트가 발생 가능
            yield return null;
        }
    }

    private void NextMoveTo()
    {
        if(currentIndex<waypointcount - 1) // 이동할 waypoints가 남아있다면
        {
            transform.position = waypoints[currentIndex].position;
            //적의 위치를 정확하게 목표위치로 설정
            currentIndex++;
            Vector3 direcion = (waypoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direcion);
            // 이동 방향 설정 => 다음 목표지점(waypoints)
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
        //enemyspawner에서 리스트로 적 정보를 관리하기 때문에
        //enemyspawner에게 본인이 삭제될 때 필요한 처리를 하도록 destroy함수 호출
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
