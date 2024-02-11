using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStat : MonoBehaviour
{
    public int maxHealth = 3; // 체력
    public int currentHealth;
    public int damage; // 데미지
    public float unBeatTime; // 무적 시간
    public bool isUnBeatTime; // 무적 시간 확인
    public bool isDelay;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        /* 변수 초기화 */
        currentHealth = maxHealth;
        damage = 1;
        unBeatTime = 2f;
        isUnBeatTime = false;
        isDelay = false;

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
       
       //Debug.Log("현재 체력은 " + currentHealth);

    }

    public void SetHealth(int num)
    {
        currentHealth = num;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void SetUnBeatTime(bool tmp)
    {
        isUnBeatTime = tmp;
    }

    public bool GetUnBeatTime()
    {
        return isUnBeatTime;
    }

    public void Die()
    {
        StartCoroutine(StageMgr.Instance.FadeIn());

        CheckPointScript data = new CheckPointScript();
        data.LoadCheckPointData();
        GetComponent<PlayerStat>().SetUnBeatTime(false);
        GetComponent<GameManager>().spriteRenderer.color = new Color32(255, 255, 255, 255);

        transform.position = data.checkPointData.position;
        currentHealth = maxHealth;
        isDelay = false;
        healthBar.SetHealth(currentHealth);

        StartCoroutine(StageMgr.Instance.FadeOut());
    }
}
