using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Nota : MonoBehaviour
{
    [SerializeField] Text textoNota;
    [SerializeField] MeshRenderer renderer;
    //
    public void Configurar(string texto, Material material)
    {
        textoNota.text = texto;
        renderer.material = material;
    }
}
