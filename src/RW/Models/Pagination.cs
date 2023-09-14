namespace RW.Models;

/// <summary>
/// Represents pagination information.
/// </summary>
public record Pagination(int? TotalCount, int? PageCount, int? CurrentPage, int? PageSize);
