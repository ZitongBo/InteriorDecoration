﻿//------------------------------------------------------------------------------
// Copyright 2016 Baofeng Mojing Inc. All rights reserved.
//------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MojingReport : MonoBehaviour {

    bool enterScene = true;
	// Use this for initialization
	void Start () {
        if (enterScene)
        {
            MojingSDK.Unity_AppPageStart(SceneManager.GetActiveScene().name);
#if !UNITY_EDITOR && UNITY_IOS
            MojingSDK.Unity_AppResume();
#endif
            enterScene = false;

        }
	}

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            MojingSDK.Unity_AppPageEnd(SceneManager.GetActiveScene().name);
#if !UNITY_EDITOR && UNITY_IOS
            MojingSDK.Unity_AppPause();
#endif
        }
    }

    void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus)
        {
#if !UNITY_EDITOR && UNITY_IOS
            MojingSDK.Unity_AppResume();
#endif
            MojingSDK.Unity_AppPageStart(SceneManager.GetActiveScene().name);
        }
    }

    public void SetEvent()
    {
        MojingSDK.Unity_AppSetEvent("SetEventTest","MojingSDK","ButtonDown",2,"DataBase",6);
    }

    public void ReportLog()
    {
        MojingSDK.Unity_AppReportLog(500, "MojingWorld", "{\"ERROR\":\"INVALID KEY\"}");
    }

    void OnDestroy()
    {
#if !UNITY_EDITOR && UNITY_IOS
            MojingSDK.Unity_AppPause();
#endif
        MojingSDK.Unity_AppPageEnd(SceneManager.GetActiveScene().name);
    }
}
