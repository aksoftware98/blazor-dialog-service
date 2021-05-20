using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialogService.Pages
{
    public partial class AKDialog : ComponentBase
    {

        [Inject]
        public IDialogService DialogService { get; set; }

        TaskCompletionSource<DialogResult> tcs = null;

        private string _title;
        private string _description;
        private bool _isOpen; 

        private void OnButtonClicked(DialogResult result)
        {
            tcs.SetResult(result);
        }

        protected override void OnInitialized()
        {
            DialogService.OnShow += DialogService_OnShow;
            base.OnInitialized();
        }

        private async Task<DialogResult> DialogService_OnShow(string arg1, string arg2)
        {
            tcs = new TaskCompletionSource<DialogResult>();
            _title = arg1;
            _description = arg2;
            _isOpen = true;
            StateHasChanged();
            var result = await tcs.Task;
            _isOpen = false;
            return result;
        }
    }
}
