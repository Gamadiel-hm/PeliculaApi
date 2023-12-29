using PeliculaModel.Dtos;

namespace PeliculaApi.Utilities
{
    public class ResponseHttp
    {
        public Object Data { get; set; }
        public InfoHttp InfoHttp { get; set; }

        public void ResposeAll<T>(List<T> data, int status, string message) where T : class 
        {
            this.Data = data;
            this.InfoHttp = new()
            {
                Status = status,
                Message = message,
                Page = 1,
                Results = data.Count,
            };
        }

        public void ResponseById<T>(T data, int status, string message) where T : class
        {
            this.Data = data;
            this.InfoHttp = new()
            {
                Status = status,
                Message = message,
                Page = 0,
                Results = 1,
            };
        }

        public void Response(int status, string message)
        {
            this.InfoHttp = new()
            {
                Message = message,
                Page=0,
                Results = 0,
                Status = status,
            };
        }
    }
}
