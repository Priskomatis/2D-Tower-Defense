using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Monster_Spawning : MonoBehaviour
{
    public SOEnemy_Base enemy_type;
    public int num_monsters;
    public int num_waves;
    public GameObject spawnpoint;

    public GameObject hpbar;

    private int spawnedMonsters, currentWave = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWave < num_waves)
        {
            Debug.Log("------Wave " + (currentWave+1) + "/" + num_waves + "------");
            //We reset the spawned monsters for each wave
            spawnedMonsters = 0;
            while (spawnedMonsters < num_monsters)
            {
                //The spawned position of the enemies
                Vector3 spawnPosition = spawnpoint.transform.position;

                //We spawn the prefab enemy
                GameObject enemyPrefab = Instantiate(enemy_type.enemyPrefab, spawnPosition, Quaternion.identity);

                //Must create a HPBar prefab to spawn with the enemy
                //GameObject hpbarPrefab = Instantiate(hpbar, enemyPrefab.transform.position + Vector3.up * 2.0f, Quaternion.identity);


                spawnedMonsters++;

                yield return new WaitForSeconds(2f); // Adjust the delay between spawns if needed.
            }
            currentWave++;
            
            // Optionally, you can add a delay between waves here.
            yield return new WaitForSeconds(2f); // Adjust the delay between waves if needed.
        }
    }
}