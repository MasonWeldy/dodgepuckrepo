using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public int scoreValue;


    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        //scoreValue += 5;
        scoreText.text = "score: " + scoreValue.ToString(); 
    }
}
