using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movewment : MonoBehaviour
{
    public float Velocidad;

    void ProcesarMovimiento()
    {

        float InputMovimiento = Input.GetAxis("Horizontal");
        Rigidbody2D rbd2D = GetComponent<Rigidbody2D>();

        rbd2D.velocity = new Vector2(InputMovimiento * Velocidad, rbd2D.velocity.y);



    }


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
    }
}
