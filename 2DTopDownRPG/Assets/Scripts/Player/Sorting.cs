using UnityEngine;
using System.Collections;

public class Sorting : MonoBehaviour
{
    public Transform player;

    private void Update()
    {

        //TODO remove GetComponents from update functions. Cache values instead
        if(transform.position.y>=player.transform.position.y)
        {
            Debug.Log("Behind Player");
            GetComponent<SpriteRenderer>().sortingOrder = (player.GetComponent<SpriteRenderer>().sortingOrder) - 1;
            GetComponents<BoxCollider2D>()[1].enabled = false;
            GetComponents<BoxCollider2D>()[2].enabled = true;
        }
        if (transform.position.y < player.transform.position.y)
        {
            Debug.Log("In front of Player");
            GetComponent<SpriteRenderer>().sortingOrder = (player.GetComponent<SpriteRenderer>().sortingOrder) + 1;
            GetComponents<BoxCollider2D>()[1].enabled = true;
            GetComponents<BoxCollider2D>()[2].enabled = false;
        }
    }
}