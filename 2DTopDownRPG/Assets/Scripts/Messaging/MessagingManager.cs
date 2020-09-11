using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Very basic messenger that when called will tell anyone who is listening that something has happened. There wil be no extra info, no details, just an event.

public class MessagingManager : MonoBehaviour
{
   //static singleton property
   public static MessagingManager Instance { get; private set; }

    //public property for manager
    private List<Action> subscribers = new List<Action>();

    private void Awake()
    {
        Debug.Log("Messaging Manager Started");
        //Check if any conflicting instances
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void Subscribe(Action subscriber)
    {
        Debug.Log("subscriber registered");
        subscribers.Add(subscriber);
    }

    public void Unsubscribe(Action subscriber)
    {
        Debug.Log("Subscriber unregistered");
        subscribers.Remove(subscriber);
    }

    public void ClearAllSubscribers(Action subscriber)
    {
        subscribers.Clear();
    }

    public void Broadcast()
    {
        Debug.Log("Broadcast Requested, Number of subs = " + subscribers.Count);
        foreach (var subscriber in subscribers)
        {
            subscriber();
        }
    }
}
