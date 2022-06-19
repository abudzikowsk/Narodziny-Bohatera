using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using CustomExtensions;
using static GameBehavior;

public class GameBehavior : MonoBehaviour, IManager
{
    public delegate void DebugDelegate(string newText);

    public DebugDelegate debug = Print;

    public string labelText = "Zbierz wszystkie 4 przedmioty i zdobądź wolność!";

    public int maxItems = 4;

    public bool showWinScreen = false;

    public bool showLossScreen = false;

    public Stack<string> lootStack = new Stack<string>();

    private int _itemsCollected = 0;

    private string _state;

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;

            if (_itemsCollected >= maxItems)
            {
                labelText = "Znalazłeś wszystkie przedmioty!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Przedmiot znaleziony. Jeszcze " + (maxItems - _itemsCollected) + " do końca.";
            }

        }
    }

    private int _playerHP = 3;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            if (_playerHP <= 0)
            {
                labelText = "Czy potrzebujesz kolejnego źycia?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ojej... To boli.";
            }
        }
    }

    void Start()
    {
        Initalize();

        InventoryList<string> inventoryList = new InventoryList<string>();

        inventoryList.SetItem("Eliksir");
        Debug.Log(inventoryList.item);
    }

    public void Initalize()
    {
        _state = "Menadżer zainicjowany...";
        _state.FancyDebug();
        debug(_state);
        LogWithDelegate(debug);

        GameObject player = GameObject.Find("Player");

        Player_Behavior player_Behavior = player.GetComponent<Player_Behavior>();

        player_Behavior.playerJump += HandlePlayerJump;

        lootStack.Push("Miecz losu");
        lootStack.Push("Dodatkowe życie");
        lootStack.Push("Złoty klucz");
        lootStack.Push("Skrzydlaty but");
        lootStack.Push("Magiczne szelki");
    }

    public void HandlePlayerJump()
    {
        debug("Gracz wykonał skok...");
    }

    public void LogWithDelegate(DebugDelegate del)
    {
        del("Delegowaie zadania wyświetlania komunikatu...");
    }

    public static void Print(string newText)
    {
        Debug.Log(newText);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Kondycja:" + _playerHP);

        GUI.Box(new Rect(20, 50, 150, 25), "Zebrane przedmioty: " + _itemsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                Screen.height / 2 - 50, 200, 100), "WYGRAŁEŚ!"))
            {
                Utilities.RestartLevel(0);
            }
        }

        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                Screen.height / 2 - 50, 200, 100), "PRZEGRAŁEŚ..."))
            {
                try
                {
                    Utilities.RestartLevel(-1);
                    debug("Restart poziomu zakonczył się sukcesem...");
                }

                catch (System.ArgumentException e)
                {
                    Utilities.RestartLevel(0);
                    debug("Powrót do sceny 0: " + e.ToString()); 
                }

                finally
                {
                    debug("Restart został obsłużony...");
                }
            }
        }
    }

    public void PrintLootReport()
    {
        var currentItem = lootStack.Pop();
        var nextItem = lootStack.Peek();
        Debug.LogFormat("Zebrałeś {0}! Teraz masz szanse na znalezienie {1}!", currentItem, nextItem);

        Debug.LogFormat("Czeka na Ciebie {0} losowych łupów!", lootStack.Count);
    }

}