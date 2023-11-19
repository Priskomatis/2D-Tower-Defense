using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Currency_Manager : MonoBehaviour
{
    private Game_Management gm;

    [SerializeField] private TextMeshProUGUI currency_txt;

    private void Start()
    {
        gm = FindObjectOfType<Game_Management>();

    }

    public void ChangeCurrencyUI(int x)
    {
        currency_txt.text = x.ToString();
    }
}
