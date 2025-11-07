namespace Cirreum.Storage;

public sealed class DownloadBlobOptions {

	/// <summary>
	/// Optional <see cref="RequestConditions"/> to add
	/// conditions on the download of this Block Blob.
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