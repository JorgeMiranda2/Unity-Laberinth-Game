using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public RectTransform pauseMenu;
    public RectTransform hud;
    public GameObject ship;
    public GameObject camera;
    GameObject[] _prefabLaser;
    GameObject _door;

    // Start is called before the first frame update
    void Awake()
    {
        _prefabLaser = GameObject.FindGameObjectsWithTag("Laser");
    }

    // Update is called once per frame
   
    public void ModePauseOn()
    {
        hud.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
        ship.GetComponent<Animator>().enabled = false;
        ship.GetComponent<ShipMovement>().enabled = false;
        camera.GetComponent<MovementCamera>().enabled = false;
        Time.timeScale = 0;
        foreach (GameObject _door in _prefabLaser)
        {
            Debug.Log(_door.name);
            
            //_door.GetComponent<wipeDoor>().enabled = false;

        }
    }

    public void ModePauseOff()
    {
        hud.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        ship.GetComponent<Animator>().enabled = true;
        ship.GetComponent<ShipMovement>().enabled = true;
        camera.GetComponent<MovementCamera>().enabled = true;
        Time.timeScale = 1;
        foreach (GameObject _door in _prefabLaser)
        {
            Debug.Log(_door.name);
            //_door.GetComponent<wipeDoor>().enabled = false;
           

        }
    }

}
