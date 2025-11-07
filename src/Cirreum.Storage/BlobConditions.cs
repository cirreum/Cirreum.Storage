namespace Cirreum.Storage;

public class BlobConditions {

	/// <summary>
	/// Optionally limit requests to resources that have only been modified since this point in time.
	/// </summary>
	public DateTimeOffset? IfModifiedSince { get; set; }

	/// <summary>
	/// Optionally limit requests to resources that have remained unmodified.
	/// </summary>
	public DateTimeOffset? IfUnmodifiedSince { get; set; }

	/// <summary>
	/// Optionally limit requests to resources that have a matching ETag.
	/// </summary>
	public string? IfMatch { get; set; }

	/// <summary>
	/// Optionally limit requests to resources that do not match the ETag.
	/// </summary>
	public string? IfNoneMatch { get; set; }

}