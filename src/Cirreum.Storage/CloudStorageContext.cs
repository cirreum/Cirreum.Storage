namespace Cirreum.Storage;

/// <summary>
/// Represents a context for cloud storage operations, encapsulating storage, container, and blob information.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CloudStorageContext"/> class.
/// </remarks>
/// <param name="storage">The cloud storage implementation to use.</param>
/// <param name="containerId">The ID of the container to operate on.</param>
/// <param name="blobId">Optional. The ID of a specific blob within the container.</param>
public class CloudStorageContext(ICloudStorageClient storage, string containerId, string? blobId = null) {

	/// <summary>
	/// Has the container been deleted.
	/// </summary>
	internal bool ContainerDeleted { get; private set; }
	/// <summary>
	/// Called when the container was deleted.
	/// </summary>
	internal void OnContainerDeleted() {
		this.ContainerDeleted = true;
		this.ContainerId = string.Empty;
	}
	/// <summary>
	/// Throws <see cref="InvalidOperationException"/> if container id is missing or if <see cref="ContainerDeleted"/> is <see langword="true"/>
	/// </summary>
	/// <exception cref="InvalidOperationException"></exception>
	internal void EnsureContainerId() {
		if (this.ContainerDeleted || string.IsNullOrWhiteSpace(this.ContainerId)) {
			throw new InvalidOperationException("Unknown or missing container id, or container was deleted and no longer available.");
		}
	}

	/// <summary>
	/// Has the blob been deleted.
	/// </summary>
	internal bool BlobDeleted { get; private set; }
	/// <summary>
	/// Called when the blob was deleted.
	/// </summary>
	internal void OnBlobDeleted() {
		this.BlobDeleted = true;
		this.BlobId = string.Empty;
	}
	/// <summary>
	/// Throws <see cref="InvalidOperationException"/> if blob id is missing or if <see cref="BlobDeleted"/> is <see langword="true"/>.
	/// </summary>
	/// <exception cref="InvalidOperationException"></exception>
	internal void EnsureBlobId() {
		if (this.BlobDeleted || string.IsNullOrWhiteSpace(this.BlobId)) {
			throw new InvalidOperationException("Unknown or missing blob id, or blob was deleted and no longer available.");
		}
	}

	/// <summary>
	/// Gets the cloud storage interface implementation.
	/// </summary>
	internal ICloudStorageClient Storage { get; } = storage;

	/// <summary>
	/// Gets the identifier of the cloud storage container.
	/// </summary>
	public string ContainerId { get; private set; } = containerId;

	/// <summary>
	/// Gets the optional identifier of a specific blob within the container.
	/// </summary>
	public string? BlobId { get; private set; } = blobId;

	/// <summary>
	/// Work with a specific blob.
	/// </summary>
	/// <param name="blobId">The id of the blob to work with.</param>
	/// <returns>The source <see cref="CloudStorageContext"/> instance.</returns>
	public CloudStorageContext WithBlob(string blobId) {
		this.EnsureContainerId();
		if (!string.IsNullOrWhiteSpace(this.BlobId)) {
			throw new InvalidOperationException($"Blob Id {this.BlobId} already in use.");
		}
		this.BlobId = blobId;
		return this;
	}

}