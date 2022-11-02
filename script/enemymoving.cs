using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymoving : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    private float original; // 이 오브젝트 기본 속도
    public float MoveSpeed => moveSpeed; // 이 오브젝트 이동속도 (변경됨)
    bool change = false; // 이속 변경 여부
    float time; // 여기서 사용할 시간
    public active[] actives = new active[60];
    timer timer;
    public float temp = 0;
    public LayerMask towerlist;
    private Vector2 Range = new Vector2(10000, 10000);
    void Awake()
    {
        for(int i=0; i<actives.Length; i++){
            actives[i] = new active("",0,0);
        }
        original = moveSpeed;
        timer = GameObject.Find("PanelInfoUI").GetComponent<timer>();
        time = timer.time;
    }

    // Update is called once per frame
    private void Update()
    {
        time = timer.time;
        search();
        slow();
        if (moveSpeed != original)
        {
            check();
        }
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
    public void check()
    {
        foreach (active i in actives)
        {
            if ((int)time == ((int)i.endtime))
            {
                i.name = ""; i.slow = 0; i.endtime = 0;
            }
        }
        deletelist();
    }
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
    public void slow()
    {
        temp = 0;
        foreach(active i in actives)
        {
            temp = temp + i.slow;
            float slowper = (float)temp / (float)100;
            if (slowper > 1)
            {
                slowper = 1;
            }
            moveSpeed = original * (1 - slowper); //이동속도 변경
        }
    }
    public void search()
    {
        Collider2D[] hit = Physics2D.OverlapBoxAll(this.transform.position, Range, 0, towerlist);
        foreach (Collider2D i in hit)
        {
            foreach(active j in actives)
            {
                if (j.name == i.name)
                {
                    break;
                }
                else if (j.name == "")
                {
                    if (i.gameObject.GetComponent<passive>() == false)
                    {
                        break;
                    }
                    else if (i.gameObject.GetComponent<passive>().skillnum == 2)
                    {
                        j.name = i.gameObject.name; j.endtime = time +600; j.slow = i.gameObject.GetComponent<passive>().slow;
                        break;
                    }
                    else { break; }
                }
            }
        }
    }
    public void slowlist(int slow,int slowtime,string name)
    {
        for (int i = 0; i < actives.Length; i++){
            if (actives[i].name== name)
            {
                break;
            } else if(actives[i].name == "")
            {
                actives[i] = new active(name, time + (float)slowtime,slow);
                break;
            }
        }
    }
    public void deletelist()
    {
        for (int i = 0; i < actives.Length; i++)
        {
            if (actives[i].endtime > 600)
            {
                actives[i].name = ""; actives[i].endtime = 0; actives[i].slow = 0;
            }
        }
    }
    public class active
    {
        public string name; //발동자
        public float endtime; // 끝날시간
        public float slow; //이감 퍼센트
        public active(string name, float endtime,float slow)
        {
            this.name = name;
            this.endtime = (int)endtime;
            this.slow = slow;
        }
    }
}
