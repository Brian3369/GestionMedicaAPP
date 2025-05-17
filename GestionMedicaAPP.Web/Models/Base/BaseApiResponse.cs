namespace GestionMedicaAPP.Web.Models.Base
{
    public class BaseApiResponse
    {
        public BaseApiResponse()
        {
            isSuccess = true;
        }
        public bool isSuccess { get; set; }
        public string message { get; set; }
    }
}
