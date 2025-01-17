using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour {

	[SerializeField] private UnityEvent _onInteractionEvent;
	[SerializeField] private bool _needCharacter = true;
	[SerializeField] private GameObjectVariable _clickedGameObject;
	[SerializeField] private PlayerController _character;
	[SerializeField] private float _interactionRange = 1.0f;
	[SerializeField] private float _xOffset = 0.0f;
	[SerializeField] private bool _isException = false;
	private bool _shouldStartInteraction = false;

	private void OnMouseDown() {
		var isMouseOverUI = EventSystem.current.IsPointerOverGameObject();
		if (!isMouseOverUI && (GameController.Instance.CanInteract() || _isException)) _shouldStartInteraction = true;
		else _shouldStartInteraction = false;
	}

	private void OnMouseUp() {
		if (!_shouldStartInteraction) { return; }

		if (_needCharacter) {
			_clickedGameObject.Value = this.gameObject;
			_character.MoveCharacterToClickedItem(_interactionRange, _xOffset, OnInteractableReach, _isException);
		} else {
			OnInteractableReach();
		}
	}

	public void OnInteractableReach() {
		_onInteractionEvent.Invoke();
	}
}
