using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    public int choice;
    public string password;
    string[] password1 = { "table", "chair", "rotate", "wheel", "diary" };
    string[] password2 = { "believer", "arsenal", "ricochet", "serenity", "pursuit" };

    string[] password3 = { "python", "debugger", "codebase", "mechanics", "laravel" };

    public enum Screen { MainMenu, Password, Win }
    public Screen currentScreen = Screen.MainMenu;

    void Start()
    {
        showMainMenu();
    }

    void showMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for home");
        Terminal.WriteLine("Press 2 for war");
        Terminal.WriteLine("Press 3 for computer");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            showMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPass(input);
        }

    }

    void RunMainMenu(string input)
    {
        bool isValid = (input == "1" || input == "2" || input == "3");
        if (isValid)
        {
            choice = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Enter a valid choice");
        }
    }

    void StartGame()
    {

        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        SetPass();
        var hint = password.Anagram();
        Terminal.WriteLine("Enter the password. Hint: " + hint);
        TypeMenu();
    }

    void SetPass()
    {
        var index = Random.Range(0, 5);
        switch (choice)
        {
            case 1:
                password = password1[index];
                break;
            case 2:
                password = password2[index];
                break;
            case 3:
                password = password3[index];
                break;
            default:
                Debug.LogError("Invalid Number");
                break;
        }
    }

    void CheckPass(string pass)
    {
        if (pass == password)
        {
            WinScreen();
        }
        else
        {
            StartGame();
        }
    }

    void WinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowReward();
        TypeMenu();
    }

    void ShowReward()
    {
        switch (choice)
        {
            case 1:
                Terminal.WriteLine("Congrats. Have a book...");
                Terminal.WriteLine(@"
    ________
   /       //
  /       //
 /______ //
(_______(/

                ");
                break;

            case 2:
                Terminal.WriteLine("Congrats. Have a mask...");
                Terminal.WriteLine(@"
                    
\\             // 
 \\           //
  \\         // 
   ( 0 ) ( 0 ) 
    |       |
   ( )_____( )  
                ");
                break;

            case 3:
                Terminal.WriteLine("Congrats. Have a gift...");
                Terminal.WriteLine(@"
 ____
|,--.|
||__||
|+  o|
|,'o | 
`----'                    
                ");
                break;
        }

    }

    void TypeMenu()
    {
        Terminal.WriteLine("Enter menu to return to Main Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
