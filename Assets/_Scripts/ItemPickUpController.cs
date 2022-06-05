using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpController : MonoBehaviour
{

    [SerializeField]
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.name == "Player")
        {

            //Destroy(gameObject); // Destruye este gameObject
            Destroy(transform.parent.gameObject); // Destruye el padre de este gameObject
            gameManager.ItemsCollected++;
        
        }

    }
}
