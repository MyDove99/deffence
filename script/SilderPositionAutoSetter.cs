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
        targetTransform = target; //따라다닐 타겟 설정 
        rectTransform = GetComponent<RectTransform>(); // RectTransform의 정보 가저오기
    }

    private void LateUpdate()
    {
        if (targetTransform == null)
        {
            Destroy(gameObject);
            return;
            //타겟이 사라지면 같이 사라짐
        }
        Vector3 screenPosition = targetTransform.position;
        //오브젝트의 월드 좌표를 기준으로 화면에서의 좌표값으 ㄹ구함
        rectTransform.position = screenPosition + distance;
        //화면내에서 좌표 + distance만큼 떨어진 위치를 Slider UI위치로 설정
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
