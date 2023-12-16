using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerColorGradiant : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image image;
    [SerializeField] private Color maxColor;
    [SerializeField] private Color minColor;

    private Gradient gradient;

    private void Start()
    {
        gradient = new Gradient();
        
        GradientColorKey[] gradientColorKeys = new GradientColorKey[2];
        gradientColorKeys[0] = new GradientColorKey(minColor, 0.0f);
        gradientColorKeys[1] = new GradientColorKey(maxColor, 1.0f);

        GradientAlphaKey[] gradientAlphaKey = new GradientAlphaKey[2];
        gradientAlphaKey[0] = new GradientAlphaKey(1.0f, 0.0f);
        gradientAlphaKey[1] = new GradientAlphaKey(1.0f, 1.0f);

        gradient.SetKeys(gradientColorKeys, gradientAlphaKey);
    }

    public void OnSliderValueChanged()
    {
        if (gradient != null)
        {
            float percent = slider.value / slider.maxValue;
            image.color = gradient.Evaluate(percent);
        }
    }
}
