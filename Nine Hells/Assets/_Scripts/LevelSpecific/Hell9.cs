using _Scripts.Character;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hell9 : MonoBehaviour
{
    [SerializeField] private List<string> virtueQuotes = new();
    [SerializeField] private List<string> sinQuotes = new();
    [SerializeField] private List<string> mixedQuotes = new();

    [SerializeField] private GameObject textPanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField]
    private void Start()
    {
        StartCoroutine(WaitforFade());

    }

    IEnumerator WaitforFade()
    {
        yield return new WaitForSeconds(3);

        TextRendererManager.instance.SetTextPanel(textPanel, dialogueText);

        PlayerSave.GetScorePath(this);
    }

    public void ShowVirtue()
    {
        TextRendererManager.instance.ShowNewDialogue(virtueQuotes, "John");
    }

    public void ShowSin()
    {
        TextRendererManager.instance.ShowNewDialogue(sinQuotes, "John");
    }

    public void ShowMixed()
    {
        TextRendererManager.instance.ShowNewDialogue(mixedQuotes, "John");
    }

    public void GoToMenu()
    {
        LoadingManager.instance.LoadScene("MainMenu");
    }
}
