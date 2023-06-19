using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public GameControls.PlayerActions PlayerControls { get => _gameControls.Player;}
        private GameControls _gameControls;

        private void Awake()
        {
            _gameControls = new GameControls();
            _gameControls.Enable();
        }

        private void OnDisable()
        {
            _gameControls.Disable();
        }
    }
}