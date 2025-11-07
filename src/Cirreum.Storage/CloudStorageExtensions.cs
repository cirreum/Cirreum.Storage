namespace Cirreum.Storage;

/// <summary>
/// 
/// </summary>
public static class CloudStorageExtensions {

	/// <summary>
	/// 
	/// </summary>
	/// <param name="storage"></param>
	/// <param name="containerId"></param>
	/// <returns></returns>
	public static CloudStorageContext UseContainer(this ICloudStorageClient storage,
		string containerId) {
		return new CloudStorageContext(storage, containerId);
	}

}