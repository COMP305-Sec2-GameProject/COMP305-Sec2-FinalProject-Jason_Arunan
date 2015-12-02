using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public Text finalAcquiredLabel;
    public ScoreController scScript;
    public GameObject timeController;
    // Use this for initialization
    void Awake()
    {
        timeController = GameObject.FindWithTag("TimeController");
        GameObject scoreController = GameObject.FindWithTag("ScoreController"); //create reference for Player gameobject, and assign the variable via FindWithTag at start
        if (scoreController != null) // if the playerObject gameObject-reference is not null - assigning the reference via FindWithTag at first frame -
        {
            scScript = scoreController.GetComponent<ScoreController>();// - set the PlayerController-reference (called playerControllerScript) to the <script component> of the Player gameobject (via the gameObject-reference) to have access the instance of the PlayerController script
        }
        if (scoreController == null) //for exception handling - to have the console debug the absense of a player controller script in order for this entire code, the code in the GameController to work
        {
            Debug.Log("Cannot find ScoreController script for final score referencing to GameOver - finalAcquired Label");
        }
    }

    void Start()
    {
        this.finalAcquiredLabel.text = "Acquired: " + scScript.finalScore + "/15";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))//check for the key press if it is R, then -
        {
            Destroy(timeController);
            Destroy(scScript.gameObject);
            Application.LoadLevel("Main"); // - reload the current loaded level/scene file
        }
    }

}
