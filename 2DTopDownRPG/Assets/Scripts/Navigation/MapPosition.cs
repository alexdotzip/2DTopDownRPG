using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var lastPosition = GameState.GetLastScenePosition(SceneManager.GetActiveScene().name);
        
        if(lastPosition != Vector3.zero)
        {
            transform.position = lastPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (GameState.saveLastPosition)
        {
            GameState.SetLastScenePosition(SceneManager.GetActiveScene().name, transform.position);
        }
    }
}

