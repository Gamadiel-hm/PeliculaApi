namespace PeliculaServices.Utilities
{
    public class ResponseService
    {
        public bool Completed { get; set; }
        public string Message { get; set; }

        public ResponseService()
        {
            Completed = false;
        }

        public void Response(bool completed, string Message)
        {
            this.Message = Message;
            this.Completed = completed;
        }
    }
}
