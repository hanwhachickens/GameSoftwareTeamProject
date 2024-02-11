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
        BGM = GetComponent<AudioSource>(); //������� �����ص�

        // ��������� ����ǰ� �ִٸ� �н�
        if (BGM.isPlaying) return;

        // ������� ��� ����ϰ�
        else
        {
            BGM.Play();
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
