public class PaginatedResponse<T>
{
    public List<T> Items { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
    public int Total { get; set; }
    public int TotalPages { get; set; }
    public int FirstEntry { get; set; }
    public int LastEntry { get; set; }
}