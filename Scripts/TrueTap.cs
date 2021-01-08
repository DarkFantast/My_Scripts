using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrueTap : MonoBehaviour
{
    public GameObject RedCircle1;
    public GameObject RedCircle2;
    public GameObject PanelWin;

    private void Start()
    {
        RedCircle1.SetActive(false);
        RedCircle2.SetActive(false);
        PanelWin.SetActive(false);
    }
    public void OnTap()
    {
        RedCircle1.SetActive(true);
        RedCircle2.SetActive(true);
        Invoke("ActivePanelWin", 1f);
    }

    void ActivePanelWin()
    {
        PanelWin.SetActive(true);
    }
}
