using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour
{
   [Header("Dynamic")]
    public int score = 0;
    private TextMeshProUGUI uiText;
    void Start(){
        uiText = GetComponent<TextMeshProUGUI>();
    
    }

    void Update(){
        uiText.text = "Score: " + score.ToString("#,0");
    }
}
