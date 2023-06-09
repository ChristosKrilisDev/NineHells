using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Hell1 : MonoBehaviour
{
    public GameObject demoInteractPanel;

    [SerializeField] GameObject textPanel;
    [SerializeField] TextMeshProUGUI dialogueText;

    void Start()
    {
        TextRendererManager.instance.SetTextPanel(textPanel, dialogueText);
    }

    public void OnNpcHelped()
    {
        Debug.Log("Done!");
    }

    public void RaiseLadder(List<Transform> args)
    {
        args[0].GetComponent<BoxCollider>().enabled = false;
        args[0].DOLocalMove(args[1].localPosition, 0.4f).OnComplete(() =>
        {
            args[0].GetComponent<BoxCollider>().enabled = true;
        });
        args[0].DOLocalRotate(args[1].transform.eulerAngles, 0.4f);
    }

    public void ToggleInteractPanel()
    {
        demoInteractPanel.SetActive(!demoInteractPanel.activeInHierarchy);
    }
}
