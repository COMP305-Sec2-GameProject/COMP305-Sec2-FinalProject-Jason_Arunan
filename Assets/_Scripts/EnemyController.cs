using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    // PUBLIC PROPERTIES
    public Transform target;
    public float speed;
    public float triggerDistance;
    // PRIVATE PROPERTIES
    private float _targetDistance;
    private Transform _transform;

    // Use this for initialization
    void Start()
    {
        this._transform = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        this._targetDistance = Vector3.Distance(this._transform.position, target.position);
        if(this._targetDistance <= triggerDistance){
        this._transform.position = Vector3.MoveTowards(this._transform.position, target.position, speed);
        }
        Debug.Log(this._targetDistance);
    }
}
