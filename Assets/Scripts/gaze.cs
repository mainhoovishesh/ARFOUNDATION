using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class gaze : MonoBehaviour
{
    List<info> infos = new List<info>();
    private void Start()
    {
        infos = FindObjectsOfType<info>().ToList();
    }
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if(go.CompareTag("hasinfo"))
            {
                openinfo(go.GetComponent<info>());
            }
            else
            {
                closeall();
            }
            
        }
    }
    void openinfo(info desiredinfo)
    {
        foreach(info Info in infos)
        {
            if(Info==desiredinfo)
            {
                Info.openinfo();
            }
            else
            {
                Info.closeinfo();
            }
        }
    }
    void closeall()
    {
        foreach(info Info in infos)
        {
            Info.closeinfo();
        }
    }
}
