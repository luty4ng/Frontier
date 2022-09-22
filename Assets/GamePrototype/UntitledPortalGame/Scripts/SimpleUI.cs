using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleUI : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject pausePanel;
    public GameObject postProcessing;
    public void Quit()
    {
        Application.Quit();
    }

    private void Awake()
    {
        ActiveStartPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPanel(pausePanel, !pausePanel.activeInHierarchy);
        }
    }


    private void SetPanel(GameObject panel, bool state)
    {
        panel.SetActive(state);
        postProcessing.SetActive(state);
        Time.timeScale = state ? 0 : 1;
    }

    public void ActiveStartPanel() => SetPanel(startPanel, true);
    public void DeactiveStartPanel() => SetPanel(startPanel, false);
    public void DeactivePausePanel() => SetPanel(pausePanel, false);

}
