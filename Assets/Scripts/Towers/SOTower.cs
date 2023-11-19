using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName ="Tower")]
public class SOTower : ScriptableObject {

    public string tower_name;
    public string tower_description;
    public Sprite tower_image;

    public int cost;
    public int upgrade;

    public int damage;
    public int attackRange;
    public int attackspeed;


}
