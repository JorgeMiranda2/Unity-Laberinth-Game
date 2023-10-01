using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startPoint;
    public GameObject cameraShip;
    ShipMovement _movementComponent;
    public RectTransform hud;
   
    public bool resetDoorScale = false;
    public GameObject btnRed;
    public GameObject btnGreen;
    public GameObject prefabRed;
    public GameObject prefabGreen;
    GameObject[] _prefabLaser;    
    GameObject _door;


    void Awake()
    {
        _prefabLaser = GameObject.FindGameObjectsWithTag("Laser");


        _movementComponent = GetComponent<ShipMovement>();
    }

    private void Start()
    {
        
    }

    public void resetLevel()
    {


        StartCoroutine(ResetLvl());

    }

    public IEnumerator ResetLvl()
    {
        
        
            transform.position = startPoint.transform.position;
            cameraShip.transform.position = new Vector3(startPoint.transform.position.x + 3.04f, startPoint.transform.position.y + 0.21f, cameraShip.transform.position.z);
        GetComponent<Collitions>().shipFail = false;
        hud.gameObject.SetActive(true);
        resetDoorScale = true;
        GetComponent<Animator>().enabled = true;
        btnGreen.GetComponent<ChangeSprite>().resetSprite();
        btnRed.GetComponent<ChangeSprite>().resetSprite();
        GetComponent<Animator>().enabled = true;
        GetComponent<ShipMovement>().enabled = true;
        cameraShip.GetComponent<MovementCamera>().enabled = true;
        Time.timeScale = 1;
        foreach ( GameObject _door in _prefabLaser)
        {
            
            StartCoroutine(_door.GetComponent<wipeDoor>().ResetTheDoor());
        
        }
        yield return null;

        if (_movementComponent != null)
        {
            _movementComponent.speed = _movementComponent.initialSpeed;

        }

       
    }



}
