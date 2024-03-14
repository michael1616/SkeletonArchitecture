using System.Net;

namespace XYZPlatform.Models.DTO
{
    public class APIResponseDTO
    {
        public APIResponseDTO()
        {
            ErrorMessages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }

        public bool IsExitoso { get; set; } = true;

        public List<string> ErrorMessages { get; set; }

        public object Resultado { get; set; }
    }
}
