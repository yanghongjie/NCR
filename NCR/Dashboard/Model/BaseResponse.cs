namespace NCR.Dashboard.Model
{
    public class BaseResponse
    {
        public string RequestId { get; set; }
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }
    }

    public enum ErrorCode
    {
        内部服务异常 = 500
    }
}