namespace Cirreum.Storage;

/// <summary>
/// Defines the interface for a Cloud Blob Storage Client.
/// </summary>
/// <remarks>
/// Such as for Azure Storage or AWS S3
/// </remarks>
public interface ICloudStorageClient {

	/// <summary>
	/// Gets the Account Name from the underlying storage client.
	/// </summary>
	string AccountName { get; }

	/// <summary>
	/// Exposes the underlying service client to allow support for api methods beyond
	/// this interface.
	/// </summary>
	/// <typeparam name="TClient">The Type of the client.</typeparam>
	/// <param name="callback">A callback used to execute the user specific method on the client.</param>
	/// <returns>An awaitable task.</returns>
	Task UsingClientAsync<TClient>(Func<TClient, Task> callback) where TClient : class;

	/// <summary>
	/// Exposes the underlying service client to allow support for api methods beyond
	/// this interface.
	/// </summary>
	/// <typeparam name="TClient">The Type of the client.</typeparam>
	/// <typeparam name="TResult">The Type of the result.</typeparam>
	/// <param name="callback">A callback used to execute the user specific method on the client.</param>
	/// <returns>An awaitable task.</returns>
	Task<TResult> UsingClientAsync<TClient, TResult>(Func<TClient, Task<TResult>> callback) where TClient : class;

	/// <summary>
	/// Create the storage container, if it doesn't already exist.
	/// </summary>
	/// <param name="containerId">The container to create.</param>
	/// <returns>An awaitable task.</returns>
	Task CreateIfNotExistsAsync(string containerId);

	/// <summary>
	/// Deletes the storage container, if it exists.
	/// </summary>
	/// <param name="containerId">The container to delete.</param>
	/// <returns>An awaitable task.</returns>
	Task DeleteContainerAsync(string containerId);

	/// <summary>
	/// The <see cref="UploadFileAsync(string, string, string, bool, CancellationToken)"/> operation
	/// creates a new block blob or throws if the blob already exists.
	/// Setting <paramref name="overwrite"/> to true allows updating the
	/// content of an existing block blob. Updating an existing block blob
	/// overwrites any existing metadata on the blob.
	/// </summary>
	/// <param name="containerId">The id of the container where the file will be stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="sourceFilePath">The full path of the source file to be uploaded.</param>
	/// <param name="overwrite">Whether the upload should overwrite any existing blobs. The default value is false.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional cloud file 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	Task<string?> UploadFileAsync(
		string containerId,
		string blobId,
		string sourceFilePath,
		bool overwrite,
		CancellationToken token = default);

	/// <summary>
	/// The <see cref="UploadFileAsync(string, string, string, bool, IDictionary{string, string}, CancellationToken)"/> operation
	/// creates a new block blob or throws if the blob already exists.
	/// Setting <paramref name="overwrite"/> to true allows updating the
	/// content of an existing block blob. Updating an existing block blob
	/// overwrites any existing metadata on the blob.
	/// </summary>
	/// <param name="containerId">The id of the container where the file will be stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="sourceFilePath">The full path of the source file to be uploaded.</param>
	/// <param name="overwrite">Whether the upload should overwrite any existing blobs. The default value is false.</param>
	/// <param name="metaData">The metadata to associate with the file</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional cloud file 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	Task<string?> UploadFileAsync(
		string containerId,
		string blobId,
		string sourceFilePath,
		bool overwrite,
		IDictionary<string, string> metaData,
		CancellationToken token = default);

	/// <summary>
	/// Uploads the file to cloud storage overwriting the existing content.
	/// </summary>
	/// <param name="containerId">The id of the container where the file will be stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="sourceFilePath">The full path of the source file to be uploaded.</param>
	/// <param name="options">The desired <see cref="UploadBlobOptions"/> to effect the upload process.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional cloud file 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	Task<string?> UploadFileAsync(
		string containerId,
		string blobId,
		string sourceFilePath,
		UploadBlobOptions options,
		CancellationToken token = default);

	/// <summary>
	/// The <see cref="UploadContentAsync(string, string, string, bool, CancellationToken)"/> operation
	/// creates a new block blob or throws if the blob already exists.
	/// Setting <paramref name="overwrite"/> to true allows updating the
	/// content of an existing block blob. Updating an existing block blob
	/// overwrites any existing metadata on the blob.
	/// </summary>
	/// <param name="containerId">The id of the container where the file will be stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="content">The string contents to upload.</param>
	/// <param name="overwrite">Whether the upload should overwrite any existing blobs. The default value is false.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional cloud file 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	Task<string?> UploadContentAsync(
		string containerId,
		string blobId,
		string content,
		bool overwrite,
		CancellationToken token = default);

	/// <summary>
	/// Uploads the content to cloud storage overwriting the existing content.
	/// </summary>
	/// <param name="containerId">The id of the container where the file will be stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="content">The string contents to upload.</param>
	/// <param name="options">The desired <see cref="UploadBlobOptions"/> to effect the upload process.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional cloud file 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	Task<string?> UploadContentAsync(
		string containerId,
		string blobId,
		string content,
		UploadBlobOptions options,
		CancellationToken token = default);


	/// <summary>
	/// The <see cref="UploadStreamAsync(string, string, Stream, bool, CancellationToken)"/> operation
	/// creates a new block blob or throws if the blob already exists.
	/// Setting <paramref name="overwrite"/> to true allows updating the
	/// content of an existing block blob. Updating an existing block blob
	/// overwrites any existing metadata on the blob.
	/// </summary>
	/// <param name="containerId">The id of the container where the file will be stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="stream">The <see cref="Stream"/> contents to upload.</param>
	/// <param name="overwrite">Whether the upload should overwrite any existing blobs. The default value is false.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional cloud file 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	Task<string?> UploadStreamAsync(
		string containerId,
		string blobId,
		Stream stream,
		bool overwrite,
		CancellationToken token = default);

	/// <summary>
	/// Uploads the stream to cloud storage overwriting the existing content.
	/// </summary>
	/// <param name="containerId">The id of the container where the file will be stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="stream">The <see cref="Stream"/> contents to upload.</param>
	/// <param name="options">The desired <see cref="UploadBlobOptions"/> to effect the upload process.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional cloud file 'Version' ID, if the service provider supports versioning; otherwise null.</returns>
	/// <remarks>
	/// A RequestFailedException will be thrown if
	/// a failure occurs.
	/// </remarks>
	Task<string?> UploadStreamAsync(
		string containerId,
		string blobId,
		Stream stream,
		UploadBlobOptions options,
		CancellationToken token = default);

	/// <summary>
	/// Downloads the file from cloud storage.
	/// </summary>
	/// <param name="containerId">The id of the container where the blob is stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="destinationFilePath">The full path of where to download the stored file.</param>
	/// <param name="options">The optional <see cref="DownloadBlobOptions"/> options.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>An awaitable Task</returns>
	Task DownloadFileAsync(
		string containerId,
		string blobId,
		string destinationFilePath,
		DownloadBlobOptions? options = null,
		CancellationToken token = default);


	/// <summary>
	/// Gets the <paramref name="blobId"/> (blob) metadata, if any.
	/// </summary>
	/// <param name="containerId">The id of the container where the blob is stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The dictionary of metadata values</returns>
	Task<IDictionary<string, string>> GetMetaDataAsync(
		string containerId,
		string blobId,
		CancellationToken token = default);

	/// <summary>
	/// Sets the metadata for the <paramref name="blobId"/> (blob).
	/// </summary>
	/// <param name="containerId">The id of the container where the blob is stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="metadata">The metadata to set on the <paramref name="blobId"/> (blob)</param>
	/// <param name="conditions">The optional <see cref="RequestBlobConditions"/> that will effect the application of the metadata.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The optional new VersionId.</returns>
	/// <remarks>
	/// This will create a new version, if the container has versioning enabled. Any 'tags' associated
	/// with the blob before this method call, will not follow with the blob into this new version.
	/// See <see cref="SetTagsAsync(string, string, IDictionary{string, string}, RequestBlobConditions?, CancellationToken)"/>
	/// </remarks>
	Task<string?> SetMetaDataAsync(
		string containerId,
		string blobId,
		IDictionary<string, string> metadata,
		RequestBlobConditions? conditions,
		CancellationToken token = default);


	/// <summary>
	/// Delete blobs from cloud storage.
	/// </summary>
	/// <param name="containerId">The id of the container where the blobs are stored.</param>
	/// <param name="prefix">Specifies a string that filters the blobs to be deleted, to include only those whose id begins with the specified value.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>An awaitable Task</returns>
	/// <remarks>
	/// This also deletes any snapshots.
	/// </remarks>
	Task DeleteBlobsAsync(
		string containerId,
		string prefix,
		CancellationToken token = default);

	/// <summary>
	/// Delete a blob from cloud storage.
	/// </summary>
	/// <param name="containerId">The id of the container where the files are stored.</param>
	/// <param name="blobId">Id of the blob to delete.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>An awaitable Task</returns>
	/// <remarks>
	/// This also deletes any snapshots.
	/// </remarks>
	Task DeleteBlobAsync(
		string containerId,
		string blobId,
		CancellationToken token = default);


	/// <summary>
	/// For systems that support it, attempts to acquire a lease on the storage object.
	/// </summary>
	/// <param name="containerId">The id of the container where the blob is stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="duration"></param>
	/// <param name="conditions"></param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The <see cref="LeaseInfo"/>.</returns>
	Task<LeaseInfo> AcquireLeaseAsync(
		string containerId,
		string blobId,
		TimeSpan duration,
		BlobConditions? conditions = null,
		CancellationToken token = default);

	/// <summary>
	/// For systems that support it, attempts to renew a lease on the storage object.
	/// </summary>
	/// <param name="containerId"></param>
	/// <param name="blobId"></param>
	/// <param name="conditions"></param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The <see cref="LeaseInfo"/>.</returns>
	Task<LeaseInfo> RenewLeaseAsync(
		string containerId,
		string blobId,
		BlobConditions? conditions = null,
		CancellationToken token = default);

	/// <summary>
	/// For systems that support it, releases a lease on the storage object.
	/// </summary>
	/// <param name="containerId">The id of the container where the blob is stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The <see cref="LeaseInfo"/>.</returns>
	Task<LeaseInfo> ReleaseLeaseAsync(
		string containerId,
		string blobId,
		CancellationToken token = default);

	/// <summary>
	/// For systems that support it, breaks a lease on the storage object.
	/// </summary>
	/// <param name="containerId">The id of the container where the blob is stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="breakPeriod"></param>
	/// <param name="conditions"></param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The <see cref="LeaseInfo"/>.</returns>
	Task<LeaseInfo> BreakLeaseAsync(
		string containerId,
		string blobId,
		TimeSpan? breakPeriod,
		BlobConditions? conditions = null,
		CancellationToken token = default);


	/// <summary>
	/// For systems that support it, sets the supplied tags on the specified object.
	/// </summary>
	/// <param name="containerId">The id of the container where the blob is stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="tags"></param>
	/// <param name="conditions"></param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>An awaitable task.</returns>
	Task SetTagsAsync(
		string containerId,
		string blobId,
		IDictionary<string, string> tags,
		RequestBlobConditions? conditions,
		CancellationToken token = default);


	/// <summary>
	/// Determines if a blob with the <paramref name="blobId"/> exists.
	/// </summary>
	/// <param name="containerId">The id of the container where the blob is stored.</param>
	/// <param name="blobId">The id of the blob.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns><see langword="true"/> if exists; otherwise <see langword="false"/>.</returns>
	Task<bool> ExistsAsync(
		string containerId,
		string blobId,
		CancellationToken token = default);

}