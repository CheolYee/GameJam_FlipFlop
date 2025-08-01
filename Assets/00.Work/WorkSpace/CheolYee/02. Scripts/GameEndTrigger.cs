using System;
using UnityEngine;

namespace _00.Work.WorkSpace.CheolYee._02._Scripts
{
    public class GameEndTrigger : MonoBehaviour
    {
        public event Action OnAnyKeyPressed;
        public event Action OnRKeyPressed;
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                if (!Input.GetKeyDown(KeyCode.R))
                {
                    OnAnyKeyPressed?.Invoke();
                }
                else
                {
                    OnRKeyPressed?.Invoke();
                }
            }
        }
    }
}