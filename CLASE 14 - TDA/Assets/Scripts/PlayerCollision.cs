using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCollision : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(name + " COLISION CON " + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("Level1");
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<PlayerMovement>().SetJumpStatus(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log(name + " EXIT COLISION CON " + other.gameObject.name);
        if (other.gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<PlayerMovement>().SetJumpStatus(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup")){
            Debug.Log(name + " Tigger con" + other.gameObject.name);
            Destroy(other.gameObject);
            GameManager.instance.score += 100;
            GameManager.instance.powerupSpeed++;


        }
        
    }
}
