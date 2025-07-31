using UnityEngine;
using UnityEngine.UI;

public class DiskSliderBar : MonoBehaviour
{
    private Image img;

    private float maxDisk = 100f;
    private float disk;
    private float diskAmount = 20f;
    private float diskSafe = 50f;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    private void Start()
    {
        disk = maxDisk;
        SetDiskSlider(disk);
    }

    public void PlusDisk()
    {
        SetDiskSlider(diskAmount);
    }
    public void MinusDisk()
    {
        SetDiskSlider(-diskAmount);
    }

    private void SetDiskSlider(float value)
    {
        disk += value;

        if (disk > maxDisk)
        {
            disk = maxDisk;
        }
        else if (disk < 0f)
        {
            disk = 0f;
        }

        if (disk < diskSafe)
        {
            Debug.Log("safe!");
        }

        img.fillAmount = disk / maxDisk;
    }
}
