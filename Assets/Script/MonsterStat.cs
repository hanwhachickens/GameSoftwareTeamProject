using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterStat : MonoBehaviour
{
    public int maxHealth = 3; // 체력
    public int currentHealth;
    public int damage = 1; // 데미지
    public float unBeatTime = 0f; // 무적 시간
    public bool isUnBeatTime = false; // 무적 시간 확인
    public bool isDelay = false;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        /* 변수 초기화 */
        currentHealth = maxHealth;
        /*
        damage = 1;
        unBeatTime = 0f;
        isUnBeatTime = false;
        isPlayed = false;
        isPlaying = false;
        isPaused = false;
        isStopped = false;
        */

        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetHealth(int num)
    {
        currentHealth = num;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void Die()
    {
        Destroy(this.GameObject());
    }
}
