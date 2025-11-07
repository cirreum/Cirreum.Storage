namespace Cirreum.Storage;

public class TransferValidationOptions {

	/// <summary>
	/// Checksum algorithm to use. Default: StorageChecksumAlgorithm.Auto
	/// </summary>
	/// <remarks>
	/// For Azure: https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blob-upload#specify-transfer-validation-options-on-upload
	/// </remarks>
	public StorageChecksumAlgorithm ChecksumAlgorithm { get; set; } = StorageChecksumAlgorithm.Auto;

	/// <summary>
	/// Defaults to true. False can only be specified on specific operations and not at the client level.
	/// Indicates whether the SDK should validate the content
	/// body against the content hash before returning contents to the caller.
	/// If set to false, caller is responsible for extracting the hash out
	/// of the <c>Response&lt;T&gt;</c> and validating the hash themselves.
	/// </summary>
	public bool AutoValidateChecksum { get; set; } = true;

}