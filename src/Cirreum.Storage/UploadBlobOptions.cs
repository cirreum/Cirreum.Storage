namespace Cirreum.Storage;
using Metadata = IDictionary<string, string>;
using Tags = IDictionary<string, string>;

public sealed class UploadBlobOptions {

	/// <summary>
	/// Optional custom metadata to set for this append blob.
	/// </summary>
	public Metadata? Metadata { get; set; }

	/// <summary>
	/// Options tags to set for this block blob.
	/// </summary>
	/// <remarks>
	/// For Azure: https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blob-upload#upload-with-index-tags
	/// </remarks>
	public Tags? Tags { get; set; }

	/// <summary>
	/// Optional <see cref="RequestBlobConditions"/> to add
	/// conditions on the upload of this Block Blob.
	/// </summary>
	public RequestBlobConditions? RequestConditions { get; set; }

	/// <summary>
	/// Progress handler for tracking download progress.
	/// </summary>
	public IProgress<long>? ProgressHandler { get; set; }

	/// <summary>
	/// Transfer options for managing individual read requests.
	/// </summary>
	public TransferOptions TransferOptions { get; set; }

	/// <summary>
	/// Optional override settings for this client's <c>TransferValidation</c> settings.
	/// This operation does not allow <c>TransferValidationOptions.AutoValidateChecksum</c>
	/// to be set false.
	/// </summary>
	public TransferValidationOptions? TransferValidation { get; set; }

}