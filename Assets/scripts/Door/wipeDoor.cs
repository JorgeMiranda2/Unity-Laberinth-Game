using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class wipeDoor : MonoBehaviour
{
    public Transform touchPoint;
    public float checkRadius = 0.5f;
    public LayerMask stopLayer;
    bool _haveToStop = false;
    public GameObject Button;
    bool _isInCoolDown;
    public float speed = 1f;
    public float initialScale;
    public GameObject ship;
    bool _haveToReset = false;


    // Start is called before the first frame update
    private void Awake()
    {
        initialScale = gameObject.transform.localScale.y;
     

    }

   

    // Update is called once per frame
    void Update()
    {


       // Debug.Log(_haveToReset);
       

        

        if (touchPoint != null)
        {
            _haveToStop = Physics2D.OverlapCircle(touchPoint.position, checkRadius, stopLayer);
        }

       






        /*
        if (Input.GetKeyDown(KeyCode.H) && _isInCoolDown == false)
        {
            _isInCoolDown = true;
            
            StartCoroutine(WipeSprite());
           
        }
        if (Input.GetKeyDown(KeyCode.G) && _isInCoolDown == false && _haveToStop == true || Input.GetKeyDown(KeyCode.G) && transform.localScale.y >= 5f)
        {
            Debug.Log("aqui llega");
            _isInCoolDown = true;
            
            StartCoroutine(ReduceSprite());

        }
        */

    }


   public void Validate()
    {
     
        if (Button != null)
        {
            Debug.Log("funciona el objeto: " + this.gameObject.name);
            _haveToReset = false;
            _isInCoolDown = Button.GetComponent<ChangeSprite>().spriteInCoolDown;


            if (_isInCoolDown == false)
            {
              
                CheckDoorStatus();
                    

            }
          

        }
    }
    // arreglar: cuando se esta escalando no se resetea, activar _haveToReset y romper el ciclo
    public IEnumerator ResetTheDoor()
    {
      
        _haveToReset = true;
        yield return null;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, initialScale, gameObject.transform.localScale.z);
     //   Debug.Log(gameObject.transform.localScale.y + "-----" + this.gameObject.name);
        yield return null;
    }


    void CheckDoorStatus()
    {
        
        if (_haveToStop == true || transform.localScale.y > 0f)
        {
            StartCoroutine(ReduceSprite());
        } else
        {
            if(_haveToStop==false && transform.localScale.y == 0f)
            {
                StartCoroutine(WipeSprite());
            }
            
        }
        
          
    }

  
    IEnumerator WipeSprite()
    {
      
        while (_haveToStop == false &&  transform.localScale.y < 5f )
        {
            if (_haveToReset == true)
            {
                break;
            }

            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y + speed * Time.deltaTime);
            yield return null;
        }

       

        _haveToReset = false;

        yield return null;
    }
    IEnumerator ReduceSprite()
    {
       
            while ( transform.localScale.y > 0f )
            {

            if (_haveToReset == true)
            {
                break;
            }

            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y - speed * Time.deltaTime);
                if(transform.localScale.y < 0){
                    transform.localScale = new Vector2(transform.localScale.x,0f);
                }
           



            yield return null;
            }

        _haveToReset = false;

        yield return null;
    }

    //Nota mental: se escala el game object, pero el _haveToStop lo hace el hijo
}
