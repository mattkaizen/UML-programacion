using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReaderData")]
public class InputReaderData : ScriptableObject, GameControls.IPlayerActions
{
    private GameControls _gameControls;
    private InputAction _interact;
    
    public event UnityAction Interacted = delegate {};

    private void OnEnable()
    {
        _gameControls = new GameControls();
        _gameControls.Player.Enable();

        _interact = _gameControls.Player.Interact;

        _interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        _interact.performed -= OnInteract;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (_interact.WasPerformedThisFrame())
        {
            Interacted?.Invoke();
        }
    }
}