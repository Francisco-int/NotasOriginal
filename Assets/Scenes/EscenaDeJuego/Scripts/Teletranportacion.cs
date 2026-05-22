using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletranportacion : MonoBehaviour
{
    [SerializeField] Transform puntoTeletransporte;

    // Start is called before the first frame update
    void Start()
    {
        ManejadorDeNotas.Instancia.ReiniciarNotas();
        ManejadorDeNotas.Instancia.GenerarNotas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = puntoTeletransporte.transform.position;
            ManejadorDeNotas.Instancia.ReiniciarNotas();
            ManejadorDeNotas.Instancia.GenerarNotas();
        }
    }
}
