using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement pmPlayer;

    private void Start() {
        pmPlayer = GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(name + " COLISION CON " + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy"))
        {
           // Debug.Log("GAME OVER");
            SceneManager.LoadScene("Level1");
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<PlayerMovement>().SetJumpStatus(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
       // Debug.Log(name + " EXIT COLISION CON " + other.gameObject.name);
        if (other.gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<PlayerMovement>().SetJumpStatus(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup")){
           // Debug.Log(name + " Tigger con" + other.gameObject.name);
            Destroy(other.gameObject);
            GameManager.instance.score += 100;
            GameManager.instance.powerupSpeed++;


        }
        
        if (other.gameObject.CompareTag("Savepoint")){
           // Debug.Log(other.name);
            SavepointsManager managerSP = other.transform.parent.GetComponent<SavepointsManager>();
            managerSP.FindSavePoint(other.name);
        }

        if (other.gameObject.CompareTag("Gem")){
            InventoryManager playerInventory = pmPlayer.GetPlayerInventory();
            GameObject gem = other.gameObject;
            gem.SetActive(false);
            playerInventory.AddInventoryOne(gem);
            playerInventory.AddInventoryTwo(gem);
            playerInventory.AddInventoryThree(gem.name, gem);
            Debug.Log("--------- INVETARIO 1 -----------");
            playerInventory.SeeInventoryOne();
            Debug.Log("--------- INVETARIO 2 -----------");
            playerInventory.SeeInventoryTwo();
            Debug.Log("--------- INVETARIO 3 -----------");
            playerInventory.SeeInventoryThree();
        }
    }   
}
