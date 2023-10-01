using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera : MonoBehaviour
{
    public GameObject shipMov; 
     float _speedShip;
    
              

    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if (shipMov != null)
        {
            _speedShip = shipMov.GetComponent<ShipMovement>().speed;
            transform.position = new Vector3(transform.position.x + _speedShip * Time.deltaTime, transform.position.y, transform.position.z);
        }

       
    }
}
