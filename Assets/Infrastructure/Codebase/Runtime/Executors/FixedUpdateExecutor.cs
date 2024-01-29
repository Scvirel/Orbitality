namespace Orbitality.Client.Runtime
{
    public sealed class FixedUpdateExecutor : BaseExecutor 
    {
        private void FixedUpdate()
        {
            base.Execute();
        }
    }
}