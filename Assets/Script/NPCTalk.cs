using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class NPCTalk : MonoBehaviour
{

    // public TalkManager talkManager;
    public GameObject talkPanel;
    public GameObject portal;
    // public GameObject scanObject;
    public Text talkText;
    public bool isAction;
    public int talkIndex;
    bool isDelay;
    public GameObject joystick;

    //public void Action()
    //{
    //    ObjData objData = GetComponent<ObjData>();
    //    Talk(objData.id, objData.isNpc);
    //    talkPanel.SetActive(isAction);
    //}

    void Talk(int id, bool isNpc)
    {
        string talkData = GetComponent<TalkManager>().getTalk(id, talkIndex);
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }
        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }
        isAction = true;
        Debug.Log("isAction");
        talkIndex++;
    }
    // Start is called before the first frame update
    void Start()
    {
        // talkManager = new TalkManager();
        // talkPanel = GameObject.Find("talkPanel");
        // talkText.text = "디폴트";
        isAction = false;
        talkIndex = 0;
        isDelay = false;
    }
    // Update is called once per frame
    void Update()
    {

    }


    public IEnumerator Action()
    {
        if (isDelay == false)
        {
            isDelay = true;
            Debug.Log("들어왔따");
            ObjData objData = GetComponent<ObjData>();
            if (objData.id == 3000)
            {
                portal.SetActive(true);
            }
            Talk(objData.id, objData.isNpc);
            talkPanel.SetActive(isAction);
            yield return new WaitForSeconds(1f);
        }
        isDelay= false;
    }         
}
