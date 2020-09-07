using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPrompt : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {

        if(NavigationManager.CanNavigate(this.tag))
        {
            Debug.Log("trying to enter " + tag);

            NavigationManager.NavigateTo(this.tag);

        }

      
    }
}
