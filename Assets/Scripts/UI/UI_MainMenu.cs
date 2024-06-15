using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    [Header("Warning Info")]
    [SerializeField] private TextMeshProUGUI warningText;
    [SerializeField] private float disaperaingSpeed = .25f;
    private float currentWarningAlpha;
    private float targetWarningAlpha;

    private void Update()
    {
        if (currentWarningAlpha > targetWarningAlpha)
        {
            currentWarningAlpha -= Time.deltaTime * disaperaingSpeed;
            warningText.color = new Color(1, 1, 1, currentWarningAlpha);
        }
    }

    public void ShowWarningMessage(string message)
    {
        warningText.color = Color.white;
        warningText.text = message;

        currentWarningAlpha = warningText.color.a;
        targetWarningAlpha = 0;
    }
}
