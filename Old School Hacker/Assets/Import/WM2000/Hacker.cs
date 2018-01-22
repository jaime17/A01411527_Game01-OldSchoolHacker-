using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    
    //class atributes
    const string menuHint = "you can type menu at any time";
    string[] passwordLevel1 = { "book", "Class", "teacher", "room", "hour" };//These are password for diferent level
    string[] passwordLevel2 = { "pay", "bank", "FBI", "computerLab", "Omen" };// second level
    string[] passwordLevel3 = { "bangarang", "banamex", "perro", "gatonegro" };//third level
                                                                               // Use this for initialization
    int level;
    enum gameState { MainMenu, Password, Win}; //be declared a enumerated 
    gameState currentScreen = gameState.MainMenu;
    string password;
    bool changePassword;

    void Start () {
        showMainmenu();
	}

    private void showMainmenu()
    {
        Terminal.ClearScreen();
        Terminal.ClearScreen();
        Terminal.WriteLine("what do you want to hack today?");
        Terminal.WriteLine("1 Tom's collegue");
        Terminal.WriteLine("2 City");
        Terminal.WriteLine("3 IMB");
        Terminal.WriteLine("What is your option?");
        currentScreen = gameState.MainMenu;
        changePassword = true;
    }

    void OnUserInput(string input)
    {
        //If user inputs the meni keyword, then we call the showmenu
        if (input == "menu")
        {
            showMainmenu();
        }else if(input=="quit" || input=="close" || input == "exit") 
        {
            Terminal.WriteLine("Please, close the browser's tab");
            Application.Quit();
        }else if(currentScreen== gameState.MainMenu)
        {
            RunMainMenu(input);
        }else if(currentScreen==gameState.Password)
        {
            CheckPassword(input);
        }

        
    }

    private void CheckPassword(string input)
    {
        if (input == password) {
            DisplayWinScreen(input);
        }
        else
        {
            AskForPassword();
        }
    }

    private void DisplayWinScreen(string input)
    {
        currentScreen = gameState.Win;
        Terminal.ClearScreen();
        if (input == password)
        {
            ShowLevelReward();
        }
        else
        {
            CheckPassword(input);
        }
        Terminal.WriteLine(menuHint);
        
    }

    private void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You can put 10 in your calcification");
                break;

            case 2:
                Terminal.WriteLine("The city is yours");
                break;

            case 3:
                Terminal.WriteLine("You can play with the CEO from IMB");
                break;


        }
    }

    void RunMainMenu(string input)
    {
        bool isvalidInput = (input == "1") || (input == "2") || (input == "3");
        if (isvalidInput)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if(input=="007")
        {
            Terminal.WriteLine("Please enter a valid level, Mr. bond");
        }
        else
        {
            Terminal.WriteLine("Enter valid level");
        }
    }

    private void AskForPassword()
    {
        currentScreen = gameState.Password;

        Terminal.ClearScreen();
        if (changePassword)
        {
            SetRandomPassword();
        }
        Terminal.WriteLine("Enter your password. Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = passwordLevel1[UnityEngine.Random.Range(0,passwordLevel1.Length)];
                break;
            case 2:
                password = passwordLevel2[UnityEngine.Random.Range(0, passwordLevel2.Length)];
                break;
            case 3:
                password = passwordLevel3[UnityEngine.Random.Range(0, passwordLevel3.Length)];
                break;
            default:
                Debug.LogError("Invalid level. How did you manage that?");
                changePassword = true;
                break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
