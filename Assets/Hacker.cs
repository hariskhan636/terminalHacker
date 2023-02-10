using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    public int choice;

    public enum Screen { MainMenu, Password, Win }
    public Screen currentScreen = Screen.MainMenu;

    void Start()
    {
        var greeting = "Hello Haris";
        showMainMenu(greeting);
    }

    void showMainMenu(string g)
    {
        Screen currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(g);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for NASA");
        Terminal.WriteLine("Press 3 for police station");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            showMainMenu("Yo");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }

    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            choice = 1;
            StartGame();
        }
        if (input == "2")
        {
            choice = 2;
            StartGame();
        }
        if (input == "3")
        {
            choice = 3;
            StartGame();
        }
    }

    void StartGame()
    {
        Terminal.WriteLine("Level: " + choice);
        currentScreen = Screen.Password;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
