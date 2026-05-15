using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentoDeNotas : MonoBehaviour
{
   [SerializeField] GameObject[] notasVerdes;
   [SerializeField] GameObject[] notasRojas;
    static CuentoDeNotas instance;
    int recuentoVerde = 0;
    int recuentoRoja= 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NotaVerde"))
        {
            ConteoDeNotas(true);
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("NotaRoja"))
        {
            ConteoDeNotas(false);
            collision.gameObject.SetActive(false);
        }
    }
    void ConteoDeNotas(bool tipoDeNota)
    {
        if (tipoDeNota)
        {                  
            notasVerdes[recuentoVerde].SetActive(true);
            recuentoVerde++;
        }
        else
        {
           notasRojas[recuentoRoja].SetActive(true);
            recuentoRoja++;
        }
    }

}
