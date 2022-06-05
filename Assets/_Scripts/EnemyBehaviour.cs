﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name == "Player")
        {

            Debug.Log("Jugador detectado");

        }

    }

    private void OnTriggerExit(Collider other)
    {
        
        if(other.gameObject.name == "Player")
        {

            Debug.Log("Jugador fuera de rango");

        }

    }

}
