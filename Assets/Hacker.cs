using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

  bool isBond = false;
  int level = 0;
  string password;
  string[] levelOnePasswords = {"toast", "fringe", "cave"};
  string[] levelTwoPasswords = {"orangutan", "pineapple", "horsecarbatterystaple"};
  string[] levelThreePasswords = {"complicatedsituation", "unfathomablesadness", "strainedparentalrelationships"};
  enum Screen {MainMenu, Password, Win };
  Screen currentScreen = Screen.MainMenu;
  // Use this for initialization
  void Start () {
    ShowMainMenu();
  }

  // Update is called once per frame
  void Update () {

  }

  // Set the main menu (at any start)
  void ShowMainMenu () {
    Terminal.ClearScreen();
    if (!isBond){
      Terminal.WriteLine("Game Intro Message.");
    } else {
      Terminal.WriteLine("Choose a level agent bond");
    }
    Terminal.WriteLine("\n");
    Terminal.WriteLine("Easy Difficulty Description: 1");
    Terminal.WriteLine("Medium Difficulty Description: 2");
    Terminal.WriteLine("Hard Difficulty Description: 3");
    Terminal.WriteLine("\n");
    Terminal.WriteLine("Enter your selection:");
  }

  // User input Message handling
  void OnUserInput (string input) {
    if (input == "menu"){
      isBond = false;
      currentScreen = Screen.MainMenu;
      ShowMainMenu();
    } else if (currentScreen == Screen.MainMenu) {
      RunMainMenu(input);
    } else if (currentScreen == Screen.Password){
      HandleOnPassword(input);
    } else if (currentScreen == Screen.Win) {
      HandleOnWin(input);
    }
  }

  void RunMainMenu(string input){
    if (input == "007"){
      isBond = true;
      currentScreen = Screen.MainMenu;
      ShowMainMenu();
    } else if (input == "1"){
      level = 1;
      StartGame();
    } else if (input == "2"){
      level = 2;
      StartGame();
    } else if (input == "3"){
      level = 3;
      StartGame();
    } else {
      Terminal.WriteLine("Please select a valid level.");
    }
  }

  // Start Game
  void StartGame(){
    Terminal.WriteLine("You have chosen level " + level);
    currentScreen = Screen.Password;
    if (level == 1) {
      password = levelOnePasswords[Random.Range(0, levelOnePasswords.Length)];
    } else if (level == 2) {
      password = levelTwoPasswords[Random.Range(0, levelTwoPasswords.Length)];
    } else if (level == 3) {
      password = levelThreePasswords[Random.Range(0, levelThreePasswords.Length)];
    }
    Terminal.WriteLine("Please enter your password:");
  }

  // Other Funcs
  void HandleOnPassword(string input) {
    if (input == password) {
      Terminal.WriteLine("Congratulations! You Win!");
      Terminal.WriteLine("Again? Y/N");
      currentScreen = Screen.Win;
    }
    else {
      Terminal.WriteLine("Incorrect Password. You typed: " + input);
    }
  }

  void HandleOnWin(string input) {
    if (input == "Y") {
      currentScreen = Screen.MainMenu;
      ShowMainMenu();
    }
  }
}
