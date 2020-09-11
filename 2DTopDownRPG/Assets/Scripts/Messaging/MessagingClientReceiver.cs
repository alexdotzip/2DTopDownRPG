using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingClientReceiver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MessagingManager.Instance.Subscribe(ThePlayerIsTryingToLeave);
    }



    void ThePlayerIsTryingToLeave()
    {

        //TODO This should probably be decided in the Convo manager and then have one output in this Message receiver

        //This is chechking if there is a conversation component
        var dialog = GetComponent<ConversationComponent>();
        if(dialog != null)
        {

            //if that component has a conversation and if that conversation is greater than 0
            if (dialog.Conversations != null && dialog.Conversations.Length > 0)
            {

                //store it
                var conversation = dialog.Conversations[0];

                if(conversation != null)
                {
                    ConversationManager.Instance.StartConversation(conversation);
                }
            }
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
