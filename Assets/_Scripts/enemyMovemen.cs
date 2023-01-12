using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemyMovemen : MonoBehaviour
{
    public float speed;
    private Vector3 direction;
    private GameObject playerObj=null;
    private float player_x, player_y, aggroRadius=10;
    private double distance;


    // Start is called before the first frame update
    //void Start()
    //{ }

    // Update is called once per frame
    void Update(){
        if (isClose()){
            Debug.Log("MADMADMADMAD");
        }
        else{
            Debug.Log("calm");
        }
    }

    bool isClose(){

        //finding the player by name
        if (playerObj==null){
            playerObj=GameObject.Find("Player");
        }

        player_x=playerObj.transform.position.x;
        player_y=playerObj.transform.position.y;

        // distance btwn player and enemy;
        //there has to be a better way to do this...
        double uhm=Math.Pow((player_x-transform.position.x), 2);
        double uhh=Math.Pow((player_y-transform.position.y), 2);
        distance=Math.Pow((uhm+uhh), 0.5);
        if (distance <=aggroRadius){
            return true;
        }
        return false;
    }
}
