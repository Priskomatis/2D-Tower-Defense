using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    private Game_Management gm;
    public SOEnemy_Base enemy_base;

    public int health;
    [SerializeField] private int reward;
    private float turnUR = -51.4f;
    private float turnUL = 55.72f;
    private float turnUp = 0f;
    private float turnL = 90f;
    private float turnR = -90f;

    [SerializeField] private Slider hpSlider;
    private void Start()
    {
        health = enemy_base.maxHealth;
        GameObject gameManagementObject = GameObject.Find("GameManager");

        if (gameManagementObject != null)
        {
            gm = gameManagementObject.GetComponent<Game_Management>();
        }
        

        hpSlider = GetComponentInChildren<Slider>();
        hpSlider.gameObject.SetActive(true);

        hpSlider.maxValue = enemy_base.maxHealth;
        hpSlider.value = enemy_base.maxHealth;

        Debug.Log(health);
    }

    public void Death()
    {
        GiveReward(reward);
        gameObject.SetActive(false);
    }
    public void DealDamage(int damage)
    {
        Debug.Log("----------DAMAGED---------");

        health = health - damage;
        Debug.Log("Current health: "+ health);

        hpSlider.value -= damage;

        if(health <= 0)
        {
            Death();
        }
    }

    public void GiveReward(int reward)
    {
        gm.money += reward;
    }
    public void CrossLine()
    {
        gm.DecreaseHealth(enemy_base.num_lives);
    }
    public void RotateUR()
    {
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x,
        gameObject.transform.eulerAngles.y,
        turnUR);
        
    }
    public void RotateUL()
    {
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x,
        gameObject.transform.eulerAngles.y,
        turnUL);

    }

    public void RotateUp()
    {
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x,
        gameObject.transform.eulerAngles.y,
        turnUp);

    }

    public void RotateR()
    {

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -90f);

    }
    public void RotateL()   
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90f);

    }

   

}
