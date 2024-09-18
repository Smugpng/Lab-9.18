using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        virtualCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
        lookAtME();
    }

    public void lookAtME()
    {
        
        virtualCamera.Follow = this.transform;
        virtualCamera.m_Lens.OrthographicSize = 8;
    }
    public void Shake()
    {
        virtualCamera.enabled = false;
        CamShake shake = FindAnyObjectByType<CamShake>();
        shake.start = true;
        Invoke("EndShake", 2);
    }
    public void EndShake()
    {
        virtualCamera.enabled = true;
    }
}
