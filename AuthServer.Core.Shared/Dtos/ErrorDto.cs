namespace AuthServer.Core.Shared.Dtos
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public ErrorDto(string error, bool isShow)
        {
            Errors.Add(error);
            isShow = true;
        }
        public ErrorDto(List<string> errors, bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }
        public List<string> Errors { get; private set; }
        public bool IsShow { get; private set; }
    }
}