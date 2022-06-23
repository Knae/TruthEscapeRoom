using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//includes for file reading
using System.IO;
using System.Text;

//includes for dialogue text ui
using UnityEngine.UI;

//for array stuff
using System;

public class DialogueFileReader : MonoBehaviour {
    //to change dialogue create or modify .txt files in Assets/DialogueTextFiles making sure the file name matches in ReadFullDayDialogue parameters
    //to use connect a UI Text object to the script for the dialogue to write to

    //UI text to modify
    public Text targetText;
    public GameObject textDisplayBox;

    public GameObject neighbourInteractSprite;

    //sprites for neighbour expressions
    public Sprite angry;
    public Sprite sheepish;
    public Sprite standard;
    public Sprite irritated;
    public Sprite smiling;
    public Sprite shocked;

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

    //variables to dictate dialogue shake
    public float shakeSpeed = 100.0f;
    public float shakeAmount = 1.0f;
    bool shake = false;
    Vector2 originalTextDisplayBoxPos;

    //timer for automatic text
    float autoTimer = 0;
    //timer for automatic text delay time between text
    public float autoDelayTime;

    //time between characters
    public float timeIntervalBetweenCharacters = 0;

    //whether the dialogue is controlled by the player or not
    public bool playerControlled;

    //if the dialogue is from the neighbour or not
    public bool isNeighbourDialouge;

    //if dialogue is for sounds from next-door/neighbour
    public bool isNeighbourNextDoorSounds;

    //filename for any other dialogue if not neighbour dialogue
    public string dialogueFileName;

    //if dialogue should loop or not (if automated)
    public bool loops;

    //used to stop dialogue
    public bool stopDialogue = false;


    //change text object for dialogue/text to be written to
    public void SetTextObj(ref Text newText) { targetText = newText; }


    //---//---//---//

    void Start() {
        textDisplayBox.SetActive(true);

        if (isNeighbourDialouge) { //if neighbour dialogue automate file loading according to day
            if (StaticVariables.iNeighbourInteractions < 3) {
                string sectionNum = StaticVariables.iNeighbourInteractions.ToString();
                string fileName = "Section" + sectionNum + ".txt"; //create filename of text matching current day

                InitialiseDialogue(fileName);
            }
            else {
                stopDialogue = true;
            }
        }
        else if (!isNeighbourNextDoorSounds) {
            InitialiseDialogue(dialogueFileName);
        }

        if(currentSectionedDialogue == null)
		{
            currentSectionedDialogue = new string[100];
		}

        //stores the original position of the text box to reset after shaking
        originalTextDisplayBoxPos = textDisplayBox.transform.position;
    }

    void Update() {
        if (!stopDialogue) {
            if (playerControlled) {
                PlayerInputTextUpdate();
            }
            else {
                print("going going goung");
                AutoTextUpdate(autoDelayTime);
            }
        }
        else {
            //clear text
            targetText.text = "";
            textDisplayBox.SetActive(false);
        }

        if (StaticVariables.bInteractingWithNeighbour && isNeighbourDialouge) {
            stopDialogue = false;
            textDisplayBox.SetActive(true);
        }
    }

    //---//---//---//


    //initialise dialogue
    public void InitialiseDialogue(string fileName) {
        ReadFullDayDialogue(fileName);
        SplitFullDayDialogue();
    }

    //automatic text update with delay
    public void AutoTextUpdate(float delay) {
        if (currentDialogueSection < dialogueSectionAmount) { //if there is still dialogue left
            //add to timer
            autoTimer += Time.deltaTime;

            if (speak) {
                SpeakDialogueSection(currentDialogueSection, timeIntervalBetweenCharacters);
            }

            if (autoTimer > delay && !speak) {
                currentDialogueSection += 1;
                speak = true;
                autoTimer = 0;
            }
        }
        else { //if there is no dialogue left
            if (loops) {
                currentDialogueSection = 0;
            }
            else {
                targetText.text = "";
                textDisplayBox.SetActive(false);
            }
        }
    }

    //player controlled text update skipping & advancing with user input
    public void PlayerInputTextUpdate() {
        if (currentDialogueSection < dialogueSectionAmount) { //if there is still dialogue left
            skipDialogueTimer += Time.deltaTime;

            if (speak) {
                SpeakDialogueSection(currentDialogueSection, timeIntervalBetweenCharacters);
            }

            if (Input.anyKeyDown && !speak && skipDialogueTimer > 0.1f) {
                currentDialogueSection += 1;
                speak = true;
                skipDialogueTimer = 0;
            }
        }
        else { //if there is no dialogue left
            if (Input.anyKeyDown) { //exit dialogue interaction
                targetText.text = "";
                StaticVariables.bInteractingWithNeighbour = false;
                StaticVariables.bNeighbourInteractionComplete = true;
                textDisplayBox.SetActive(false);
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

        //find first char for any effects
        char firstChar = completeDialogue[0];
        if (firstChar == '!') { //! = shake
            //set shaking text to true
            shake = true;

            //remove first char
            char[] resizeArray = new char[completeDialogue.Length - 1];
            Array.Copy(completeDialogue, 1, resizeArray, 0, completeDialogue.Length - 1);
            completeDialogue = resizeArray;
        }
        else if (isNeighbourDialouge) { //if not ! check for emotion/sprite change symbols
            if (firstChar == '^') { //angry [^]
                changeNeighbourSpriteSetup(angry);
            }
            else if (firstChar == '%') { //sheepish [%]
                changeNeighbourSpriteSetup(sheepish);
            }
            else if (firstChar == '~') { //standard [~]
                changeNeighbourSpriteSetup(standard);
            }
            else if (firstChar == '&') { //irritated [&]
                changeNeighbourSpriteSetup(irritated);
            }
            else if (firstChar == '$') { //happy/smiling [$]
                changeNeighbourSpriteSetup(smiling);
            }
            else if (firstChar == '#') { //shocked/surprised [#]
                changeNeighbourSpriteSetup(shocked);
            }
        }

        charTimer += Time.deltaTime;

        if (spokenDialogue.Length == completeDialogue.Length) {
            startedSpeaking = false;
            shake = false;
            speak = false; //allows control of function running within update with seperate bool
            return;
        }
        else {
            if (charTimer > timeBetweenCharacters) {
                spokenDialogue += completeDialogue[currentDialogueChar];
                targetText.text = spokenDialogue;
                currentDialogueChar += 1;
                charTimer = 0;
            }
        }

        if (shake) { //if shake == true then shake the dialogue box
            textDisplayBox.transform.position = new Vector2(originalTextDisplayBoxPos.x + Mathf.Sin(Time.time * shakeSpeed) * shakeAmount,
                originalTextDisplayBoxPos.y + Mathf.Sin(Time.time * shakeSpeed) * shakeAmount);
        }

        if (Input.anyKeyDown && skipDialogueTimer > 0.1f && playerControlled) { //allows the player to skip to the end of the dialogue section by pressing any key (if dialogue is player controlled)
            string fullString = new string(completeDialogue);
            spokenDialogue = fullString;
            targetText.text = spokenDialogue;
            startedSpeaking = false;
            speak = false; //allows control of function running within update with seperate bool
            shake = false;
            skipDialogueTimer = 0;
            return;
        }
    }

    void changeNeighbourSpriteSetup(Sprite sprite) {
        //remove first char
        char[] resizeArray = new char[completeDialogue.Length - 1];
        Array.Copy(completeDialogue, 1, resizeArray, 0, completeDialogue.Length - 1);
        completeDialogue = resizeArray;

        //set sprite
        neighbourInteractSprite.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    IEnumerator DelaySound(AudioClip sound, float delayFloat = 1)
    {
        yield return new WaitForSeconds(delayFloat);

        //play sound
        SoundManager.instance.Sound.PlayOneShot(sound);
    }

    public void SetNeighbourNextDoorSoundsStart() {
        if (StaticVariables.iDay > 1 && StaticVariables.iDay != 5) {
            //set text file for reading
            string sectionNum = StaticVariables.iDay.ToString();
            string fileName = "NeighbourSounds" + sectionNum + ".txt"; //create filename of text matching current day
            InitialiseDialogue(fileName);
            if (StaticVariables.iDay == 2)
            {
                StartCoroutine(DelaySound(SoundManager.instance.Bang1, 0));
                StartCoroutine(DelaySound(SoundManager.instance.Crash, 1.8f));
            }
            else if (StaticVariables.iDay == 3)
            {
                StartCoroutine(DelaySound(SoundManager.instance.Thump, 0));
                StartCoroutine(DelaySound(SoundManager.instance.Thump, 1.7f));
                StartCoroutine(DelaySound(SoundManager.instance.Bang2, 3.3f));
                StartCoroutine(DelaySound(SoundManager.instance.Yell2, 4));
            }
            else if (StaticVariables.iDay == 4)
            {
                StartCoroutine(DelaySound(SoundManager.instance.Crash, 0));
                StartCoroutine(DelaySound(SoundManager.instance.Yell1, 1.8f));
            }
            else if (StaticVariables.iDay == 6)
            {
                StartCoroutine(DelaySound(SoundManager.instance.Yell2, 0));
                StartCoroutine(DelaySound(SoundManager.instance.Crash, 1.5f));
                StartCoroutine(DelaySound(SoundManager.instance.Thump, 3.5f));
                StartCoroutine(DelaySound(SoundManager.instance.Bang2, 4.6f));
            }
            //set dialogue to start
            stopDialogue = false;
            textDisplayBox.SetActive(true);
        }
    }

    public void SetConfrontationDialogue() {
        //set dialogue to start
        stopDialogue = false;
        textDisplayBox.SetActive(true);
    }
}
