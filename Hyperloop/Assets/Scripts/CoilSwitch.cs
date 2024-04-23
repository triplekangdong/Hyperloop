using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilSwitch : MonoBehaviour
{
    [SerializeField] private Material[] CoilMaterial = new Material[2];
    [SerializeField] private GameObject[] Coilstand;
    private Material[] CoilStandMaterial;
    private int i = 0;
    public int ChangeMaterial()
    {
        i = ++i % 2;
        for (int j = 0; j < Coilstand.Length; j++)
        {
            Coilstand[j].GetComponent<MeshRenderer>().material = CoilMaterial[i];
        }
        return i;
    }
    public void DefalutChangeMaterial()
    {
        for (int j = 0; j < Coilstand.Length; j++)
        {
            Coilstand[j].GetComponent<MeshRenderer>().material = CoilMaterial[0];
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DefalutChangeMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeMaterial();
        }
    }
}