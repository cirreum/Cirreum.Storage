namespace Cirreum.Storage;

public sealed class RequestBlobConditions : BlobConditions {

	/// <summary>
	/// Optionally limit requests to resources with an active lease
	/// matching this Id.
	/// </summary>
	public string? LeaseId { get; set; }

	/// <summary>
	/// Optional SQL statement to apply to the Tags of the Blob.
	/// </summary>
	public string? TagConditions { get; set; }

}