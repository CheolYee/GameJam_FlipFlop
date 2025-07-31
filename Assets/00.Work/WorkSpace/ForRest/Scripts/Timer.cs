using _00.Work.Scripts.Managers;
using TMPro;
using UnityEngine;

public class Timer : MonoSingleton<Timer>
{
    private TMP_Text timeText;

    private float stime = 120f;
    private float mtime = 0f;

    protected override void Awake()
    {
        base.Awake();
        if (Instance == this)
            DontDestroyOnLoad(this);
        timeText = GetComponentInChildren<TMP_Text>();
        SetTimerText();
    }

    private void Start()
    {
        while (stime >= 60f)
        {
            mtime += 1;
            stime -= 60;
        }
        SetTimerText();
    }

    void Update()
    {
        if (stime > 0f || mtime > 0f)
        {
            stime -= Time.deltaTime;

            if (stime < 0f)
            {
                if (mtime > 0f)
                {
                    mtime -= 1;
                    stime += 60f;
                }
                else
                {
                    stime = 0f;
                }
            }
        }
        SetTimerText();
    }

    private void SetTimerText()
    {
        timeText.text = $"{(int)mtime} : {(int)stime:D2}";
    }
}
