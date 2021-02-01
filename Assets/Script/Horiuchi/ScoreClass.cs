using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreClass
{
    private static ScoreClass scoreClass;
    public static ScoreClass GetInstance()
    {
        //singleton
        if (scoreClass == null)
        {
            scoreClass = new ScoreClass();
        }
        return scoreClass;
    }

    private float
        totalScore,
        bonusScore;

    private int
        hitCount;

    private const float
        baseScore = 1000,
        deduction = 50,
        timeDeduction = 10;

    public enum Bonus
    {
        RUN,
        JUMP,
        SLIDING,
        WALLRUN,
        DASH,
        MAXVAL
    }
    private Dictionary<Bonus, float>
        bonusDic = new Dictionary<Bonus, float>()
        {
            {Bonus.RUN, 10},
            {Bonus.JUMP, 20},
            {Bonus.SLIDING, 20},
            {Bonus.WALLRUN, 30},
            {Bonus.DASH, 30}
        };

    public ScoreClass()
    {
        InitParam();
    }
    public void InitParam()
    {
        totalScore = 0;
        bonusScore = 0;
        hitCount = 0;
    }

    public void SetScore(float Time)
    {
        totalScore = baseScore - (Time * timeDeduction + deduction * hitCount) + bonusScore;

        PlayerPrefs.SetFloat("NewScore", totalScore);
        PlayerPrefs.Save();
    }
    public void HitCount()
    {
        hitCount++;
    }
    public void addBounus(Bonus val)
    {
        bonusScore += bonusDic[val];
    }
}
