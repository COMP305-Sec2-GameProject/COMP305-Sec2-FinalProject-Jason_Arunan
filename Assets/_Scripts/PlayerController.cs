using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour {

    //PUBLIC INSTANCE VARIABLE
    public int count;

    public Text aquiredLabel;
    public Text timerLabel;
    public Text titleLabel;
    public Text instructLabel;

    public float timer;
    [HideInInspector]
    public float bestTime = 0;

    //PRIVATE INSTANCE VARIABLES
    private AudioSource[] _audioSources;
    private AudioSource _tick;
    private AudioSource _music;
    private AudioSource _pickup;
    //Stop all sounds
    private AudioSource[] allAudioSources;
    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

	// Use this for initialization
	void Start () {
        this.SetCount();

        this._audioSources = gameObject.GetComponents<AudioSource>();
        this._tick = this._audioSources[3];
        this._pickup = this._audioSources[1];
        this._music = this._audioSources[2];

        InvokeRepeating("PlayTicking", 114.5f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if(timer <= 115f)
        {
            this.titleLabel.enabled = false;
            this.instructLabel.enabled = false;
        }
        this.Timer();

        if(count >= 15)
        {
            //Time.timeScale = 0f;
            bestTime = timer;
            Application.LoadLevel("Win");
        }
	}

    void PlayTicking()
    {
        this._tick.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")) // If the other GameObject that collided with the player - is Enemy -
        {
            this._pickup.Play();
            count++;
            SetCount();
            Debug.Log("Adam Sandler Acquired");
            Destroy(other.gameObject); //Test - Collision with the Enemy will be a Game Over
        }
    }

    public void SetCount() // method to update to the current score upon killing enemies or picking up Gold and Silver coins
    {
        this.aquiredLabel.text = "Acquired: " + count + "/15"; // label equals this string statement - score is concatenated to string for display
    }
    public void Timer () // method to update to the current score upon killing enemies or picking up Gold and Silver coins
    {
        this.timerLabel.text = String.Format("{0:0}", timer); // label equals this string statement - score is concatenated to string for display

        if (timer <= 5f)
        {
            this.timerLabel.color = Color.red;
        }
        if (timer <= 0)
        {
            Application.LoadLevel("Game Over");
        }
    }
}
