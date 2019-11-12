using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

  bool isBond = false;
  int level = 0;
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
  }

  // Other Funcs
  void HandleOnPassword(string input){
    Terminal.WriteLine("Guessed password: " + input);
  }
}
