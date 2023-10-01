using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShipMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float initialSpeed = 2f;
    public float speed = 0f;
    public bool isPlaying = false;
    Touch _firstTouch;
    float _areaWidth;
    float _middleHeight;
    bool _touchBegunInGameObject;

    private void Awake()
    {
        
    }
  


   public  void activateIsPlayingBool (){
        isPlaying = true;
        speed = initialSpeed;
    }


    // Update is called once per frame
    void Update()
    {
     /*   Debug.Log("Laser: "+GetComponent<Collitions>().touchLaser);
        Debug.Log("Wall: "+GetComponent<Collitions>().touchWall);
        Debug.Log("Isplaying: "+isPlaying);   */

             
        if (GetComponent<Collitions>().touchLaser == false && GetComponent<Collitions>().touchWall == false && isPlaying == true)
            {

            // para pc

          
               if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow) == false)
                {
                goUp();
                }

                if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow) == false)
                {
                goDown();
                }

                if (Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false || Input.GetKey(KeyCode.UpArrow) == true && Input.GetKey(KeyCode.DownArrow) == true)
                {

                stayRect();
                }

                        /*
               if(Input.touchCount > 0 )
            {
                 _firstTouch = Input.GetTouch(0);
                 _areaWidth = Screen.width/2;
                _middleHeight = Screen.height/2;

                if(_firstTouch.position.y > _middleHeight )
                {
                    goUp();
                } else if(_firstTouch.position.y <= _middleHeight )
                {
                    goDown();
                }
                      

            } else
            {
                stayRect();
               
            }


                */

            //para mobile

            if (Input.touchCount > 0 )
            {
                 _firstTouch = Input.GetTouch(0);
                 _areaWidth = Screen.width/2;
                _middleHeight = Screen.height/2;
                Debug.Log(_firstTouch.phase);
                if(_firstTouch.phase == TouchPhase.Began)
                {
                    if (EventSystem.current.IsPointerOverGameObject(_firstTouch.fingerId) == true)
                        _touchBegunInGameObject = true;
                    else
                        _touchBegunInGameObject = false;
                } 
                if (  _touchBegunInGameObject == false )
                        {
                    _touchBegunInGameObject = false;
                    if (_firstTouch.position.y > _middleHeight)
                            {
                                goUp();
                            }
                            else if (_firstTouch.position.y <= _middleHeight)
                            {
                                goDown();
                            }
                    
                    } else
                {
                //    stayRect();
                }
            }
            else
            {
             //   stayRect();

            }



        }  else
                  {
            speed = 0f;
                    }
           
        
       
    }
    void goUp()
    {
        transform.position = new Vector3(transform.position.x + speed  * Time.deltaTime, transform.position.y + speed * Time.deltaTime, transform.position.z);
       transform.localEulerAngles = new Vector3(0f, 0f, 45f);
     
    }

    void goDown()
    {
       transform.localEulerAngles = new Vector3(0f, 0f, -45f);
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y - speed * Time.deltaTime, transform.position.z);
    }

    void stayRect()
    {

       transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        transform.position = new Vector3(transform.position.x +  speed * Time.deltaTime, transform.position.y, transform.position.z);
    }


}
