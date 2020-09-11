using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingClientBroadcast : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        MessagingManager.Instance.Broadcast();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        MessagingManager.Instance.Broadcast();
    }
}
