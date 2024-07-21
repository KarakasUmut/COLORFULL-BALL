using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uimaneger;
    public void Start()
    {
        CoinCalculator(0);
        Debug.Log(PlayerPrefs.GetInt("moneyy"));
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("FinishLine"))
        {
            Debug.Log("oyun bitti");
            CoinCalculator(100);
            uimaneger.CoinTextUpdate();
            uimaneger.FinishScreen();
            PlayerPrefs.SetInt("LevelIndex", PlayerPrefs.GetInt("LevelIndex") + 1);
        }
    }

    public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("moneyy"))
        {
            int oldScore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy", oldScore + money);

        }
        else
            PlayerPrefs.SetInt("moneyy", 10000);
    }   

}
