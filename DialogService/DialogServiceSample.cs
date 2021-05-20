using System;
using System.Threading.Tasks;

namespace DialogService
{
    public class DialogServiceSample : IDialogService
    {
        public event Func<string, string, Task<DialogResult>> OnShow;

        public async Task<DialogResult> ShowDialogAsync(string title, string description)
        {
            return await OnShow?.Invoke(title, description); 
        }
    }
}
