using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    private Rigidbody2D rbd2D;
    [Header("Movimiento")]

    private float movimeintoHorizontal = 0f;

    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private float velocidadDeMovimeinto;
    [Range(0, 0.3f)][SerializeField] private float suavizadoDeMovimiento;

    private Vector3 velocidad = Vector3.zero;

    private bool miraDerecha = true;


    //actualizacion, no funciono
    //pequeña prueba de fuego pq ya son las 2 de la mañana y me levanta a las 5
   /* void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Item")
        {
            Bolsa.Add(coll.gameObject);
            coll.gameObject.SetActive(false);
        }
    }*/

    private void Start()
    {

        rbd2D = GetComponent<Rigidbody2D>();
    
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
        movimeintoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimeinto;


    }

    private void Saltar()
    {
        rbd2D.AddForce(new Vector2(0f, fuerzaDeSalto), ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {

        Mover(movimeintoHorizontal * Time.fixedDeltaTime);

    }

    private void Mover(float mover)
    {

        Vector3 velocidadObjetivo = new Vector2(mover, rbd2D.velocity.y);
        rbd2D.velocity = Vector3.SmoothDamp(rbd2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (mover > 0 && !miraDerecha)
        {

            Girar();

        }
        else if (mover < 0 && miraDerecha)
        {

            Girar();

        }

    }

    private void Girar()
    {

        miraDerecha = !miraDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;

    }


}
