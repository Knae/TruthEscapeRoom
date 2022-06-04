using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//includes for file reading
using System.IO;
using System.Text;

//includes for dialogue text ui
using UnityEngine.UI;

public class DialogueFileReader : MonoBehaviour {
    //to change dialogue create or modify .txt files in Assets/DialogueTextFiles making sure the file name matches in ReadFullDayDialogue parameters
    //to use connect a UI Text object to the script for the dialogue to write to

    //UI text to modify
    public Text neighbourDialogueText;

    //stores full string from file and the 'cut-up' string array of dialogue sections
    string currentDialogue;
    string[] currentSectionedDialogue = new string[100]; //this size should be enough
    int dialogueSectionAmount = 0;

    bool startedSpeaking = false;
    bool speak = true;
    float charTimer;
    int currentDialogueChar;
    char[] completeDialogue;
    string spokenDialogue;

    int currentDialogueSection = 0;

    float skipDialogueTimer = 0;


    void Start() {
        string day = StaticVariables.iDay.ToString();
        string fileName = "dialogueDay" + day + ".txt"; //create filename of text matching current day
        ReadFullDayDialogue(fileName);
        SplitFullDayDialogue();
    }
    void Update() {
        if (currentDialogueSection < dialogueSectionAmount) { //if there is still dialogue left
            skipDialogueTimer += Time.deltaTime;

            if (speak) {
                SpeakDialogueSection(currentDialogueSection, 0.08f);
            }

            if (Input.anyKeyDown && !speak && skipDialogueTimer > 0.1f) {
                currentDialogueSection += 1;
                speak = true;
                skipDialogueTimer = 0;
            }
        }
        else { //if there is no dialogue left
            if (Input.anyKeyDown) { //exit dialogue interaction
                neighbourDialogueText.text = "";
            }
        }
    }


    //Reads all text from a file. Stores this text within currentDialogue.
    //String textFileName gives it the file to read e.g. input "dialogueText.txt"
    public void ReadFullDayDialogue(string textFileName) {
        string path = Application.dataPath + "/DialogueTextFiles/" + textFileName;
        string fullDialogue = File.ReadAllText(path);

        currentDialogue = fullDialogue;
    }


    //Splits the existing currentDialogue string into a string array containing each section of dialogue as individual parts. Stores this inside currentSectionedDialogue.
    //Only call after calling ReadFullDayDialogue()
    public void SplitFullDayDialogue() {
        int currentLine = 0;
        StringBuilder dialogueSB = new StringBuilder("");

        foreach (char currentChar in currentDialogue) {
            //if marker is found ('|') finish this section of dialogue, input to array, then move to next section of dialogue to be read (incriment array). Otherwise continue reading to current array string.
            if (currentChar == '|') {
                currentSectionedDialogue[currentLine] = dialogueSB.ToString();
                dialogueSB.Clear();
                currentLine += 1;
            }
            else {
                dialogueSB.Append(currentChar);
            }
        }

        if (dialogueSB.Length > 0) {
            currentSectionedDialogue[currentLine] = dialogueSB.ToString();
            dialogueSB.Clear();
            currentLine += 1;

            dialogueSectionAmount = currentLine; //stores the amount of dialogue sections there are to limit reading over the available dialogue later.
        }
    }


    //Adds characters of a section of dialogue incrimentally to the UI Text to give the appearance of ongoing speech
    public void SpeakDialogueSection(int section, float timeBetweenCharacters) {
        if (!startedSpeaking) {
            charTimer = 0;
            currentDialogueChar = 0;
            completeDialogue = currentSectionedDialogue[section].ToCharArray();
            spokenDialogue = "";
            startedSpeaking = true;
        }

        charTimer += Time.deltaTime;

        if (spokenDialogue.Length == completeDialogue.Length) {
            startedSpeaking = false;
            speak = false; //allows control of function running within update with seperate bool
            return;
        }
        else {
            if (charTimer > timeBetweenCharacters) {
                spokenDialogue += completeDialogue[currentDialogueChar];
                neighbourDialogueText.text = spokenDialogue;
                currentDialogueChar += 1;
                charTimer = 0;
            }
        }

        if (Input.anyKeyDown && skipDialogueTimer > 0.1f) { //allows the player to skip to the end of the dialogue section by pressing any key
            spokenDialogue = currentSectionedDialogue[section];
            neighbourDialogueText.text = spokenDialogue;
            startedSpeaking = false;
            speak = false; //allows control of function running within update with seperate bool
            skipDialogueTimer = 0;
            return;
        }
    }
}
