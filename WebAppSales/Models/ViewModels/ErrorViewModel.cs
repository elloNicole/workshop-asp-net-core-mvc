namespace WebAppSales.Models.ViewModels //nome projeto paste principal e subparta, esse é o endereço de arquivo errorview models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
