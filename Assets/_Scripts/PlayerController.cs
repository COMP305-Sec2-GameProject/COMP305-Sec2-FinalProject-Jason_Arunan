using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour {

    public int count;

    public Text aquiredLabel;
    public Text timerLabel;
    public Text titleLabel;
    public Text instructLabel;

    public float deathTime;
    private float titleTime = 5;
    private float[] ticking = {5,6,7,8,9};

	// Use this for initialization
	void Start () {
        SetCount();
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time >= titleTime)
        {
            this.titleLabel.enabled = false;
            this.instructLabel.enabled = false;
        }
        Timer();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")) // If the other GameObject that collided with the player - is Enemy -
        {
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
        this.timerLabel.text = String.Format("{0:0}", Time.time); // label equals this string statement - score is concatenated to string for display

        if (Time.time >= ticking[0])
        {
            this.timerLabel.color = Color.red;
            if (Time.time >= ticking[1])
            {
            }
            if (Time.time >= ticking[2])
            {
            }
            if (Time.time >= ticking[3])
            {
            }
            if (Time.time >= ticking[4])
            {
            }
        }

        if (Time.time >= deathTime)
        {
            Application.LoadLevel("Game Over");
        }
    }
}
