using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cameraGimble;
    public GameObject scenesContainer;
    public GameObject transition;
    public Vector3 outOfBridgePosition;

    private bool isTransitioning;
    private int currentScene;
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
            scenesContainer.transform.GetChild(i).gameObject.SetActive(false);
            scenes.Add(scenesContainer.transform.GetChild(i).gameObject);
        }
        scenes[0].SetActive(true);
        transition.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraGimble.position = Vector3.Lerp(cameraGimble.position, targetCameraPosition, Time.deltaTime * 1.5f);
    }

    private void IncrementScene(int amount)
    {
        currentScene += amount;
        if (currentScene >= scenes.Count)
        {
            currentScene = 0;
        }
        else if (currentScene < 0)
        {
            currentScene = scenes.Count - 1;
        }
    }

    private async void ExecuteTransitionAnimation(Action callBack)
    {
        transition.SetActive(true);
        await Task.Delay(5000);
        transition.SetActive(false);
        callBack();
    }
    public void ChangeEvent()
    {
        if (isTransitioning)
            return;

        isTransitioning = true;

        void EndScene()
        {
            scenes[currentScene].SetActive(true);
            isTransitioning = false;
        }

        scenes[currentScene].SetActive(false);
        IncrementScene(1);
        ExecuteTransitionAnimation(EndScene);
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
