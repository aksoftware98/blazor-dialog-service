using System;
using System.Threading.Tasks;

namespace DialogService
{
    public interface IDialogService
    {
        event Func<string, string, Task<DialogResult>> OnShow;
        Task<DialogResult> ShowDialogAsync(string title, string description); 
    }
}
