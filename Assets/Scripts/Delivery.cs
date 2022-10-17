using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    
    SpriteRenderer spriteRenderer;
    [SerializeField] ParticleSystem packageBurst;

    [SerializeField] bool hasPackage = false;
    [SerializeField] float destroyDelay = .5f;


    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    
    //removed "private" so it can be accessed elsewhere, if i want
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Boom!!");
    }

     void OnTriggerEnter2D(Collider2D other) {

        string statement = "Test";

        //use a TAG to check if something is a category of a thing
        if (other.tag == "Package" && !hasPackage) {
                 statement = "Package picked up!";
                 hasPackage = true;
                 Destroy(other.gameObject, destroyDelay);
                 spriteRenderer.color = hasPackageColor;
                 packageBurst.Play();
   
        } else if (other.tag == "Package" && hasPackage) {
            statement = "You already have a package to deliver!";

        } else if (other.tag == "Customer" && hasPackage) {
            statement = "Package Delivered";
            hasPackage = false;
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = noPackageColor;
            packageBurst.Stop();

        } else if (other.tag == "Customer" && !hasPackage) {
            statement = "You have nothing to deliver to the customer";
        }
        
        Debug.Log(statement);
        
    }

    //if statements check if something is true or not
    //if (this statement is true) { Do this thing }


}
