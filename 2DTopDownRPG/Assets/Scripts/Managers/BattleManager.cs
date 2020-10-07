using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{

    public GameObject[] EnemySpawnPoints;
    public GameObject[] EnemyPrefabs;
    public AnimationCurve SpawnAnimationCurve;
    private int enemyCount;

    public CanvasGroup theButtons;
    enum BattlePhase
    {
        PlayerAttack,
        EnemyAttack
    }
    //cache current State
    private BattlePhase phase;
    // Start is called before the first frame update
    void Start()
    {
        //Calc enemies
        enemyCount = Random.Range(1, EnemySpawnPoints.Length);
        //Spawn the enemies in
        StartCoroutine(SpawnEnemies());
        //Set the beginning Battle Phase
        phase = BattlePhase.PlayerAttack;
    }

    private void Update()
    {
        if(phase == BattlePhase.PlayerAttack)
        {
            theButtons.alpha = 1;
            theButtons.interactable = true;
            theButtons.blocksRaycasts = true;
        }
        else
        {
            theButtons.alpha = 0;
            theButtons.interactable = false;
            theButtons.blocksRaycasts = false;
        }
    }

    public void RunAway()
    {
        GameState.justExitedBattle = true;
        NavigationManager.NavigateTo("Overworld");
    }

    IEnumerator SpawnEnemies()
    {
        //Spawn enemies
        for (int i = 0; i < enemyCount; i++)
        {
            var newEnemy = (GameObject)Instantiate(EnemyPrefabs[0]);
            newEnemy.transform.position = new Vector3(10, -1, 0);

            yield return StartCoroutine(MoveCharacterToPoint(EnemySpawnPoints[i], newEnemy));
            newEnemy.transform.parent = EnemySpawnPoints[i].transform;
        }
    }

    IEnumerator MoveCharacterToPoint(GameObject destination, GameObject enemyCharacter)
    {
        float timer = 0f;
        var StartPosition = enemyCharacter.transform.position;
        if(SpawnAnimationCurve.length > 0)
        {
            /** Use While Loop to keep the GameObject moving uyntil it finally reaches its destination. Basing Loop on th elength of the AnimationCurve Parameter to have the 
             * character not immediately spawn on a postion
             * 
             * 
             * First checking whether there are animation steps/leys within the Curve.
             * Second if there are keys in the animation, then we keep iterating until we reach the last key in the animation based on the time of that step and our current iteration time**/


            while (timer < SpawnAnimationCurve.keys[SpawnAnimationCurve.length - 1].time)
            {

                //Lerping for the position of the object from start to finish using the animation curve to control its time and rate
                enemyCharacter.transform.position = Vector3.Lerp(StartPosition, destination.transform.position, SpawnAnimationCurve.Evaluate(timer));

                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            enemyCharacter.transform.position = destination.transform.position;
        }
    }
}
