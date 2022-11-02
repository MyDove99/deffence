using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilderPositionAutoSetter : MonoBehaviour
{
    [SerializeField]
    private Vector3 distance = Vector3.up * 20.0f;
    private Transform targetTransform;
    private RectTransform rectTransform;

    public void Setup(Transform target)
    {
        targetTransform = target; //����ٴ� Ÿ�� ���� 
        rectTransform = GetComponent<RectTransform>(); // RectTransform�� ���� ��������
    }

    private void LateUpdate()
    {
        if (targetTransform == null)
        {
            Destroy(gameObject);
            return;
            //Ÿ���� ������� ���� �����
        }
        Vector3 screenPosition = targetTransform.position;
        //������Ʈ�� ���� ��ǥ�� �������� ȭ�鿡���� ��ǥ���� ������
        rectTransform.position = screenPosition + distance;
        //ȭ�鳻���� ��ǥ + distance��ŭ ������ ��ġ�� Slider UI��ġ�� ����
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
