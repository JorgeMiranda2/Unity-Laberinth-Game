using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionShip : MonoBehaviour
{
    public GameObject particles;
    ParticleSystem _ps;

    // Start is called before the first frame update

    private void Awake()
    {
        _ps = particles.GetComponent<ParticleSystem>(); 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _ps.Play(true);
            Destroy(this.gameObject);
        }
    }
}
