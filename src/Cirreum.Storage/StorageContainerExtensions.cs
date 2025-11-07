namespace Cirreum.Storage;

public static class StorageContainerExtensions {

	/// <summary>
	/// Create the storage container, if it doesn't already exist.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <returns>An awaitable task.</returns>
	public static async Task CreateIfNotExistsAsync(this CloudStorageContext context) {
		context.EnsureContainerId();
		await context.Storage.CreateIfNotExistsAsync(context.ContainerId);
	}

	/// <summary>
	/// Deletes the current container and marks this instance as deleted.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <returns>An awaitable task.</returns>
	/// <exception cref="InvalidOperationException">Thrown if this container has already been deleted.</exception>
	/// <remarks>
	/// After calling this method, any further operations on this context will throw an exception.
	/// </remarks>
	public static async Task DeleteContainerAsync(this CloudStorageContext context) {
		context.EnsureContainerId();
		await context.Storage.DeleteContainerAsync(context.ContainerId);
		context.OnContainerDeleted();
	}

	/// <summary>
	/// Deletes one or more blobs from cloud storage.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="prefix">Specifies a string that filters the blobs to be deleted, to include only those whose id begins with the specified value.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>An awaitable Task</returns>
	/// <remarks>
	/// This also deletes any snapshots.
	/// </remarks>
	public static async Task DeleteBlobsAsync(this CloudStorageContext context,
		string prefix,
		CancellationToken token = default) {
		context.EnsureContainerId();
		await context.Storage.DeleteBlobsAsync(context.ContainerId, prefix, token);
	}

	/// <summary>
	/// Delete a blob from cloud storage.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>An awaitable Task</returns>
	/// <remarks>
	/// <c>Important:</c> This also deletes any snapshots.
	/// </remarks>
	public static async Task DeleteBlobAsync(this CloudStorageContext context,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		await context.Storage.DeleteBlobAsync(context.ContainerId, context.BlobId!, token);
		context.OnBlobDeleted();
	}


}