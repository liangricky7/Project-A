using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    public float speed;
    private Vector3 direction;
    private GameObject playObj=null;
    private float player_x, player_y, distance, aggroRadius=10;



    // Start is called before the first frame update
    //void Start()
    //{    }

    // Update is called once per frame
    void Update(){
        if (isClose){
            Debug.Log("MADMADMADMAD");
        }
        
    }

    private bool isClose(){

        //finding the player by name 
        if (playerObj==null){
            playerObj=GameObject.Find("Player");
        } 
        player_x=playerObj.transform.position.x;
        player_y=playerObj.transform.position.y;

        // distance btwn player and enemy;
        //there has to be a better way to do this...
        distance=sqrt((player_x-transform.position.x)**2 +(player_y-tranform.position.y)**2);
        if (distance <=aggroRadius){
            return true;
        }
    }
}
