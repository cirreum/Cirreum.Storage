namespace Cirreum.Storage;

using System.IO;

/// <summary>
/// Defines the methods for interacting with a cloud Blob storage service.
/// </summary>
/// <remarks>
/// Such as for Azure Storage or AWS S3
/// </remarks>
public static class StorageBlobExtensions {

	/// <summary>
	/// Creates a new block blob or throws if the blob already exists.
	/// Setting <paramref name="overwrite"/> to true allows updating the
	/// content of an existing block blob. Updating an existing block blob
	/// overwrites any existing metadata on the blob.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="sourceFilePath">The full path of the source file to be uploaded.</param>
	/// <param name="overwrite">Whether the upload should overwrite any existing blobs. The default value is false.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional blob 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	public static async Task<string?> UploadFileAsync(this CloudStorageContext context,
		string sourceFilePath,
		bool overwrite,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.UploadFileAsync(context.ContainerId, context.BlobId!, sourceFilePath, overwrite, token);
	}

	/// <summary>
	/// Creates a new block blob or throws if the blob already exists.
	/// Setting <paramref name="overwrite"/> to true allows updating the
	/// content of an existing block blob. Updating an existing block blob
	/// overwrites any existing metadata on the blob.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="sourceFilePath">The full path of the source file to be uploaded.</param>
	/// <param name="overwrite">Whether the upload should overwrite any existing blobs. The default value is false.</param>
	/// <param name="metaData">The metadata to associate with the blob.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional blob 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	public static async Task<string?> UploadFileAsync(this CloudStorageContext context,
		string sourceFilePath,
		bool overwrite,
		IDictionary<string, string> metaData,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.UploadFileAsync(context.ContainerId, context.BlobId!, sourceFilePath, overwrite, metaData, token);
	}

	/// <summary>
	/// Uploads the file to cloud storage overwriting the existing content.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="sourceFilePath">The full path of the source file to be uploaded.</param>
	/// <param name="options">The desired <see cref="UploadBlobOptions"/> to effect the upload process.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional blob 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	public static async Task<string?> UploadFileAsync(this CloudStorageContext context,
		string sourceFilePath,
		UploadBlobOptions options,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.UploadFileAsync(context.ContainerId, context.BlobId!, sourceFilePath, options, token);
	}

	/// <summary>
	/// Creates a new block blob or throws if the blob already exists.
	/// Setting <paramref name="overwrite"/> to true allows updating the
	/// content of an existing block blob. Updating an existing block blob
	/// overwrites any existing metadata on the blob.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="content">The string contents to upload.</param>
	/// <param name="overwrite">Whether the upload should overwrite any existing blobs. The default value is false.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional blob 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	public static async Task<string?> UploadContentAsync(this CloudStorageContext context,
		string content,
		bool overwrite,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.UploadContentAsync(context.ContainerId, context.BlobId!, content, overwrite, token);
	}

	/// <summary>
	/// Uploads the content to cloud storage overwriting the existing content.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="content">The string contents to upload.</param>
	/// <param name="options">The desired <see cref="UploadBlobOptions"/> to effect the upload process.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional blob 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	public static async Task<string?> UploadContentAsync(this CloudStorageContext context,
		string content,
		UploadBlobOptions options,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.UploadContentAsync(context.ContainerId, context.BlobId!, content, options, token);
	}


	/// <summary>
	/// Creates a new block blob or throws if the blob already exists.
	/// Setting <paramref name="overwrite"/> to true allows updating the
	/// content of an existing block blob. Updating an existing block blob
	/// overwrites any existing metadata on the blob.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="stream">The <see cref="Stream"/> contents to upload.</param>
	/// <param name="overwrite">Whether the upload should overwrite any existing blobs. The default value is false.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional blob 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	public static async Task<string?> UploadStreamAsync(this CloudStorageContext context,
		Stream stream,
		bool overwrite,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.UploadStreamAsync(context.ContainerId, context.BlobId!, stream, overwrite, token);
	}

	/// <summary>
	/// Uploads the stream to cloud storage overwriting the existing content.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="stream">The <see cref="Stream"/> contents to upload.</param>
	/// <param name="options">The desired <see cref="UploadBlobOptions"/> to effect the upload process.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional blob 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	public static async Task<string?> UploadStreamAsync(this CloudStorageContext context,
		Stream stream,
		UploadBlobOptions options,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.UploadStreamAsync(context.ContainerId, context.BlobId!, stream, options, token);
	}

	/// <summary>
	/// Downloads the file from cloud storage.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="destinationFilePath">The full path of where to download the stored file.</param>
	/// <param name="options">The optional <see cref="DownloadBlobOptions"/> options.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>An awaitable public static async Task</returns>
	public static async Task DownloadFileAsync(this CloudStorageContext context,
		string destinationFilePath,
		DownloadBlobOptions? options = null,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		await context.Storage.DownloadFileAsync(context.ContainerId, context.BlobId!, destinationFilePath, options, token);
	}

	/// <summary>
	/// Gets the metadata, if any.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The dictionary of metadata values</returns>
	public static async Task<IDictionary<string, string>> GetMetaDataAsync(this CloudStorageContext context,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.GetMetaDataAsync(context.ContainerId, context.BlobId!, token);
	}

	/// <summary>
	/// Sets the metadata on the specified blob.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="metadata">The metadata to set on the blob.</param>
	/// <param name="conditions">The optional <see cref="RequestBlobConditions"/> that will effect the application of the metadata.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional new VersionId.</returns>
	/// <remarks>
	/// This will create a new version, if the container has versioning enabled. Any 'tags' associated
	/// with the blob before this method call, will not follow with the blob into this new version.
	/// See <see cref="SetTagsAsync(CloudStorageContext, IDictionary{string, string}, RequestBlobConditions?, CancellationToken)"/>
	/// </remarks>
	public static async Task<string?> SetMetaDataAsync(this CloudStorageContext context,
		IDictionary<string, string> metadata,
		RequestBlobConditions? conditions,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.SetMetaDataAsync(context.ContainerId, context.BlobId!, metadata, conditions, token);
	}

	/// <summary>
	/// For systems that support it, sets the supplied tags on the specified blob.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="tags"></param>
	/// <param name="conditions"></param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>An awaitable task.</returns>
	public static async Task SetTagsAsync(this CloudStorageContext context,
		IDictionary<string, string> tags,
		RequestBlobConditions? conditions,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		await context.Storage.SetTagsAsync(context.ContainerId, context.BlobId!, tags, conditions, token);
	}

	/// <summary>
	/// Determines if a blob exists.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns><see langword="true"/> if exists; otherwise <see langword="false"/>.</returns>
	public static async Task<bool> ExistsAsync(this CloudStorageContext context,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.ExistsAsync(context.ContainerId, context.BlobId!, token);
	}

}