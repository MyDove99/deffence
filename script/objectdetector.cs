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
        //����ī�޶� �±׸� ������ �ִ� ������Ʈ Ž�� �� Camera ������Ʈ ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))//���콺 ���� Ŭ��
            {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            // ī�޶� ��ġ���� ȭ���� ���콺 ��ġ�� �����ϴ� ���� ����
            if (Physics.Raycast(ray,out hit, Mathf.Infinity))
            //������ �ε����� ������Ʈ�� �˻��ؼ� hit�� ����
            {
                if (hit.transform.CompareTag("tile"))
                //������ �ε����� ������Ʈ�� tile�̸�
                {
                    /*towerspawner.SpawnTower(hit.transform);*/
                    //Ÿ���� �����ϴ� spawntower() ȣ��
                }
            }
        }
    }
}
