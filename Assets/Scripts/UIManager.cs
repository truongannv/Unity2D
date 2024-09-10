using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public GameObject gameoverPanel;
   
    public void setScoreText(string txt){
        if(scoreText){
            scoreText.text = txt;
        }
    }

    public void showGameOverPanel(bool isShow){
        if(gameoverPanel){
            gameoverPanel.SetActive(isShow);
        }
    }
}
