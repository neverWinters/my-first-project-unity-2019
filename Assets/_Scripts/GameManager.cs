using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int _itemsCollected = 0;
    public int ItemsCollected
    {

        get { return _itemsCollected; }

        set { _itemsCollected = value; }

    }
    private int _playerHP = 100;
    public int PlayerHP
    {
        get { return _playerHP; }

        set 
        { if(value >= 0 && value <= 100) _playerHP = value; }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
