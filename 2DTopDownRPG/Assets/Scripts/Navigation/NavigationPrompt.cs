using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationPrompt : MonoBehaviour
{

    public Vector3 startingPosition;
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameState.saveLastPosition = false;
        GameState.SetLastScenePosition(SceneManager.GetActiveScene().name, startingPosition);

        if(NavigationManager.CanNavigate(this.tag))
        {
            Debug.Log("trying to enter " + tag);

            NavigationManager.NavigateTo(this.tag);

        }

      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        GameState.saveLastPosition = false;
        GameState.SetLastScenePosition(SceneManager.GetActiveScene().name, startingPosition);

        if (NavigationManager.CanNavigate(this.tag))
        {
            Debug.Log("trying to enter " + tag);

            NavigationManager.NavigateTo(this.tag);

        }


    }
}
