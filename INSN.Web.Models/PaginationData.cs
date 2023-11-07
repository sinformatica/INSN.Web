namespace INSN.Web.Models;

public class PaginationData
{
    public int CurrentPage { get; set; }
    public int RowsPerPage { get; set; }
    public int TotalPages { get; set; }
    public int RowCount { get; set; }
}