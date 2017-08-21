namespace NarwhalEngine.Managers.Complements
{
    interface IScreen
    {
        void Open();
        void Update(float deltaTime);
        void Exit();
    }
}
