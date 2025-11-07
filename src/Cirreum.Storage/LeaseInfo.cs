namespace Cirreum.Storage;

/// <summary>
/// Information related to a lease.
/// </summary>
/// <param name="LeaseId">Uniquely identifies a container's or blob's lease.</param>
/// <param name="LeaseTime">The approximate time remaining in the lease period, in seconds. This is only provided when breaking a lease.</param>
/// <param name="LastModified">The date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob</param>
/// <param name="Etag">The ETag contains a value that you can use to perform operations conditionally.</param>
public record LeaseInfo(string LeaseId, int? LeaseTime, DateTimeOffset LastModified, string Etag);