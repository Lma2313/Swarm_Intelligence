using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComidaScript : MonoBehaviour
{   
    public LogicManager game;
    public Rigidbody2D myRigidbody;
    private int timer = 0;
    private Vector2 pos;
    public float angulo;
    public float speed;
    private float desv;

    // Start is called before the first frame update
    void Start(){
   
        game = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        speed = 0f;
        angulo = Random.Range(0,2*Mathf.PI);
        desv = 0.1f;
    }

    // Update is called once per frame
    void Update(){

        if(timer == 0){
            timer += 1;
            pos = Empezar();
            myRigidbody.position = pos;
            speed = game.food_speed; // Lo hago solo en el primer tick para inicializarlos
        }
        else{
            transform.position += new Vector3(Mathf.Cos(angulo)*speed*Time.deltaTime , Mathf.Sin(angulo)*speed*Time.deltaTime,0);
            
            if(Random.Range(0,100) < 1){
                if(Random.Range(0,10) < 5){
                    angulo += desv;
                }
                else{
                    angulo -= desv;
                }
            }

            if(transform.position.x > game.width){
                transform.position += new Vector3(-2*game.width,0,0);
            }
            if(transform.position.x < -game.width){
                transform.position += new Vector3(2*game.width,0,0);
            }
            if(transform.position.y > game.height){
                transform.position += new Vector3(0,-2*game.height,0);
            }
            if(transform.position.y < -game.height){
                transform.position += new Vector3(0,2*game.height,0);
            }
        }
    }
    private Vector2 Empezar(){

        var y = game.N_Rand(-game.height+game.radio,game.height-game.radio);
        var x = game.N_Rand(-game.width+game.radio,game.width-game.radio);
        return new Vector2(x,y);
    }
}
