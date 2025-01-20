using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicManager : MonoBehaviour
{   
    public float radio;
    public float width;
    public float height;
    public int N_Cell;
    public int playerScore;
    public Text scoreText;
    public float shout_range;
    public float house_speed;
    public float food_speed;
    
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd){
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    
    // Start is called before the first frame update
    void Start(){

        radio = 0.5f;
        height = 15;
        width = 26;
        N_Cell = 200;
        shout_range = 25;

        house_speed = 1f;
        food_speed = 0.5f;
    }

    // Update is called once per frame

    public float N_Rand (float min, float max){
        return min+ (max-min) * Random.value;
    }
}
