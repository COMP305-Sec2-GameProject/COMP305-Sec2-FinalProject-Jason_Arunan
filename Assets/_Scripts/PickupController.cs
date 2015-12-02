using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

    public Transform[] pickupSpawns; // an array transform components of the coinSpawn empty gameobjects
    public GameObject pickup; // reference to hold coin gameObject

    // Use this for initialization
    void Start()
    {
        Spawn(); // at first frame, call Spawn method
    }

    void Spawn() // method that spawns coins on a loop the size of the transform array
    {
        for (int i = 0; i < pickupSpawns.Length; i++)
        {
                Instantiate(pickup, pickupSpawns[i].position, pickupSpawns[i].rotation); // instantiate coin gameObject, at the coinSpawn tranform of the current loop index
        }
    }
}
