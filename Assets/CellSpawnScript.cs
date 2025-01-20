using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSpawnScript : MonoBehaviour
{
    public LogicManager game;
    public GameObject cell;
    private int timer = 0;
    private int i;

    // Start is called before the first frame update
    void Start(){

        game = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    void Update(){
        if(timer == 0){
            timer +=1;
            for(i = 0; i < game.N_Cell; i++)
                SpawnCell();
        }
    }

    void SpawnCell(){
        Instantiate(cell, new Vector3(Random.Range(-game.width,game.width),Random.Range(-game.height,game.height),0), transform.rotation);
    }
}