using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float velocity=1f;
    public float _prueba = 1f;
     Vector2 _direction = new Vector2(1,0);
    Vector2 _speedFinal;


    // Start is called before the first frame update
    private void Awake()
    {
        
    }

  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector2(transform.position.x + velocity * Time.deltaTime , transform.position.y );  
        
        _speedFinal = _direction.normalized * velocity * Time.deltaTime ;
     
        transform.Translate(_speedFinal);
   
        _direction = new Vector2(1f, 0f);
        if ((Input.GetKey(KeyCode.UpArrow)==true && Input.GetKey(KeyCode.DownArrow) == false) || _prueba==1f )
        {


            transform.eulerAngles = new Vector3(0f, 0f, 45f);

          

        }  

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow) == false )
        {

            transform.eulerAngles = new Vector3(0f, 0f, -45f);

          
           
        }

        if(Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false )
        {
            transform.eulerAngles = new Vector3(0f,0f,0f);
          
            
            
        }
    }
}
