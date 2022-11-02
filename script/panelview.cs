using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class panelview : MonoBehaviour
{
    // Start is called before the first frame update
    public int panel = 0;
    private TextMeshProUGUI towerName;
    private TextMeshProUGUI towerAttack;
    private TextMeshProUGUI towerSpeed;
    private TextMeshProUGUI towerRare;
    private towerweapon towerweapon;
    private Image Bassimage;
    private SpriteRenderer changimg;
    private rarespawn upgradespawn1;
    public int upgradenum1;
    private Image entry1;
    public Sprite Changeentry1;
    private TextMeshProUGUI entryname1;
    private TextMeshProUGUI entrylist1;
    public string Centrylist1;
    private rarespawn upgradespawn2;
    public int upgradenum2;
    private Image entry2;
    public Sprite Changeentry2;
    private TextMeshProUGUI entryname2;
    private TextMeshProUGUI entrylist2;
    public string Centrylist2;
    private towerspawner towerspawner;

    public void OnMouseDown()
    {
        if(panel == 0) //타워 정보
        {
            GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(7).gameObject.SetActive(false);
            GameObject.Find("towerInfo").transform.GetChild(8).gameObject.SetActive(true);

            towerName = GameObject.Find("towerInfo").transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            Bassimage = GameObject.Find("towerimg").GetComponent<Image>();
            changimg = this.gameObject.GetComponent<SpriteRenderer>();
            Bassimage.sprite = changimg.sprite;
            towerweapon = this.gameObject.GetComponent<towerweapon>();
            towerAttack = GameObject.Find("attack").GetComponent<TextMeshProUGUI>();
            towerSpeed = GameObject.Find("Speed").GetComponent<TextMeshProUGUI>();
            towerRare = GameObject.Find("Rare").GetComponent<TextMeshProUGUI>();
            upgradespawn1 = GameObject.Find("enetryimage").GetComponent<rarespawn>();
            upgradespawn2 = GameObject.Find("enetryimage2").GetComponent<rarespawn>();

            entry1 = GameObject.Find("enetryimage").GetComponent<Image>();
            entry2 = GameObject.Find("enetryimage2").GetComponent<Image>();
            entryname1 = GameObject.Find("enetryname").GetComponent<TextMeshProUGUI>();
            entryname2 = GameObject.Find("enetryname2").GetComponent<TextMeshProUGUI>();
            entrylist1 = GameObject.Find("enetrytext").GetComponent<TextMeshProUGUI>();
            entrylist2 = GameObject.Find("enetrytext2").GetComponent<TextMeshProUGUI>();

            towerspawner = GameObject.Find("towerspawner").GetComponent<towerspawner>();
            towerspawner.selecttower = this.gameObject;

            string[] name = this.gameObject.name.Split(new char[] { '(' });
            towerName.text = name[0];
            towerAttack.text = "Attack : " + towerweapon.attackDamage.ToString();
            towerSpeed.text = "Speed : " + towerweapon.attackRate.ToString();

            if (gameObject.CompareTag("nomaltower"))
            {
                towerRare.text = "등급 : 노말";
                setRare(upgradenum1,upgradenum2);
            }
            else if (gameObject.CompareTag("raretower"))
            {
                towerRare.text = "등급 : 레어";
                setRare(upgradenum1, upgradenum2);
            }
            else if (gameObject.CompareTag("unique"))
            {
                towerRare.text = "등급 : 유니크";
                setRare(upgradenum1, upgradenum2);
            }
            entry1.sprite = Changeentry1;
            string[] list1 = Centrylist1.Split(new char[] { ',' });
            entrylist1.text = towerspawner.towerlist[int.Parse(list1[0])].name + " + " + towerspawner.towerlist[int.Parse(list1[1])].name;
            entryname1.text = towerspawner.towerlist[upgradenum1].name;

            if (upgradenum2 == 0)
            {
                GameObject.Find("towerInfo").transform.GetChild(8).gameObject.SetActive(false);
                entryname2.text = "";
                entrylist2.text = Centrylist2;
            }
            else
            {
                string[] list2 = Centrylist2.Split(new char[] { ',' });
                entry2.sprite = Changeentry2;
                entryname2.text = towerspawner.towerlist[upgradenum2].name;
                entrylist2.text = towerspawner.towerlist[int.Parse(list2[0])].name + " + " + towerspawner.towerlist[int.Parse(list2[1])].name;
            }
        }
        else if(panel == 2) //인벤토리
        {
            GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(7).gameObject.SetActive(false);
        }
        else if (panel == 3) //상점
        {
            GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(7).gameObject.SetActive(false);
        }
        else if (panel == 4) //도감
        {
            GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.GetChild(7).gameObject.SetActive(false);
        }
        else if (panel == 5) //퀘스트
        {
            GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(5).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(7).gameObject.SetActive(true);
        }
    }
    public void setRare(int entry1,int entry2)
    {
        upgradespawn1.rare = entry1;
        upgradespawn2.rare = entry2;
    }
}
