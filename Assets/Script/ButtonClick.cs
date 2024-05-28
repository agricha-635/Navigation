using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;

    [SerializeField] private Button backButton;
    [SerializeField] private Button forwardButton;

    private Stack<GameObject> panelHistory = new Stack<GameObject>();

    private Stack<GameObject> forwardPanelHistory = new Stack<GameObject>();

    private void Start()
    {
        SetActivePanel(0);
    }

    private void SetActivePanel(int index)
    {
        // Hide all panels
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

        // Show the specified panel
        panels[index].SetActive(true);

        Debug.Log(index);

        // Add the current panel index to history
        panelHistory.Push(panels[index]);

        if (forwardPanelHistory.Count > 0)
        {
            forwardPanelHistory.Pop();
        }

        foreach (GameObject panel in panelHistory)
        {
            Debug.Log(panel.name);
        }

        // PrintPanelHistory();
        // PrintForwardPanelHistory();

        Debug.Log("Forward: ");
        foreach (GameObject prevPanel in forwardPanelHistory)
        {
            Debug.Log(prevPanel.name);
        }

    }


    private void Update()
    {
        // Check for Android back button press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackBtnClick();
        }
    }

    public void OnHomeBtnClick()
    {
        SetActivePanel(1);
    }

    public void OnLoginBtnClick()
    {
        SetActivePanel(2);
    }

    public void OnLevelBtnClick()
    {
        SetActivePanel(3);
    }

    public void OnMainBtnClick()
    {
        SetActivePanel(0);
    }

    public void OnBackBtnClick()
    {

        if (panelHistory.Count > 1)
        {
            // Pop the current panel index
            GameObject currentPanel = panelHistory.Pop();
            currentPanel.SetActive(false);

            forwardPanelHistory.Push(currentPanel);

            // if (panelHistory.Count >= 0)
            // {
            //     currentPanel = panelHistory.Pop();
            //     currentPanel.SetActive(false);

            //     forwardPanelHistory.Push(currentPanel);
            // }

            // Get the previous panel index
            GameObject previousPanel = panelHistory.Peek();
            previousPanel.SetActive(true);
            foreach (GameObject panel in panelHistory)
            {
                Debug.Log(panel.name);
            }
            Debug.Log("Forward: ");
            foreach (GameObject prevPanel in forwardPanelHistory)
            {
                Debug.Log(prevPanel.name);
            }
        }
    }



    public void OnForwardBtnClick()
    {

        Debug.Log("Length of Forward History:" + forwardPanelHistory.Count);


        GameObject prevPanel = panelHistory.Peek();
        Debug.Log("Previous Panel: " + prevPanel.name);


        // Check if there are panels in the forward history
        if (forwardPanelHistory.Count > 0)
        {
            // Pop the previous panel index from the forward history
            GameObject currentPanel = forwardPanelHistory.Pop();
            Debug.Log("Current Panel: " + currentPanel.name);
            currentPanel.SetActive(true);
            panelHistory.Push(currentPanel);

            prevPanel.SetActive(false);

        }
    }
    // private void PrintPanelHistory()
    // {
    //     Debug.Log(" Panel History:");
    //     foreach (GameObject panel in panelHistory)
    //     {
    //         Debug.Log(panel.name);
    //     }
    // }
    // private void PrintForwardPanelHistory()
    // {
    //     Debug.Log("Forward Panel History:");
    //     foreach (GameObject panel in forwardPanelHistory)
    //     {
    //         Debug.Log(panel.name);
    //     }
    // }

}