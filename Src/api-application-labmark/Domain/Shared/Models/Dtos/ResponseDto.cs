namespace Labmark.Domain.Shared.Models.Dtos
{
    public class ResponseDto
    {
        public string status { get; set; }
        public dynamic detail { get; set; }
        public ResponseDto(string _status, dynamic _detail)
        {
            status = _status;
            detail = _detail;
        }
    }
}
