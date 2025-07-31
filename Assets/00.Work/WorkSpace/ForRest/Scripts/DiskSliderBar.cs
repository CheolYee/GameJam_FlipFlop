using UnityEngine;
using UnityEngine.UI;

public class DiskSliderBar : MonoBehaviour
{
    private Image img;

    private float disk;
    private float maxDisk = 100;
    private float diskAmount = 20;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    public void PlusDisk()
    {
        SetDisk(diskAmount);
    }
    public void MinusDisk()
    {
        SetDisk(-diskAmount);
    }

    private void SetDisk(float value)
    {
        disk += value;
        Set_HP(disk);
    }

    private void Set_HP(float value)
    {
        disk = value;

        if (disk > maxDisk)
        {
            disk = maxDisk;
        }
        else if (disk < 0)
        {
            disk = 0;
        }
        img.fillAmount = disk / maxDisk;
    }
}
