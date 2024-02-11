using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStat : MonoBehaviour
{
    public int maxHealth = 3; // ü��
    public int currentHealth;
    public int damage; // ������
    public float unBeatTime; // ���� �ð�
    public bool isUnBeatTime; // ���� �ð� Ȯ��
    public bool isDelay;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        /* ���� �ʱ�ȭ */
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
       
       //Debug.Log("���� ü���� " + currentHealth);

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
