using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collitions : MonoBehaviour
{
   public  bool touchWall = false;
    public bool touchLaser = false;
    public LayerMask wallLayer;
    public LayerMask laserLayer;
    public float checkArea = 0.5f;
    public GameObject particles;
    ParticleSystem _ps;
    public bool shipFail = false;
    public RectTransform reTryMenu;
    public RectTransform hud;
    private AudioSource _audioExplosion;




    private void Awake()
    {
        _audioExplosion = GetComponent<AudioSource>();
        _ps = particles.GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        touchWall = Physics2D.OverlapCircle(transform.position, checkArea, wallLayer);
        touchLaser = Physics2D.OverlapCircle(transform.position, checkArea, laserLayer);
                         if(shipFail == false)
        {
            if (touchWall == true || touchLaser == true)
            {

                StartCoroutine(ExploteShip());


            }
        }
         
        
        
    }

    IEnumerator ExploteShip()
    {

        shipFail = true;
        _audioExplosion.Play();
        _ps.Play(true);
        //  Destroy(this.gameObject, 0.4f);
        
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
        GetComponent<Animator>().enabled = false;
        hud.gameObject.SetActive(false);
        reTryMenu.gameObject.SetActive(true);
        GetComponent<ShipMovement>().isPlaying = false;

    }

   
}
