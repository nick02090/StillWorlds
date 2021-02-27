using Gameplay.Interactors;

namespace Gameplay.Characters
{
    public interface ICharacter
    {
        float GetMovementSpeed();
        float GetRotationSpeed();
        Interactor GetInteractor();
    }
}