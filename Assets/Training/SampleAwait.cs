using System.Threading.Tasks;

namespace Training
{
    public class SampleAwait
    {
        private async void DoSomethingAsync()
        {
            bool result = await DoAnythingAsync();
        }

        private async Task<bool> DoAnythingAsync()
        {
            await Task.Delay(500);
            return true;
        }
    }
}