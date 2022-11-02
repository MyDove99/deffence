using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhp01 : MonoBehaviour
{
    [SerializeField]
    private float maxHp;
    public float currentHp; //����ü��
    public float deffence; // ����
    private float imdef; // �ε� ����
    private bool isDie = false;
    private enemy enemy;
    private SpriteRenderer spriterenderer;
    [SerializeField]
    public towerlist[] towerlists = new towerlist[60];
    public float Maxhp => maxHp;
    public float Currenthp => currentHp;

    private void Awake()
    {
        imdef = deffence;
        currentHp = maxHp;
        enemy = GetComponent<enemy>();
        spriterenderer = GetComponent<SpriteRenderer>();
        for(int i=0; i<towerlists.Length; i++)
        {
            towerlists[i] = new towerlist("", 0);
        }
    }

    public void TakeDamage(float damage,int skill)
    {
        if (isDie == true) return;
        
        if(deffence > damage)
        {
            currentHp = currentHp;
        }
        else if(skill==0)
        {
            if(deffence <= -50)
            {
                currentHp = currentHp - damage;
                StopCoroutine("HitAlphaAnimation");
                StartCoroutine("HitAlphaAnimation");
            }
            else
            {
                float def = deffence / (deffence + 50) * 100; //����
                float dmg = damage - (damage / Mathf.Ceil(def)); // ������ ������
                currentHp = currentHp - dmg;
                StopCoroutine("HitAlphaAnimation");
                StartCoroutine("HitAlphaAnimation");
            }
        }else if (skill == 1)
        {
            currentHp = currentHp - damage;
            StopCoroutine("HitAlphaAnimation");
            StartCoroutine("HitAlphaAnimation");
        }

        if(currentHp <= -0)
        {
            isDie = true;
            enemy.OnDie();
        }
    }

    private IEnumerator HitAlphaAnimation()
    {
        Color color = spriterenderer.color;

        color.a = 0.4f;
        spriterenderer.color = color;

        yield return new WaitForSeconds(0.05f);

        color.a = 1.0f;
        spriterenderer.color = color;
    }
    public void amorbreak()
    {
        float temp = 0;
        foreach (towerlist tower in towerlists)
        {
            temp = temp + tower.def;
        }
        deffence = imdef - temp;
    }
    public void listdelete(string towername)
    {
        foreach (towerlist tower in towerlists)
        {
            if(tower.name == towername)
            {
                tower.name = "";
                tower.def = 0;
            }
        }
    }
    public class towerlist
    {
        public string name; // Ÿ���̸�
        public float def; // ��
        public towerlist(string name,float def)
        {
            this.name = name;
            this.def = def;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
