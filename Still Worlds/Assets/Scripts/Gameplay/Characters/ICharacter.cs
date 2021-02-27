namespace Gameplay.Characters
{
    public interface ICharacter
    {
        float GetMovementSpeed();
        float GetRotationSpeed();
        bool IsInteractable();
        void Interact();
        void ShowInteraction();
        void HideInteraction();
        ICharacter GetInteractor();
        void SetInteractor(ICharacter character);
    }
}