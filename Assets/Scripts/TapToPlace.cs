using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlace : MonoBehaviour
{
    public GameObject _gameobjecttoinstantiate;
    public GameObject _videogameobject;
    //public GameObject videomessage;
    //public GameObject message;
    private Vector2 touchposition;
    private Vector2 videotouchposition;
    private GameObject spawnedgameobject;
    private GameObject messagespawner;
    private GameObject videospawner;
    private GameObject spawnedvideoobject;
    private ARRaycastManager aRRaycastManager;
    private int numberofobjects;
    
    
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        
        
    }
    
    bool trygettouchposition(out Vector2 touchposition)
    {
        if(Input.touchCount>0)
        {
            touchposition = Input.GetTouch(0).position;
            return true;
        }
        touchposition = default;
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!trygettouchposition(out Vector2 touchposition))
            return;
        if(aRRaycastManager.Raycast(touchposition,hits,TrackableType.PlaneWithinPolygon))
        {
            var hitpose = hits[0].pose;
            if (numberofobjects==0)
            {
                spawnedgameobject = Instantiate(_gameobjecttoinstantiate, hitpose.position, hitpose.rotation);
                numberofobjects=1;
                
                StartCoroutine(waiting());
                    //messagespawner = Instantiate(message, spawnedgameobject.transform.position, spawnedgameobject.transform.rotation);
            }
            
            else if(numberofobjects ==1)
            {
                var hitpose2 = hits[1].pose;
                spawnedvideoobject = Instantiate(_videogameobject, hitpose2.position, hitpose2.rotation);
                    StartCoroutine(waiting());
                    //videospawner = Instantiate(videomessage, spawnedvideoobject.transform.position, spawnedvideoobject.transform.rotation);
                    numberofobjects=2;
            }
        }
        
    }
    IEnumerator waiting()
    {
        yield return new WaitForSeconds(1);
    }
}
