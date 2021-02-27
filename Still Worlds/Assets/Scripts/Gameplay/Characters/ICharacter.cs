using Gameplay.Interactors;

namespace Gameplay.Characters
{
    public interface ICharacter
    {
        float GetMovementSpeed();
        float GetRotationSpeed();
        Interactor GetInteractor();
        Portal GetPortal();
        int GetLife();
        void SetLife(int life);
        void Attack();
        void TakeHit();
        int GetKill();
        void SetKill(int kill);
    }
}