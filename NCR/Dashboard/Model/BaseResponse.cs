namespace NCR.Dashboard.Model
{
    public class BaseResponse
    {
        public string RequestId { get; set; }
        public ErrorCode ErrorCode { get; set; }
        public string ReturnMessage { get; set; }
        public object ReturnData { get; set; }
        public bool Success { get; set; }
    }

    public enum ErrorCode
    {
        内部服务异常 = 500
    }
}