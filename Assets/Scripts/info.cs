using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour
{
    [SerializeField]
    Transform infobox;
    Vector3 scaling = Vector3.zero;
    const float speed = 6f;

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        infobox.localScale = Vector3.Lerp(infobox.localScale, scaling, Time.deltaTime * speed);
    }
    public void openinfo()
    {
        scaling = Vector3.one;
    }
    public void closeinfo()
    {
        scaling = Vector3.zero;
    }
}
