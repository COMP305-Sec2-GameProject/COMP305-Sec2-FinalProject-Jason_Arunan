using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int Lives;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy")) // If the other GameObject that collided with the player - is Enemy -
        {
            Debug.Log("Enemy Hit");
            Destroy(other.gameObject); //Test - Collision with the Enemy will be a Game Over
        }
    }
}
