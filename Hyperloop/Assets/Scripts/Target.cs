using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private RaycastHit hit;
    private GameObject target = null;
    private int i = 0;
    [SerializeField] private GameObject UI;
    [SerializeField] private Text PartName;
    [SerializeField] private Text MaterialName;

    public void GetObjectInfo()
    {
        target = GetObject();
        if (target != null)
        {
            string partsname = target.name;
            string materialname = target.GetComponent<MeshRenderer>().material.name;
            string pole;
            if (materialname == "RedMetal (Instance)")
            {
                pole = "N";
                MaterialName.text = pole;
            }
            if (materialname == "BlueMetal (Instance)")
            {
                pole = "S";
                MaterialName.text = pole;
            }
            UI.gameObject.SetActive(true);
            PartName.text = partsname;
        }
    }
    public GameObject GetObject()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                i = ++i % 2;
                if (i == 0)
                {
                    target = hit.collider.gameObject;
                    return target;
                }
            }
        }
        return target;
    }

    // Update is called once per frame
    void Update()
    {

        GetObjectInfo();
    }
}