namespace EcomApi2.Models.Dto
{
    public class ResponceDto
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Massage {  get; set; }=string.Empty;
    }
}
