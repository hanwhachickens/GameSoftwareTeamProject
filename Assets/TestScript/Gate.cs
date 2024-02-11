using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public enum NextPositionType
    {
        Init, Some, Portal,
    };
    public NextPositionType nextPositionType;
    public Transform Destination;

    public bool FadeInOut;
    public bool SmoothMoving;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision is CapsuleCollider2D)
        {
            if (collision.transform.CompareTag("Player"))
            {
                if (nextPositionType == NextPositionType.Init)
                {
                    //collision.transform.position = Vector3.zero;
                    StartCoroutine(StageMgr.Instance.MoveNext(collision, Vector3.zero, FadeInOut, SmoothMoving));
                }
                else if (nextPositionType == NextPositionType.Some)
                {
                    //collision.transform.position = Destination.position;
                    StartCoroutine(StageMgr.Instance.MoveNext(collision, Destination.position, FadeInOut, SmoothMoving));
                }
                else if (nextPositionType == NextPositionType.Portal)
                {
                    SceneManager.LoadScene("EndingScene");
                }
                else { }
            }
        }
    }
}
