using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    
    [SerializeField]
    TMP_Text scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.SetText(score.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetScore(int value)
    {
        score = value;
        scoreText.SetText(score.ToString());
    }
}
