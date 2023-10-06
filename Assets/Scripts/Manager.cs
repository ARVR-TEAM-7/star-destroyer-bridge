using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cameraGimble;
    public GameObject scenesContainer;
    public Vector3 outOfBridgePosition;

    private Vector3 defaultCameraPosition;
    //private Quaternion defaultCameraRotation;

    private Vector3 targetCameraPosition;
    //private Quaternion targetCameraRotation;
    private List<GameObject> scenes = new List<GameObject>();

    private void Awake()
    {
        defaultCameraPosition = cameraGimble.transform.position;
        targetCameraPosition = cameraGimble.transform.position;
        //defaultCameraRotation = cameraGimble.transform.rotation;
        for (int i = 0; i < scenesContainer.transform.childCount; i++)
        {
            scenes.Add(scenesContainer.transform.GetChild(i).gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCameraOutOfBridge()
    {
        targetCameraPosition = outOfBridgePosition;
    }

    public void MoveCameraIntoBridge()
    {
        targetCameraPosition = defaultCameraPosition;
    }
}
