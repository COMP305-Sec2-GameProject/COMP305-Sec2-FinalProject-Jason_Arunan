using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class WinController : MonoBehaviour {

	public Text finalTimeLabel;
    public TimeController tcScript;
    public GameObject scoreController;
    // Use this for initialization
    void Awake()
    {
        scoreController = GameObject.FindWithTag("ScoreController");
        GameObject timeController = GameObject.FindWithTag("TimeController"); //create reference for Player gameobject, and assign the variable via FindWithTag at start
        if (timeController != null) // if the playerObject gameObject-reference is not null - assigning the reference via FindWithTag at first frame -
        {
            tcScript = timeController.GetComponent<TimeController>();// - set the PlayerController-reference (called playerControllerScript) to the <script component> of the Player gameobject (via the gameObject-reference) to have access the instance of the PlayerController script
        }
        if (timeController == null) //for exception handling - to have the console debug the absense of a player controller script in order for this entire code, the code in the GameController to work
        {
            Debug.Log("Cannot find ScoreController script for final score referencing to GameOver - finalAcquired Label");
        }
    }

    void Start()
    {
        this.finalTimeLabel.text = "Best Time: " + String.Format("{0:0.000}", tcScript.finalTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))//check for the key press if it is R, then -
        {
            Destroy(scoreController);
            Destroy(tcScript.gameObject);
            Application.LoadLevel("Main"); // - reload the current loaded level/scene file
        }
    }
}
