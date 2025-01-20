using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CellScript : MonoBehaviour
{
    public LogicManager game;
    public Rigidbody2D myRigidbody;
    public Transform shouter;
    public LayerMask OtherCells;
    public float speed;
    public bool shout = false;
    public bool full = false;
    private float angulo;
    private float probabilidad_desviacion;

    // Start is called before the first frame update
    void Start(){
        angulo = Random.Range(0,2*Mathf.PI);
        game = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        speed = Random.Range(10,20);
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.1f,0.1f,0.1f));
        probabilidad_desviacion = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Mathf.Cos(angulo)*speed*Time.deltaTime , Mathf.Sin(angulo)*speed*Time.deltaTime,0);
        
        if(Random.Range(0,100) < probabilidad_desviacion){
            if(Random.Range(0,10)>5){
                angulo += Random.Range(0.001f,0.01f);
            }
            else{
                angulo -= Random.Range(0.001f,0.01f);
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

        if(shout == true){ // Si han escuchado un grito, gritan y van hacia el grito
            Collider2D[] shouted_cells = Physics2D.OverlapCircleAll(shouter.position,game.shout_range,OtherCells);
            foreach(Collider2D Cell in shouted_cells){
                Cell.GetComponent<CellScript>().ChangeDirection(transform.position,full);
            }
            shout = false;
        }
    }

    public void ChangeDirection(Vector3 posicion_gritador, bool estado){

        if(estado != full){
            float x = posicion_gritador.x - transform.position.x;
            float y = posicion_gritador.y - transform.position.y;

            float aux = 0;
            if (x<0 && y<0){
                aux = Mathf.PI;
            }

            if (x<0 && y>0){
                aux = Mathf.PI;
            }

            if (x>0 && y<0){
                aux = 2*Mathf.PI;
            }
            if(x != 0){
                angulo = Mathf.Atan(y/x) + aux;
            }
            if(x == 0){
                if(y == 0){
                    return;
                }
                else{
                    if(y>0){
                        angulo = Mathf.PI/2;
                    }
                    else{
                        angulo = 3*Mathf.PI/2;
                    }
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        //COMIDA
        if(collision.gameObject.layer == 6){
            full = true;
            angulo += Mathf.PI;
            shout = true; // Si llegan a la comida chillan
        }
        //CASA
        if(collision.gameObject.layer == 7){
            if(full == true){
            game.addScore(1);
            angulo -= Mathf.PI;         
            full = false;  
            shout = true;   //Si encuentran comida también chillan 
            }

        }
    }
}