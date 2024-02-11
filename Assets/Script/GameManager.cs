using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public TalkManager talkManager;
    public GameObject talkPanel;
    public GameObject scanObject;
    public Text talkText;
    public bool isAction;
    public int talkIndex;
    // public NPCTalk manager;



    // 대충 여기서 공격 데미지 처리, 무적 관리, 게임 스테이지 관리 등
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Monster")
            if (other.GetComponent<MonsterStat>().GetHealth() <= 0)
            {
                GetComponent<PlayerStat>().SetUnBeatTime(false);
                GetComponent<GameManager>().spriteRenderer.color = new Color32(255, 255, 255, 255);
                
                other.GetComponent<MonsterStat>().Die();
            }

            else
                StartCoroutine(GetComponentInChildren<PlayerAttack>().TargetAttack(other));
        if (other.tag == "NPC")
        {
            float NPCDistance = Vector3.Distance(other.transform.position, transform.position);
            if (NPCDistance <= 1f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    
                    // scanObject = other.gameObject;
                    // Debug.Log(scanObject.name);
                    StartCoroutine(other.GetComponent<NPCTalk>().Action());
                    Debug.Log(other.name);
                    //other.GetComponent<NPCTalk>().Action();
                }
            }
        }

        if (other.tag == "Potion")
        {
            float potionDistance = Vector3.Distance(other.transform.position, transform.position);
            if (potionDistance <= 0.75f)
            {
                other.GetComponent<ItemScript>().getPotion();
            }
        }

        if (other.tag == "Save")
        {
            float saveDistance = Vector3.Distance(other.transform.position, transform.position);
            if (saveDistance <= 0.75f)
            {
                Vector3 position = transform.position;
                other.GetComponent<CheckPointScript>().Save(position);
            }
        }
    }

    public IEnumerator CalcUnBeatTime()
    {
        bool isDelay = GetComponent<PlayerStat>().isDelay;
        float unBeatTime = GetComponent<PlayerStat>().unBeatTime;
        if (GetComponent<PlayerStat>().GetHealth() <= 0)
        {
            GetComponent<PlayerStat>().Die();
            yield return null;
        }

        else
        {
            if (GetComponent<PlayerStat>().GetUnBeatTime())
            {
                if (isDelay == false)
                {
                    isDelay = true;
                    for (int i = 0; i < unBeatTime * 10; ++i)
                    {
                        if (i % 2 == 0)
                            spriteRenderer.color = new Color32(255, 255, 255, 90);
                        else
                            spriteRenderer.color = new Color32(255, 255, 255, 180);
                        yield return new WaitForSeconds(0.1f);
                    }
                    GetComponent<PlayerStat>().SetUnBeatTime(false);
                    spriteRenderer.color = new Color32(255, 255, 255, 255);
                    yield return null;
                }
            }
        }
        isDelay = false;
    }
}
