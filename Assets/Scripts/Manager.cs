using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cameraGimble;
    public GameObject scenesContainer;
    public Vector3 outOfBridgePosition;

    private bool cameraStateFlag;
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
        cameraGimble.position = Vector3.Lerp(cameraGimble.position, targetCameraPosition, Time.deltaTime * 1.5f);
    }

    public void ToggleCameraPosition()
    {
        if (cameraStateFlag)
        {
            targetCameraPosition = defaultCameraPosition;
        }
        else
        {
            targetCameraPosition = outOfBridgePosition;
        }
        cameraStateFlag = !cameraStateFlag;
    }
}
