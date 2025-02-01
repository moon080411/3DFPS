using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : Agent
{
    #region component region
    [field: SerializeField] public InputReader InputCompo { get; private set; }
    [field: SerializeField] public CinemachineVirtualCamera VirtualCamera { get; private set; }
    #endregion
    private Coroutine zoomCoroutine;
    public bool isZoomed = false;
    public override void InitializeState()
    {
        foreach (StateType stateType in Enum.GetValues(typeof(StateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"Player{enumName}State");
            State state = Activator.CreateInstance(t, new object[] { this }) as State;
            StateEnum.Add(stateType, state);
        }
    }
    protected override void Awake()
    {
        base.Awake();
        InputCompo.OnZoomKeyEvent += ZoomInOut;
        HealthCompo.OnDie += GameOver;
        InputCompo.OnAttackKeyEvent += Attack;
    }
    private void GameOver()
    {
        Time.timeScale = 0.2f;
        //게임오버 ui 틀기
    }

    protected override void Start()
    {
        base.Start();
        DataCompo.BaseZoom = VirtualCamera.m_Lens.FieldOfView;
    }
    private void ZoomInOut()
    {
        if (DataCompo.ZoomAmount == 1) return;
        if (zoomCoroutine == null)
        {
            zoomCoroutine = StartCoroutine(ChangeFOV(isZoomed));
        }
        else
        {
            StopCoroutine(zoomCoroutine);
            zoomCoroutine = StartCoroutine(ChangeFOV(isZoomed));
        }
    }
    public void SettingZoomInout(bool zoomed)
    {
        if (DataCompo.ZoomAmount == 1) return;
        if (zoomCoroutine == null)
        {
            zoomCoroutine = StartCoroutine(ChangeFOV(zoomed));
        }
        else
        {
            StopCoroutine(zoomCoroutine);
            zoomCoroutine = StartCoroutine(ChangeFOV(zoomed));
        }
    }
    private IEnumerator ChangeFOV(bool zoomed)
    {
        float endFOV, duration;
        isZoomed = !zoomed;
        if (!zoomed)
        {
            endFOV = DataCompo.BaseZoom / DataCompo.ZoomAmount;
            speed = DataCompo.speed / (DataCompo.RunSpeed * 1.5f);
        }
        else
        {
            endFOV = DataCompo.BaseZoom;
            speed = DataCompo.speed;
        }
        duration = DataCompo.ZoomedSpeed;
        float startFOV = VirtualCamera.m_Lens.FieldOfView;
        float time = 0;
        float fakeTime = time * DataCompo.ZoomedSpeed;
        while (LensChecker(VirtualCamera.m_Lens.FieldOfView , endFOV , zoomed))
        {
            VirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(startFOV, endFOV, fakeTime / 1);
            yield return null;
            time += Time.deltaTime;
            fakeTime = time * DataCompo.ZoomedSpeed;
        }
        VirtualCamera.m_Lens.FieldOfView = endFOV;
    }
    private bool LensChecker(float nowFOV ,float endFOV,bool zoomed)
    {
        switch (zoomed)
        {
            case true:
                return !(nowFOV >= endFOV);
            case false:
                return !(nowFOV <= endFOV);
        }
    }
}
