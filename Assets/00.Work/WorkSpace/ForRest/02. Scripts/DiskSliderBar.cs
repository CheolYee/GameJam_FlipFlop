using _00.Work.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

public class DiskSliderBar : MonoSingleton<DiskSliderBar>
{
    [SerializeField] private Image redBar;
    [SerializeField] private Image blueBar;
    [SerializeField] private RectTransform safeLine;

    [SerializeField] private float maxDisk;
    [SerializeField] private float diskSafe = 80f;
    private float _disk;

    private void Start()
    {
        _disk = maxDisk;
        SetDiskSlider(_disk);
        SafeBarPosition();
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
        blueBar.fillAmount = greenFill;
    }

    private void SafeBarPosition()
    {
        RectTransform redRect = redBar.rectTransform;
        float safeRatio = diskSafe / maxDisk;
        float localSafeX = (safeRatio - 0.5f) * redRect.rect.width;

        // 레드바 로컬 기준 위치를 월드좌표로 변환
        Vector3 worldSafePos = redRect.TransformPoint(new Vector3(localSafeX, 0f, 0f));
        safeLine.localPosition = safeLine.parent.InverseTransformPoint(worldSafePos);
    }
}
