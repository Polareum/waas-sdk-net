namespace Polareum.Waas.Sdk;

/// <summary>
/// Represents a paged result returned by WAAS list endpoints.
/// </summary>
public record PagedResult<T>(int TotalItemsCount, List<T> Items);

/// <summary>
/// Represents the base query fields used by paged WAAS searches.
/// </summary>
public record SearchModel(int Page, int PageSize, string? OrderBy);

/// <summary>
/// Search model for owner wallet list endpoints.
/// </summary>
public record OwnerWalletSearchModel(int Page, int PageSize, string? Name, string? PartialName, string? OrderBy) : SearchModel(Page, PageSize, OrderBy);

/// <summary>
/// Search model for administrative wallet list endpoints.
/// </summary>
public record AdminWalletSearchModel(int Page, int PageSize, Guid? ApiKeyId, string? Name, string? PartialName, string? OrderBy) : SearchModel(Page, PageSize, OrderBy);

/// <summary>
/// Search model for blockchain network list endpoints.
/// </summary>
public record BlockchainNetworkSearchModel(int Page, int PageSize, string? Name, string? PartialName, BlockchainType[]? BlockchainTypes, string? OrderBy) : SearchModel(Page, PageSize, OrderBy);

/// <summary>
/// Summarizes a wallet API key for owner-facing responses.
/// </summary>
public record WalletApiKeyListItemForUserDto(Guid Id, string Name);

/// <summary>
/// Represents a wallet API key returned in wallet details.
/// </summary>
public record WalletApiKeyDto(Guid Id, string Name, string HashApiKeyHex, DateTime CreatedAt, DateTime UpdatedAt);

/// <summary>
/// Summarizes a wallet in list responses.
/// </summary>
public record WalletListItemDto(Guid Id, string Name, WalletApiKeyListItemForUserDto Owner, Guid? ParentWalletId, DateTime CreatedAt, DateTime UpdatedAt);

/// <summary>
/// Represents wallet details.
/// </summary>
public record WalletDto(Guid Id, string Name, WalletApiKeyDto Owner, Guid? ParentWalletId, DateTime CreatedAt, DateTime UpdatedAt);

/// <summary>
/// Represents exported wallet key material and generated addresses.
/// </summary>
public record ExportedWalletDto(Guid Id, string Name, string PrivateKeyHex, string? ChainCodeHex, WalletAddressDto[] Addresses);

/// <summary>
/// Represents a generated wallet address.
/// </summary>
public record WalletAddressDto(Guid Id, BlockchainType BlockchainType, string PublicAddress, string PublicKey);

/// <summary>
/// Request to generate a wallet from random key material.
/// </summary>
public record GenerateRandomKeyWalletRequest(string Name, bool Exportable);

/// <summary>
/// Request to import a wallet from mnemonic words.
/// </summary>
public record ImportWalletByMnemonicsRequest(string Name, string Mnemonics, bool Exportable = false);

/// <summary>
/// Request to import a wallet from a private key.
/// </summary>
public record ImportWalletByPrivateKeyRequest(string Name, string PrivateKeyHex, string? ChainCodeHex, bool Exportable = false);

/// <summary>
/// Request to resolve or generate a wallet address for a network.
/// </summary>
public record GetOrGenerateAddressForBlockchainByOwnerRequest(WalletReference WalletReference, NetworkReference NetworkReference, bool StoreAddress = true);

/// <summary>
/// Summarizes a blockchain network for administrative listings.
/// </summary>
public record BlockchainNetworkListItemForAdminDto(Guid Id, string Name, BlockchainType BlockchainType, string RpcUrl, string? RpcAuth, string? ChainIdentifier, int NativeCoinDecimals, DateTime CreatedAt, DateTime UpdatedAt);

/// <summary>
/// Summarizes a blockchain network for owner-facing listings.
/// </summary>
public record BlockchainNetworkListItemForUsersDto(Guid Id, string Name, BlockchainType BlockchainType, string? ChainIdentifier, int NativeCoinDecimals);

/// <summary>
/// Represents blockchain network details for administrators.
/// </summary>
public record BlockchainNetworkForAdminDto(Guid Id, string Name, BlockchainType BlockchainType, string RpcUrl, string? RpcAuth, string? ChainIdentifier, int NativeCoinDecimals, bool? EvmUseLegacyTransaction, bool? EvmCalculateGasIfNotSet, DateTime CreatedAt, DateTime UpdatedAt);

/// <summary>
/// Represents blockchain network details for owner-facing responses.
/// </summary>
public record BlockchainNetworkForUsersDto(Guid Id, string Name, BlockchainType BlockchainType, string? ChainIdentifier, int NativeCoinDecimals);

/// <summary>
/// Request to add a blockchain network.
/// </summary>
public record AddBlockchainNetworkRequest(string Name, BlockchainType BlockchainType, string RpcUrl, string? RpcAuth, string? ChainIdentifier, int NativeCoinDecimals, bool? EvmUseLegacyTransaction, bool? EvmCalculateGasIfNotSet);

/// <summary>
/// Request to update a blockchain network.
/// </summary>
public record UpdateBlockchainNetworkRequest(string Name, BlockchainType BlockchainType, string RpcUrl, string? RpcAuth, string? ChainIdentifier, int NativeCoinDecimals, bool? EvmUseLegacyTransaction, bool? EvmCalculateGasIfNotSet);
