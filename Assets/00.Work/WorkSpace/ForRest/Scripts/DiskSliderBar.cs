using UnityEngine;
using UnityEngine.UI;

public class DiskSliderBar : MonoBehaviour
{
    [SerializeField] private Image redBar;
    [SerializeField] private Image greenBar;

    private float maxDisk = 100f;
    private float disk;
    private float diskAmount = 20f;
    private float diskSafe = 50f;

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

        redBar.fillAmount = disk / maxDisk;
        float greenFill = Mathf.Min(disk, diskSafe) / maxDisk;
        greenBar.fillAmount = greenFill;
    }
}
