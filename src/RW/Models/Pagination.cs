namespace RW.Models;

/// <summary>
/// Represents pagination information.
/// </summary>
public record Pagination(int? TotalRecords, int? TotalPages, int? CurrentPage, int? CurrentPageSize);
