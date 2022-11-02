using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectdetector : MonoBehaviour
{
    [SerializeField]
    private towerspawner towerspawner;
    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        mainCamera = Camera.main;
        //메인카메라 태그를 가지고 있는 오브젝트 탐색 후 Camera 컴포넌트 정보 전달
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))//마우스 왼쪽 클릭
            {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            // 카메라 위치에서 화면의 마우스 위치를 관통하는 광선 생성
            if (Physics.Raycast(ray,out hit, Mathf.Infinity))
            //광선에 부딪히는 오브젝트를 검색해서 hit에 저장
            {
                if (hit.transform.CompareTag("tile"))
                //광선에 부딪히는 오브젝트가 tile이면
                {
                    /*towerspawner.SpawnTower(hit.transform);*/
                    //타워를 생성하는 spawntower() 호출
                }
            }
        }
    }
}
