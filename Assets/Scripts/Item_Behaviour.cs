using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Behaviour : MonoBehaviour
{
    public GameBehavior gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);

            Debug.Log("Podniosłeś przedmiot!");
            gameManager.Items += 1;

            gameManager.PrintLootReport();
        }
    }
}
