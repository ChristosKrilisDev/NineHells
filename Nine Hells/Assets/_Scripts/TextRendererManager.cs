using System.Collections;
using System.Collections.Generic;
using _Scripts.Character;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
using _Scripts.Interactions.InteractionsSO;

public class TextRendererManager : MonoBehaviour
{
    public static TextRendererManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public List<string> dialogues = new List<string>();
    private string currentDialogue = "";

    [SerializeField] private GameObject textPanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI charNameSpeaking;
    [SerializeField] private Image continueImage;
    [SerializeField] private TextMeshProUGUI continueText;
    [SerializeField] private float renderDelayTime = 50f;
    [SerializeField] private float textDurationTime = 6.0f;

    public void ShowNewDialogue(List<string> dialogues, string charNameSpeaking, TalkInteraction talkInteraction = null)
    {
        Debug.Log("Typing");
        this.charNameSpeaking.text = charNameSpeaking;
        this.dialogues = dialogues;
        textPanel.gameObject.SetActive(true);


        StartCoroutine(ForTheDialogues(talkInteraction));
        //StartCoroutine(DisplayDialogue());
        //DisplayDialogue();
    }

    //IEnumerator DelayTyping(string text, float delayTime, float duration)
    //{

    //    dialogueText.text = "";

    //    Debug.Log("Typing");
    //    foreach (char c in text)
    //    {
    //        yield return new WaitForSeconds(delayTime);
    //        dialogueText.text += c;
    //    }

    //    yield return new WaitForSeconds(duration);

    //    isTextDisplayed = true;
    //}

    //public Text dialogueText;
    public float fadeDuration = 0.5f;

    private Sequence dialogueSequence;

    private IEnumerator ForTheDialogues(TalkInteraction talkInteraction)
    {
        for (int i = 0; i < this.dialogues.Count; i++)
        {
            PlayDialogueAnimation(dialogues[i]);
            yield return dialogueSequence.WaitForCompletion();
        }
        textPanel.SetActive(false);
        PlayerController.CanMove = true;

        if (talkInteraction != null)
        {
            talkInteraction.Finish();
        }
    }

    private bool _dialogueSkipped = false;

    public void PlayDialogueAnimation(string dialogue)
    {
        // Stop the current animation if it's playing
        if (dialogueSequence != null && dialogueSequence.IsActive())
        {
            dialogueSequence.Kill();
        }

        // Clear the dialogue text
        dialogueText.text = "";

        // Create a new sequence for the dialogue animation
        dialogueSequence = DOTween.Sequence();

        // Add each letter to the dialogue text one by one
        for (int i = 0; i < dialogue.Length; i++)
        {
            char letter = dialogue[i];
            dialogueSequence.AppendCallback(() => dialogueText.text += letter);
            dialogueSequence.AppendInterval(renderDelayTime);
        }

        // Fade in the dialogue text
        dialogueSequence.Append(dialogueText.DOFade(1f, fadeDuration));

        // Callback when the animation is complete
        dialogueSequence.OnComplete(OnAnimationComplete);
    }

    private void OnAnimationComplete()
    {
        // Animation complete, do something here if needed
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _dialogueSkipped = true;
            dialogueSequence.Complete();
        }
    }



    //private void DisplayDialogue()
    //{

    //    for (int i = 0; i < dialogues.Count; i++)
    //    {
    //        Sequence sequence = DOTween.Sequence();
    //        //int currentChar = 0;
    //        dialogueText.text = "";
    //        Debug.Log("Typing");

    //        for(int j = 0; j < dialogues[i].Length; j++)
    //        {
    //            dialogueText.transform.DOMoveX(1, 1)
    //                .OnUpdate(() =>
    //            {
    //                dialogueText.text += dialogues[i][j];
    //            });
    //        }

    //        dialogueText.transform.DOMoveX(1, 10);
    //        //var tweener = DOTween.To(() => currentChar, x => currentChar = x, dialogues[i].Length, textDurationTime)
    //        //    .OnUpdate(() =>
    //        //    {
    //        //    dialogueText.text += dialogues[i][currentChar];
    //        //    });


    //        //sequence.Append(tweener);


    //        //yield return sequence.WaitForCompletion();
    //    }
    //}


    //public TextMeshProUGUI textForm;
    //public TextMeshProUGUI storyForm;
    //public TextMeshProUGUI endingForm;

    //public Image blackScreen;



    //public List<TextAsset> herculesGoodText = new List<TextAsset>();
    //public List<TextAsset> herculesBadText = new List<TextAsset>();

    //public List<TextAsset> pickupText = new List<TextAsset>();
    //public List<TextAsset> endingText = new List<TextAsset>();


    bool isTextDisplayed = false;
    bool isSkipped = false;

    
    // Start is called before the first frame update
    

    //public void InitDialogScene()
    //{
    //    //GameController.instance.playerHud.SetActive(false);
    //    textPanel.enabled = true;
    //    ShowContinue();
    //}

    public void EndDialogScene()
    {
        //textCanvas.enabled = false;
        HideContinue();
        //GameController.instance.playerHud.SetActive(true);
    }

    //public void SetPickupText(string name)
    //{

    //    foreach (TextAsset text in pickupText)
    //    {
    //        if (text.name.Equals(name))
    //        {
    //            StopAllCoroutines();
    //            RenderText(text.text, 6, 1);

    //            return;
    //        }
    //    }

    //}

    //public void ResetPickupText()
    //{
    //    StopAllCoroutines();
    //    storyForm.text = "";
    //    Canvas.ForceUpdateCanvases();
    //    storyForm.gameObject.transform.parent.gameObject.GetComponent<VerticalLayoutGroup>().enabled = false;
    //    storyForm.gameObject.transform.parent.gameObject.GetComponent<VerticalLayoutGroup>().enabled = true;

    //}

    //public void SetEndingText(string name, float duration)
    //{
    //    foreach (TextAsset text in endingText)
    //    {
    //        if (text.name.Contains(name))
    //        {
    //            StopAllCoroutines();
    //            RenderText(text.text, duration, 2);

    //            return;
    //        }
    //    }
    //}

    //public void ResetEndingText()
    //{
    //    StopAllCoroutines();
    //    endingForm.text = "";
    //    Canvas.ForceUpdateCanvases();
    //    endingForm.gameObject.transform.parent.gameObject.GetComponent<VerticalLayoutGroup>().enabled = false;
    //    endingForm.gameObject.transform.parent.gameObject.GetComponent<VerticalLayoutGroup>().enabled = true;

    //}

    public void ShowContinue()
    {
        continueImage.enabled = true;
        continueText.enabled = true;
    }

    public void HideContinue()
    {
        continueImage.enabled = false;
        continueText.enabled = false;
    }

    //public void InitHerculesStatueGoodText()
    //{
    //    //Debug.Log(hercules123.text);
    //    //BlackenScreenAndRenderTypedText(hercules123.text, 3, 1);
    //    List<string> multipleText = new List<string>();
    //    foreach (TextAsset textAsset in herculesGoodText) multipleText.Add(textAsset.text);
    //    BlackenScreenAndRenderMultipleTypedText(multipleText, 3, 1);
    //}

    //public void InitHerculesStatueBadText()
    //{
    //    //Debug.Log(hercules123.text);
    //    //BlackenScreenAndRenderTypedText(hercules123.text, 3, 1);
    //    List<string> multipleText = new List<string>();
    //    foreach (TextAsset textAsset in herculesBadText) multipleText.Add(textAsset.text);
    //    BlackenScreenAndRenderMultipleTypedText(multipleText, 3, 1);
    //}

    //void Update()
    //{
    //    if (textPanel.enabled && Input.GetKeyDown(KeyCode.F)) if (continueImage.enabled) isSkipped = true;
    //}

    //public void BlackenScreenAndRenderTypedText(string text, float textDuration, float blackScreenDuration)
    //{
    //    StartCoroutine(DelayBlackeningAndRenderTypedText(text, 0.05f, textDuration, blackScreenDuration));
    //}

    //public void BlackenScreenAndRenderMultipleTypedText(List<string> multipleText, float textDuration, float blackScreenDuration)
    //{
    //    StartCoroutine(DelayBlackeningAndRenderMultipleTypedText(multipleText, renderDelayTime, textDuration, blackScreenDuration));
    //}

    public void BlackenScreen(float duration)
    {
        StartCoroutine(DelayBlackening(duration, renderDelayTime));
    }

    IEnumerator DelayBlackening(float duration, float delayTime)
    {

        int timeSteps = (int)(duration / delayTime);
        //time goes from 0->timesteps
        //a goes from 0-1
        for (int i = 0; i < timeSteps; i++)
        {
            float aValue = ((float)i) / ((float)timeSteps);
            //blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, aValue);
            yield return new WaitForSeconds(delayTime);
        }


        //blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1);

    }

    //IEnumerator DelayBlackeningAndRenderTypedText(string text, float delayTime, float textDuration, float blackScreenDuration)
    //{

    //    int timeSteps = (int)(blackScreenDuration / delayTime);
    //    //time goes from 0->timesteps
    //    //a goes from 0-1
    //    for (int i = 0; i < timeSteps; i++)
    //    {
    //        float aValue = ((float)i) / ((float)timeSteps);
    //        //blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, aValue);
    //        yield return new WaitForSeconds(delayTime);
    //    }

    //    //blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1);

    //    RenderTypedText(text, textDuration);

    //}

    //IEnumerator DelayBlackeningAndRenderMultipleTypedText(List<string> multipleText, float delayTime, float textDuration, float blackScreenDuration)
    //{
    //    //GameController.instance.player.GetComponent<PlayerMovement>().enabled = false;
    //    //AudioManager.instance.AbruptStop("LeftFoot");
    //    int timeSteps = (int)(blackScreenDuration / delayTime);
    //    //time goes from 0->timesteps
    //    //a goes from 0-1
    //    for (int i = 0; i < timeSteps; i++)
    //    {
    //        float aValue = ((float)i) / ((float)timeSteps);
    //        //blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, aValue);
    //        yield return new WaitForSeconds(delayTime);
    //    }

    //    //blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1);



    //    RenderMultipleTypedText(multipleText, textDuration);


    //}

    //public void RenderText(string text, float duration, int type = 0)
    //{
    //    StartCoroutine(DelayText(text, duration, type));
    //}

    //IEnumerator DelayText(string text, float duration, int type = 0)
    //{

    //    TextMeshProUGUI dynamicTextForm = null;

    //    if (type == 0) dynamicTextForm = textForm;
    //    else if (type == 1) dynamicTextForm = storyForm;
    //    else dynamicTextForm = endingForm;

    //    dynamicTextForm.horizontalAlignment = HorizontalAlignmentOptions.Center;
    //    dynamicTextForm.text = text;

    //    Canvas.ForceUpdateCanvases();
    //    dynamicTextForm.gameObject.transform.parent.gameObject.GetComponent<VerticalLayoutGroup>().enabled = false;
    //    dynamicTextForm.gameObject.transform.parent.gameObject.GetComponent<VerticalLayoutGroup>().enabled = true;


    //    yield return new WaitForSeconds(duration);
    //    dynamicTextForm.text = "";
    //    dynamicTextForm.horizontalAlignment = HorizontalAlignmentOptions.Left;

    //    Canvas.ForceUpdateCanvases();
    //    dynamicTextForm.gameObject.transform.parent.gameObject.GetComponent<VerticalLayoutGroup>().enabled = false;
    //    dynamicTextForm.gameObject.transform.parent.gameObject.GetComponent<VerticalLayoutGroup>().enabled = true;


    //    if (type == 2)
    //    {
    //        SceneManager.LoadScene("CreditsScene");
    //    }

    //}


    //public void RenderTypedText(string text, float duration, int type = 0)
    //{

    //    StartCoroutine(DelayTyping(text, renderDelayTime, duration, type));

    //}

    

    //IEnumerator DelayMultipleTyping(List<string> multipleText, float delayTime, float duration, int type)
    //{
    //    InitDialogScene();
    //    TextMeshProUGUI dynamicTextForm = null; ;
    //    if (type == 0) dynamicTextForm = textForm;
    //    else if (type == 1) dynamicTextForm = storyForm;
    //    else dynamicTextForm = endingForm;

    //    for (int i = 0; i < multipleText.Count; i++)
    //    {
    //        string s = multipleText[i];

    //        dynamicTextForm.text = "";
    //        foreach (char c in s)
    //        {
    //            yield return new WaitForSeconds(delayTime);
    //            dynamicTextForm.text += c;
    //            if (isSkipped) break;
    //        }

    //        isTextDisplayed = true;

    //        if (isSkipped == false)
    //        {
    //            HideContinue();
    //            yield return new WaitForSeconds(duration);
    //            ShowContinue();
    //        }
    //        else
    //        {
    //            isSkipped = false;

    //            if (i == multipleText.Count - 1) EndDialogScene();
    //        }

    //    }

    //    //blackScreen.color = new Color(0, 0, 0, 0);
    //    dynamicTextForm.text = "";
    //    //GameController.instance.player.GetComponent<PlayerMovement>().enabled = true;
    //    //AudioManager.instance.StopCurrent();
    //    //AudioManager.instance.PlayFadeIn("MainTheme");

    //    EndDialogScene();
    //}

    //public void RenderMultipleTypedText(List<string> multipleText, float duration, int type = 0)
    //{
    //    StartCoroutine(DelayMultipleTyping(multipleText, 0.08f, duration, type));
    //}
}
