using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool enableTilt;
    public float tiltIntensity = 1;
    public float tiltPeriod = 1;
    public Transform bridgeAssembly;
    public Transform wallProjector;
    public Transform gimble;
    public GameObject scenesContainer;
    public GameObject transition;
    public Vector3 outOfBridgePosition;
    public Vector3 transitionIntermediatePosition;
    public Vector3 transitionPosition;
    public AudioSource enterHyperspaceSound;
    public AudioSource exitHyperspaceSound;

    private bool isTransitioning;
    private int currentScene;
    private bool cameraStateFlag;
    private float transitionLerpTime;

    private Vector3 defaultCameraPosition;
    private Vector3 defaultGimblePosition;

    private Vector3 targetCameraPosition;
    private Vector3 targetGimblePosition;
    //private Quaternion targetCameraRotation;
    private List<GameObject> scenes = new List<GameObject>();

    private void Awake()
    {
        defaultCameraPosition = wallProjector.transform.localPosition;
        defaultGimblePosition = gimble.transform.localPosition;

        targetCameraPosition = wallProjector.transform.localPosition;
        targetGimblePosition = gimble.transform.localPosition;

        //defaultCameraRotation = cameras.transform.rotation;
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
        wallProjector.localPosition = Vector3.Lerp(wallProjector.localPosition, targetCameraPosition, Time.deltaTime * 1.5f);
        gimble.localPosition = Vector3.Lerp(gimble.localPosition, targetGimblePosition, Time.deltaTime * transitionLerpTime);
        
        if (enableTilt)
        {
            
            bridgeAssembly.rotation = Quaternion.Euler(new Vector3(0, 0, tiltIntensity * Mathf.Sin(Time.realtimeSinceStartup/tiltPeriod)));
        }
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
        enterHyperspaceSound.PlayOneShot(enterHyperspaceSound.clip, 1f);
        transition.SetActive(true);
        transitionLerpTime = 0.3f;
        targetGimblePosition = transitionIntermediatePosition;
        await Task.Delay(2000);
        transitionLerpTime = 3;
        targetGimblePosition = transitionPosition;
        await Task.Delay(8000);
        transitionLerpTime = 2;
        targetGimblePosition = defaultGimblePosition;
        exitHyperspaceSound.PlayOneShot(exitHyperspaceSound.clip, 1f);
        callBack();
    }
    public async void ChangeEvent()
    {
        if (isTransitioning)
            return;

        isTransitioning = true;

        async void EndScene()
        {
            scenes[currentScene].SetActive(true);
            await Task.Delay(3000);
            transition.SetActive(false);
            isTransitioning = false;
        }

        ExecuteTransitionAnimation(EndScene);
        await Task.Delay(2000);
        scenes[currentScene].SetActive(false);
        IncrementScene(1);
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
