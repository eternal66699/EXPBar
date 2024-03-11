using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXPManager : MonoBehaviour
{
    [Header("Experience")]
    [SerializeField] AnimationCurve EXPCurve;
    int currentLevel;
    int totalEXP;
    int previousLevelEXP;
    int nextLevelEXP;

    [Header("Interface")]
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI EXPText;
    [SerializeField] Image EXPFill;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLevel();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddExperience(5);
        }
    }

    public void AddExperience(int amount)
    {
        totalEXP += amount;
        CheckForLevelUp();
        UpdateInterface();
    }

    void CheckForLevelUp()
    {
        if (totalEXP >= nextLevelEXP)
        {
            currentLevel++;
            UpdateLevel();

            // Start level up sequence... Possibly vfx?
        }
    }

    void UpdateLevel()
    {
        previousLevelEXP = (int)EXPCurve.Evaluate(currentLevel);
        nextLevelEXP = (int)EXPCurve.Evaluate(currentLevel + 1);
        UpdateInterface();
    }

    void UpdateInterface()
    {
        int start = totalEXP - previousLevelEXP;
        int end = nextLevelEXP - previousLevelEXP;

        levelText.text = currentLevel.ToString();
        EXPText.text = "EXP: " + start + "/" + end;
        EXPFill.fillAmount = (float)start / (float)end;
    }
}
