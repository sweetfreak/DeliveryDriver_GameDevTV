using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float steerSpeed;

    [SerializeField] float collisionDecrease;
    [SerializeField] float boostIncrease;

    [SerializeField] float speedTimer = 3f;

    void Update()
    {
        //time.delta time will keep it consistent between computers, so fast/slow computers won't have different functionality


        //"Horizontal" is a string reference, not great to use
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, -steerAmount);

    }

     void OnTriggerEnter2D(Collider2D other) {
         
         if (other.tag == "Boost") {
            moveSpeed += boostIncrease;
         }
    }
     void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Boost") {
            moveSpeed -= boostIncrease;
         }
    }


    //NOTE: collision not working properly. Slows you down for too long, need to set timer and make it so it only makes your speed decreased ones

    //  void OnCollisionEnter2D(Collision2D other) {
    //     if (other.gameObject.tag == "Obstacle") {
    //         moveSpeed = collisionDecrease;
    //         //startDelay();
    //     }
    //  }    

    // void startDelay()  {
    //         while (speedTimer > 0) {
    //             speedTimer -= Time.deltaTime;
    //         } 
            
    //         if (speedTimer <= 0) {
    //         moveSpeed -= collisionDecrease;
    //         speedTimer = 3f;
    //     }
    // }

}

