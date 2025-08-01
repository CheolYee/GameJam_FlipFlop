using System;
using _00.Work.Scripts.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _00.Work.Scripts.SO
{
    [CreateAssetMenu(fileName = "InputSO", menuName = "SO/InputSO")]
    public class PlayerInputSo : ScriptableObject, Controls.IPlayerActions
    {
        private Controls _controls;

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls();
                _controls.Player.SetCallbacks(this);
            }
            
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                SoundManager.Instance.PlaySfx("Click");
            }
        }
    }
}
