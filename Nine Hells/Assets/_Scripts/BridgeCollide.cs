using UnityEngine;
using DG.Tweening;
using _Scripts.Interactions.InteractionsSO;

public class BridgeCollide : MonoBehaviour
{
    [SerializeField] private int hp;
    public Hell8 hell8;
    public TalkInteraction npcTalkInteraction;

    public void HitBridge(int amount)
    {
        if (hp <= amount)
        {
            transform.parent.gameObject.SetActive(false);

            hell8.Sin();

            npcTalkInteraction.ClearDialogues();
            npcTalkInteraction.AddDialogue("How could you?!");
            npcTalkInteraction.AddDialogue("Aaaaaaaaaaaarggh!");
        }
        else
        {
            hp-=amount;

            transform.parent.DOShakeScale(0.4f);
        }
    }
}
