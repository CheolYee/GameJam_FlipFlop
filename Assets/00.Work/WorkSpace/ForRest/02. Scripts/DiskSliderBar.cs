using _00.Work.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

public class DiskSliderBar : MonoSingleton<DiskSliderBar>
{
    [SerializeField] private Image redBar;
    [SerializeField] private Image greenBar;
    [SerializeField] private RectTransform ComBar;

    [SerializeField] private float maxDisk;
    [SerializeField] private float diskSafe = 80f;
    private float _disk;

    private void Start()
    {
        _disk = maxDisk;
        SetDiskSlider(_disk);
    }

    public void PlusDisk(float value)
    {
        SetDiskSlider(value);
    }
    public void MinusDisk(float value)
    {
        SetDiskSlider(-value);
    }

    private void SetDiskSlider(float value)
    {
        _disk += value;

        if (_disk > maxDisk)
        {
            _disk = maxDisk;
        }
        else if (_disk < 0f)
        {
            _disk = 0f;
        }

        if (_disk < diskSafe)
        {
            Debug.Log("safe!");
        }

        redBar.fillAmount = _disk / maxDisk;
        float greenFill = Mathf.Min(_disk, diskSafe) / maxDisk;
        greenBar.fillAmount = greenFill;
    }
}
