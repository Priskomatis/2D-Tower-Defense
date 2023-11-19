using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lives_Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lives_txt;

    private Game_Management gm;

    [SerializeField] private Animator anim;

    private void Start()
    {
        gm = Game_Management.FindObjectOfType<Game_Management>();
        lives_txt.text = gm.health.ToString();
    }
    public void ChangeLivesTxt(int x)
    {
        lives_txt.text = x.ToString();
        anim.SetTrigger("Flash");
    }





}
