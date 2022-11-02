using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    // Start is called before the first frame update

    public bool IsBuildTower { set; get; }

    private void Awake()
    {
        IsBuildTower = false;
        // 타일에 타워가 건설되어 있는지 검사하는 변수
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
