using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform hudNextLevel;
    public RectTransform hudLevelCompleted;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Ship") {
            if (hudLevelCompleted != null) {
                if (hudNextLevel != null) { 
                //se entra al icono del siguiente nivel y se desbloquea a través de cambiar  una variable
                }
                hudLevelCompleted.gameObject.SetActive(true);
            }

            
            }
    }
}
