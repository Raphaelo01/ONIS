namespace ONIS.Shared.Base.Helpers
{
    public class ResultObject<T>
    {

        public IEnumerable<T>? Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsError { get; set; } = false;
    }
}
