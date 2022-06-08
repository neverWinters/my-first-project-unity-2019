using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string labelText = "Recolecta los 4 items y ganate la libertad!";
    [SerializeField]
    private int maxItems = 4;
    private int _itemsCollected = 0;
    private bool showWinScreen = false;
    public int ItemsCollected
    {

        get { return _itemsCollected; }

        set {

            _itemsCollected = value;

            if (_itemsCollected >= maxItems)
            {

                labelText = "Has encontrado todos los items";
                showWinScreen = true;
                Time.timeScale = 0;

            }
            else
            {
                labelText = $"Item encontrado, te faltan: {maxItems - _itemsCollected}";

            }

        }

    }
    private int _playerHP = 100;
    public int PlayerHP
    {
        get { return _playerHP; }

        set 
        { if(value >= 0 && value <= 100) _playerHP = value; }

    }

    void OnGUI()
    {

        GUI.Box(new Rect(25, 25, 180, 25), $"Vida: {_playerHP}");
        GUI.Box(new Rect(25, 65, 180, 25), $"Items recolectados: {_itemsCollected}");
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 50), labelText);

        if (showWinScreen)
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 400, 200), "Has ganado")) 
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;

            }

    }
}
