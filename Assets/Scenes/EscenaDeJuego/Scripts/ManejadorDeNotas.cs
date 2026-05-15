using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ManejadorDeNotas : MonoBehaviour
{
    [SerializeField] int cantidadMaximaDeNotas;

    List<int> textosRepetidosRojas = new List<int>();
    List<int> textosRepetidosVerdes = new List<int>();
    [SerializeField] List<Nota> notas;
    [SerializeField] NotaTipo tipoNotaVerde;
    [SerializeField] NotaTipo tipoNotaRoja;

    [SerializeField] int probabilidadNotaVerde;
    [SerializeField] int probabilidadNotaRoja;
    [SerializeField] int probabilidadNoNota;
    public static ManejadorDeNotas Instancia { get; private set; }

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instancia = this;
        }
    }
    private void OnValidate()
    {
        probabilidadNotaRoja = Mathf.Clamp(probabilidadNotaRoja, 0, 100);

        int restante = 100 - probabilidadNotaRoja;

        probabilidadNotaVerde = Mathf.Clamp(probabilidadNotaVerde, 0, restante);

        probabilidadNoNota = 100 - probabilidadNotaRoja - probabilidadNotaVerde;
    }
    public void GenerarNotas()
    {
        int cantidadDeNotas = Random.Range(0, cantidadMaximaDeNotas + 1);

        for (int i = 0; i < cantidadDeNotas; i++)
        {
            int tipoDeNota = NumerosConMayorProbabilidad();

            if (tipoDeNota == 2) continue;

            NotaTipo tipoNota = tipoDeNota == 0 ? tipoNotaRoja : tipoNotaVerde;
            ActivarNotas(tipoNota);
        }
    }

    void ActivarNotas(NotaTipo tipoNota)
    {

        if (notas.Count == 0) return;

        Nota nota = ObtenerNotaLibre();
        if (nota == null) return;

        string texto = ObtenerTextosSinRepetir(tipoNota);

        nota.Configurar(texto, tipoNota.material);
        nota.gameObject.SetActive(true);
    }

    Nota ObtenerNotaLibre()
    {
        foreach (var nota in notas)
        {
            if (!nota.gameObject.activeInHierarchy)
            {
                return nota;
            }
        }
        return null;
    }
    int NumerosConMayorProbabilidad()
    {
        int numeroRandom = Random.Range(0, 100);
        if (numeroRandom < probabilidadNotaRoja)
        {
            return 0;
        }
        else if (numeroRandom < probabilidadNotaRoja + probabilidadNotaVerde)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    public void ReiniciarNotas()
    {
        Desactivar();
    }
    string ObtenerTextosSinRepetir(NotaTipo tipo)
    {
        List<int> textosRepetidos;

        if (tipo == tipoNotaRoja)
            textosRepetidos = textosRepetidosRojas;
        else
            textosRepetidos = textosRepetidosVerdes;

        if (textosRepetidos.Count >= tipo.textos.Count)
        {
            textosRepetidos.Clear();
        }
   
        int indice;

        do
        {
            indice = Random.Range(0, tipo.textos.Count);
        } while (textosRepetidos.Contains(indice));

        textosRepetidos.Add(indice);

        return tipo.textos[indice];
    }
    void Desactivar()
    {
        foreach (Nota nota in notas)
        {
            nota.gameObject.SetActive(false);
        }
    }
}

