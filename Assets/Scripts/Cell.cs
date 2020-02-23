using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private MeshRenderer _mr;

    static MeshRenderer prev;
    private void OnMouseEnter()
    {
        Debug.Log(name);
         
    }

    private void OnMouseExit()
    {
        Debug.Log(name);
        
    }

    private void OnMouseUp()
    {
        if (prev != null)
        {
            prev.material.color = Color.white;
        }

        Debug.Log(name);

        _mr.material.color = Color.green;
        prev = _mr;
    }

    // Start is called before the first frame update
    void Start()
    {
        _mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
