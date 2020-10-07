using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomBattle : MonoBehaviour
{

    public int battleProbability;
    int encounterChance = 100;
    public int secondsBetweenBattles;
    public string battleSceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if(!GameState.justExitedBattle)
        {
            encounterChance = Random.Range(1, 100);
            if (encounterChance > battleProbability)
            {
                StartCoroutine(RecalculateChance());
            }
        }
        else
        {
            StartCoroutine(RecalculateChance());
            GameState.justExitedBattle = false;
        }
       
    }

    IEnumerator RecalculateChance()
    {
        while(encounterChance > battleProbability)
        {
            yield return new WaitForSeconds(secondsBetweenBattles);
            encounterChance = Random.Range(1, 100);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(encounterChance <= battleProbability)
        {
            Debug.Log("Battle");
            SceneManager.LoadScene(battleSceneName);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        encounterChance = 100;
        StopCoroutine(RecalculateChance());
    }
}
