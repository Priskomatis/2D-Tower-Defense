using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Monster", menuName ="Monster")]
public class SOEnemy_Base : ScriptableObject
{
    //General info about each monster
    public string monster_name;
    public string description;
    public Sprite image;

    //Stats about mosnter
    public int maxHealth;
    public int currentHealth;
    public int armor;
    public int speed;
    public int num_lives;

    public int reward;

    public GameObject enemyPrefab;




}
