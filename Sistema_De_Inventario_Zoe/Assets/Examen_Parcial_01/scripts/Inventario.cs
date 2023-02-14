using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public List<GameObject> Bolsa = new List<GameObject>();
    public GameObject inventario;
    public bool Activar_Inventario;

    public GameObject Selector;
    public int ID;


    //tercera prueba//

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "Item")
        {

            for (int i = 0; i < Bolsa.Count; i++)
            {

                if (!Bolsa[i].GetComponent<Image>().enabled)
                {

                    Bolsa[i].GetComponent<Image>().enabled = true;
                    Bolsa[i].GetComponent<Image>().sprite = coll.GetComponent<SpriteRenderer>().sprite;
                    Destroy(coll.gameObject);
                    break;

                }

            }

        }

    }



    /*
        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.tag == "Item")
            {
                for (int i = 0; i < Bolsa.Count; i++)
                {
                    if (!Bolsa[i].activeSelf)
                    {
                        Bolsa[i].SetActive(true);
                        Bolsa[i].GetComponent<Image>().sprite = coll.GetComponent<SpriteRenderer>().sprite;
                        coll.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }*/


    // lo dejo por si acaso no sirve
    /*void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "Item")
        {

            for (int i = 0; i < Bolsa.Count; i++)
            {

                if (Bolsa[i].GetComponent<Image>().enabled = false)
                {

                    Bolsa[i].GetComponent<Image>().enabled = true;
                    Bolsa[i].GetComponent<Image>().sprite = coll.GetComponent<SpriteRenderer>().sprite; 
                    break;

                }
            
            }

        }

    }*/

    public void Navegar()
    {

        if (Input.GetKeyDown(KeyCode.D) && ID < Bolsa.Count - 1)
        {
            ID++;
        }
        if (Input.GetKeyDown(KeyCode.A) && ID > 0)
        {

            ID--;

        }
        if (Input.GetKeyDown(KeyCode.W) && ID > 5)
        {

            ID -= 5;

        }
        if (Input.GetKeyDown(KeyCode.S) && ID < 21)
        {

            ID += 5;

        }
        Selector.transform.position = Bolsa[ID].transform.position;



    }



    
    void Start()
    {
        
    }

   
    void Update()
    {
        Navegar();
        if (Activar_Inventario)
        {

            inventario.SetActive(true);

        }
        else
        {

            inventario.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.Return))
        {

            Activar_Inventario = !Activar_Inventario;

        }
        
    }
}
