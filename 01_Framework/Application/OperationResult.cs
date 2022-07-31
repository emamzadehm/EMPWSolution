namespace _01_Framework.Application
{
    public class OperationResult
    {
        public bool isSuccessful { get; set; }
        public string message { get; set; }
        public OperationResult()
        {
            isSuccessful = false;
        }

        public OperationResult Successful(string _message="عملیات با موفقیت انجام گردید" )
        {
            isSuccessful = true;
            message = _message;
            return this;
        }
        public OperationResult Failed(string _message)
        {
            isSuccessful = false;
            message = _message;
            return this;
        }
    }
}
