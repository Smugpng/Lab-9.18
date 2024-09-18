using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEvent : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private bool justSpawned = true;

    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
        virtualCamera.Follow = this.transform;
        
        Invoke("zoomBack", 3f);
    }
    private void Update()
    {
        if(justSpawned) virtualCamera.m_Lens.OrthographicSize += 1 * Time.deltaTime;

    }
    // Update is called once per frame
    public void zoomBack()
    {
        justSpawned = false;
        CameraBehavior behavior = FindAnyObjectByType<CameraBehavior>();
        behavior.lookAtME();
    }
}
