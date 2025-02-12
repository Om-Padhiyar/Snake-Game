using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    PlayerCollision playercoll;
    private void Awake(){
        playercoll= GameObject.FindGameObjectWithTag("Character").GetComponent<PlayerCollision>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Character")){
            Debug.Log("Checkpoint reached at position: " + transform.position);
            playercoll.UpdateCheckpoint(transform.position);
        }
    }
}
