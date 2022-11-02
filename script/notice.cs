using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class notice : MonoBehaviour
{
    [SerializeField] public GameObject noticeCanvas;
    [SerializeField] public GameObject noticeContent;
    private bool onoff = false;
    public void OnMouseDown()
    {
        if(onoff == false)
        {
            noticeCanvas.SetActive(true);
            onoff = true;
        }
        else
        {
            noticeCanvas.SetActive(false);
            onoff = false;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void textadd(string text)
    {
        GameObject notice = GameObject.Find("noticetext").gameObject;
        GameObject createnotice = GameObject.Instantiate(notice, notice.GetComponent<Transform>().position, Quaternion.identity);
        createnotice.transform.parent = noticeContent.transform;
        createnotice.transform.localScale = new Vector3(1, 1);
        TextMeshProUGUI newtext = createnotice.GetComponent<TextMeshProUGUI>();
        newtext.fontSize = 36; newtext.text = text;
    }
    public void warning(string text)
    {
        GameObject notice = GameObject.Find("noticetext").gameObject;
        GameObject createnotice = GameObject.Instantiate(notice, notice.GetComponent<Transform>().position, Quaternion.identity);
        createnotice.transform.parent = noticeContent.transform;
        createnotice.transform.localScale = new Vector3(1, 1);
        TextMeshProUGUI newtext = createnotice.GetComponent<TextMeshProUGUI>();
        newtext.fontSize = 36; newtext.text = text; newtext.color = Color.red;
    }
}
