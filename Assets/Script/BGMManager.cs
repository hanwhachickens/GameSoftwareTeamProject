using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BGMManager : MonoBehaviour
{

    AudioSource BGM;
    // Start is called before the first frame update
    void Start()
    {
        BGM = GetComponent<AudioSource>(); //배경음악 저장해둠

        // 배경음악이 재생되고 있다면 패스
        if (BGM.isPlaying) return;

        // 배경음악 계속 재생하게
        else
        {
            BGM.Play();
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
