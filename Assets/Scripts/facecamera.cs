
using UnityEngine;

[ExecuteInEditMode]
public class facecamera : MonoBehaviour
{
    Transform cam;
    Vector3 angle = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam);
        angle = transform.localEulerAngles;
        angle.x = 0;
        angle.z = 0;
        transform.localEulerAngles = angle;
    }
}
