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
    bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
    if (input == "007"){
      isBond = true;
      currentScreen = Screen.MainMenu;
      ShowMainMenu();
    } else if (isValidLevelNumber){
      level = int.Parse(input);
      StartGame();
    } else {
      Terminal.WriteLine("Please select a valid level.");
    }
  }

  // Start Game
  void StartGame(){
    currentScreen = Screen.Password;
    SetPassword();
    Terminal.ClearScreen();
    PromptAndHint();
  }

  // Other Funcs
  void HandleOnPassword(string input) {
    if (input == password) {
      DisplayWinScreen();
    }
    else {
      Terminal.WriteLine("Incorrect Password. You typed: " + input);
      PromptAndHint();
    }
  }

  void HandleOnWin(string input) {
    if (input == "Y") {
      currentScreen = Screen.MainMenu;
      ShowMainMenu();
    }
  }

  void SetPassword() {
    switch(level){
      case 1:
        password = levelOnePasswords[Random.Range(0, levelOnePasswords.Length)];
        break;
      case 2:
        password = levelTwoPasswords[Random.Range(0, levelTwoPasswords.Length)];
        break;
      case 3:
        password = levelThreePasswords[Random.Range(0, levelThreePasswords.Length)];
        break;
      default:
        Debug.LogError("Invalid Level Number");
        break;
    }
  }

  void DisplayWinScreen() {
    currentScreen = Screen.Win;
    Terminal.ClearScreen();
    ShowLevelReward();
  }

  void ShowLevelReward() {
    switch (level) {
      case 1:
        Terminal.WriteLine("Accept Gift 1");
        Terminal.WriteLine(@"
  ^%^
------
|    |
|    |
------
"       );
        break;
      case 2:
        Terminal.WriteLine("Accept Gift 2");
        Terminal.WriteLine(@"
__________
|   ##   |
|   %%   |
[--------]
 \      /
  \____/
"       );
        break;
      case 3:
        Terminal.WriteLine("Accept Gift 3");
        Terminal.WriteLine(@"
   ________
  //    //|
 //    // |
=======   |
|     |   |
|     |   |
|_____|//
"       );
        break;
      default:
        Debug.LogError("Invalid Level Number");
        break;
    }
    Terminal.WriteLine("Again? Y\\N");
  }

  void PromptAndHint() {
    Terminal.WriteLine("Enter your password: hint: " + password.Anagram());
  }
}
