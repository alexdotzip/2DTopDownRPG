using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationManager : Singleton<ConversationManager>
{

    //SINGLETON CANT USE THIS CONSTRUCTOR!!! FYI
   protected ConversationManager() { }

    bool talking = false;
    ConversationEntry currentConversationLine;
    public CanvasGroup dialogBox;
    public Image imageHolder;
    public Text textHolder;
    public void StartConversation(Conversation conversation)
    {
        dialogBox = GameObject.Find("Dialog Box").GetComponent<CanvasGroup>();
        imageHolder = GameObject.Find("Speaker Image").GetComponent<Image>();
        textHolder = GameObject.Find("Dialog Text").GetComponent<Text>();

        if(!talking)
        {
            StartCoroutine(DisplayConversation(conversation));
        }
    }

    IEnumerator DisplayConversation(Conversation conversation)
    {
        talking = true;
        foreach(var conversationLine in conversation.ConversationLines)
        {
            currentConversationLine = conversationLine;
            textHolder.text = currentConversationLine.ConversationText;
            imageHolder.sprite = currentConversationLine.DisplayPic;
            yield return new WaitForSeconds(3);
        }
        talking = false;
    }

    private void OnGUI()
    {
        if(talking)
        {
            dialogBox.alpha = 1;
            dialogBox.blocksRaycasts = true;
        }
        else
        {
            dialogBox.alpha = 0;
            dialogBox.blocksRaycasts = false;
        }
    }
}

