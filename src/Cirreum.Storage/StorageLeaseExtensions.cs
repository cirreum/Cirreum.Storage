namespace Cirreum.Storage;

/// <summary>
/// Defines the methods for interacting with a cloud Blob Leasing service.
/// </summary>
/// <remarks>
/// Such as for Azure Storage or AWS S3
/// </remarks>
public static class StorageLeaseExtensions {

	/// <summary>
	/// For systems that support it, attempts to acquire a lease on the storage object.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="duration"></param>
	/// <param name="conditions"></param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The <see cref="LeaseInfo"/>.</returns>
	public static async Task<LeaseInfo> AcquireLeaseAsync(this CloudStorageContext context,
		TimeSpan duration,
		BlobConditions? conditions = null,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.AcquireLeaseAsync(context.ContainerId, context.BlobId!, duration, conditions, token);
	}

	/// <summary>
	/// For systems that support it, attempts to renew a lease on the storage object.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="conditions"></param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The <see cref="LeaseInfo"/>.</returns>
	public static async Task<LeaseInfo> RenewLeaseAsync(this CloudStorageContext context,
		BlobConditions? conditions = null,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.RenewLeaseAsync(context.ContainerId, context.BlobId!, conditions, token);
	}

	/// <summary>
	/// For systems that support it, releases a lease on the storage object.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The <see cref="LeaseInfo"/>.</returns>
	public static async Task<LeaseInfo> ReleaseLeaseAsync(this CloudStorageContext context,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.ReleaseLeaseAsync(context.ContainerId, context.BlobId!, token);
	}

	/// <summary>
	/// For systems that support it, breaks a lease on the storage object.
	/// </summary>
	/// <param name="context">The <see cref="CloudStorageContext"/>.</param>
	/// <param name="breakPeriod"></param>
	/// <param name="conditions"></param>
	/// <param name="token">The optional <see cref="CancellationToken"/>, to support cancellation.</param>
	/// <returns>The <see cref="LeaseInfo"/>.</returns>
	public static async Task<LeaseInfo> BreakLeaseAsync(this CloudStorageContext context,
		TimeSpan? breakPeriod,
		BlobConditions? conditions = null,
		CancellationToken token = default) {
		context.EnsureContainerId();
		context.EnsureBlobId();
		return await context.Storage.BreakLeaseAsync(context.ContainerId, context.BlobId!, breakPeriod, conditions, token);
	}

}