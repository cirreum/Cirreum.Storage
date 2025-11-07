# Cirreum Storage Library

[![NuGet Version](https://img.shields.io/nuget/v/Cirreum.Storage.svg?style=flat-square)](https://www.nuget.org/packages/Cirreum.Storage/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Cirreum.Storage.svg?style=flat-square)](https://www.nuget.org/packages/Cirreum.Storage/)
[![GitHub Release](https://img.shields.io/github/v/release/cirreum/Cirreum.Storage?style=flat-square)](https://github.com/cirreum/Cirreum.Storage/releases)

A comprehensive .NET abstraction library for cloud blob storage operations, providing a unified interface for multiple cloud storage providers such as Azure Blob Storage and Amazon S3.

## Overview

The Cirreum Storage Library contains abstractions and contracts for cloud storage systems without external dependencies. It offers a clean, fluent API that abstracts away provider-specific implementations while maintaining full feature compatibility with underlying storage services.

## Features

- **Provider Agnostic**: Unified interface supporting multiple cloud storage providers
- **Fluent API**: Intuitive, context-based method chaining for enhanced developer experience
- **Comprehensive Operations**: Full support for blob lifecycle management including upload, download, metadata, and leasing
- **Advanced Transfer Options**: Configurable parallel transfers, progress tracking, and validation
- **Conditional Operations**: Support for ETags, modification timestamps, and custom conditions
- **Lease Management**: Built-in support for blob leasing operations where supported by the provider
- **Tagging Support**: Metadata and tag management for enhanced blob organization
- **Zero Dependencies**: Clean abstractions without external library dependencies

## Quick Start

### Basic Usage

```csharp
// Initialize your cloud storage client (implementation-specific)
ICloudStorageClient storageClient = new YourCloudStorageImplementation();

// Create a container context
var container = storageClient.UseContainer("my-container");
await container.CreateIfNotExistsAsync();

// Work with a specific blob
var blob = container.WithBlob("my-file.txt");

// Upload content
await blob.UploadContentAsync("Hello, World!", overwrite: true);

// Download to file
await blob.DownloadFileAsync("./downloaded-file.txt");

// Check if blob exists
bool exists = await blob.ExistsAsync();
```

### Advanced Operations

```csharp
// Upload with metadata and progress tracking
var uploadOptions = new UploadBlobOptions
{
    Metadata = new Dictionary<string, string> { ["Author"] = "John Doe" },
    Tags = new Dictionary<string, string> { ["Environment"] = "Production" },
    ProgressHandler = new Progress<long>(bytesTransferred => 
        Console.WriteLine($"Uploaded {bytesTransferred} bytes")),
    TransferOptions = new TransferOptions
    {
        MaximumConcurrency = 4,
        MaximumTransferSize = 8 * 1024 * 1024 // 8MB chunks
    }
};

await blob.UploadFileAsync("./large-file.zip", uploadOptions);

// Conditional operations with ETags
var conditions = new RequestBlobConditions
{
    IfMatch = "\"0x8D9A1B2C3D4E5F6\"",
    LeaseId = "lease-id-here"
};

await blob.SetMetaDataAsync(metadata, conditions);
```

### Lease Management

```csharp
// Acquire a lease for exclusive access
var leaseInfo = await blob.AcquireLeaseAsync(TimeSpan.FromMinutes(1));
Console.WriteLine($"Acquired lease: {leaseInfo.LeaseId}");

// Perform operations with the lease
var conditions = new BlobConditions { LeaseId = leaseInfo.LeaseId };
await blob.UploadContentAsync("Updated content", overwrite: true);

// Release the lease
await blob.ReleaseLeaseAsync();
```

## Core Components

### ICloudStorageClient

The main interface providing all cloud storage operations. Implementations should provide:

- Container management (create, delete)
- Blob upload/download operations
- Metadata and tag management
- Lease operations
- Conditional request support

### CloudStorageContext

A fluent context object that encapsulates storage client, container, and optional blob information:

```csharp
public class CloudStorageContext
{
    public string ContainerId { get; }
    public string? BlobId { get; }
    public CloudStorageContext WithBlob(string blobId);
}
```

### Extension Methods

The library provides rich extension methods organized by functionality:

- **StorageBlobExtensions**: Core blob operations (upload, download, metadata)
- **StorageContainerExtensions**: Container-level operations
- **StorageLeaseExtensions**: Lease management operations
- **CloudStorageExtensions**: Entry point extensions

## Configuration Options

### Upload Options

```csharp
public class UploadBlobOptions
{
    public IDictionary<string, string>? Metadata { get; set; }
    public IDictionary<string, string>? Tags { get; set; }
    public RequestBlobConditions? RequestConditions { get; set; }
    public IProgress<long>? ProgressHandler { get; set; }
    public TransferOptions TransferOptions { get; set; }
    public TransferValidationOptions? TransferValidation { get; set; }
}
```

### Transfer Options

```csharp
public struct TransferOptions
{
    public long? MaximumTransferSize { get; set; }
    public int? MaximumConcurrency { get; set; }
    public long? InitialTransferSize { get; set; }
}
```

### Request Conditions

```csharp
public class RequestBlobConditions : BlobConditions
{
    public DateTimeOffset? IfModifiedSince { get; set; }
    public DateTimeOffset? IfUnmodifiedSince { get; set; }
    public string? IfMatch { get; set; }
    public string? IfNoneMatch { get; set; }
    public string? LeaseId { get; set; }
    public string? TagConditions { get; set; }
}
```

## Error Handling

The library follows standard .NET exception patterns. Most operations may throw:

- `InvalidOperationException`: When container or blob IDs are missing or objects have been deleted
- `RequestFailedException`: Provider-specific failures (implementation-dependent)

```csharp
try
{
    await blob.UploadContentAsync("content", overwrite: false);
}
catch (InvalidOperationException ex)
{
    // Handle missing container/blob ID or deleted objects
}
catch (RequestFailedException ex)
{
    // Handle provider-specific errors
}
```

## Implementation Guide

To implement this library for a specific cloud provider:

1. **Implement ICloudStorageClient**: Create a concrete implementation for your target cloud provider
2. **Handle Provider Specifics**: Map provider-specific exceptions and features to the common interface
3. **Support Optional Features**: Implement leasing, tagging, and other advanced features where supported
4. **Configure Validation**: Set up appropriate transfer validation for your provider

```csharp
public class AzureBlobStorageClient : ICloudStorageClient
{
    public string AccountName => _blobServiceClient.AccountName;
    
    public async Task<string?> UploadFileAsync(string containerId, string blobId, 
        string sourceFilePath, bool overwrite, CancellationToken token = default)
    {
        // Azure-specific implementation
    }
    
    // ... implement other interface members
}
```

---

**Cirreum Foundation Framework** - Layered simplicity for modern .NET