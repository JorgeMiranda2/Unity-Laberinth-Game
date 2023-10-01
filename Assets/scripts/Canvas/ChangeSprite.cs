using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    private Sprite _startSprite;
    public Sprite spriteToChange;
    public float _coolDown=3f;
    public bool spriteInCoolDown = false;
  


    // Start is called before the first frame update
    void Awake()
    {
        _startSprite = GetComponent<Image>().sprite; 
    }


     void Update()
    {
        if(spriteInCoolDown == true)
        {
            _coolDown -= Time.deltaTime;
            if(_coolDown <= 0)
            {
                resetSprite();
            }
        }
    }

    public void resetSprite()
    {
        this.gameObject.GetComponent<Image>().sprite = _startSprite;
        spriteInCoolDown = false;
        _coolDown = 3f;
    }

    public void makeTheCoolDown() {
        if (spriteInCoolDown == false) {
            spriteInCoolDown = true;
        }
    }

    public void Change()
    {
         if(spriteInCoolDown == false)
        {
            this.gameObject.GetComponent<Image>().sprite = spriteToChange;
           
            

        }
    }
}
