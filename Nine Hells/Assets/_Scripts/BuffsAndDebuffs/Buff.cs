using _Scripts.Interactions.InteractionsSO;
using UnityEngine;

public class Buff
{
    public BuffType buffType = BuffType.Buff;
    public Sprite buffSprite;
    public int buffNo = 1;
    public BuffData buffSprites;

    public Buff(BuffType buffType, int buffNo)
    {
        buffSprites = Resources.Load("BuffSprites") as BuffData;
        this.buffType = buffType;
        this.buffNo = buffNo;

        if(buffType == BuffType.Buff)
        {
            switch (this.buffNo)
            {
                case 1:
                    buffSprite = buffSprites.Buff01;
                    Debug.Log(buffSprites.Buff01);
                    break;
                case 2:
                    buffSprite = buffSprites.Buff02;
                    break;
                case 3:
                    buffSprite = buffSprites.Buff03;
                    break;
            }
        }
        else
        {
            switch (this.buffNo)
            {
                case 1:
                    buffSprite = buffSprites.Debuff01;
                    break;
                case 2:
                    buffSprite = buffSprites.Debuff02;
                    break;
                case 3:
                    buffSprite = buffSprites.Debuff03;
                    break;
            }
        }
    }
}

public enum BuffType
{
    Buff,
    Debuff
}