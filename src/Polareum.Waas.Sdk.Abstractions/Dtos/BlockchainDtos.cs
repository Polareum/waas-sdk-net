using System.Numerics;
using System.Text.Json.Serialization;

namespace Polareum.Waas.Sdk;

/// <summary>
/// Defines the fee policy for UTXO transfers.
/// </summary>
public record UtxoFeePolicyDto([property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger? FeeRateSatoshiPerByte, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger? AbsoluteFeeSatoshi);

/// <summary>
/// Request to get a UTXO native balance.
/// </summary>
public record UtxoGetNativeBalanceRequest(NetworkReference NetworkReference, PublicWalletReference Address);

/// <summary>
/// Response containing UTXO native balances.
/// </summary>
public record UtxoGetNativeBalanceResponse(BlockchainAmount Balance, BlockchainAmount UnconfirmedBalance);

/// <summary>
/// Request to estimate a UTXO fee rate.
/// </summary>
public record UtxoEstimateFeeRequest(NetworkReference NetworkReference, int TargetBlocks = 6, string? EstimateMode = null);

/// <summary>
/// Response containing a UTXO transaction id.
/// </summary>
public record UtxoTransactionResponse(string TransactionId);

/// <summary>
/// Request for a simple UTXO native transfer.
/// </summary>
public record UtxoNativeTransferSimpleRequest(NetworkReference NetworkReference, WalletReference From, PublicWalletReference ToAddress, BlockchainAmount Amount, UtxoFeePolicyDto? FeePolicy, PublicWalletReference? ChangeAddress);

/// <summary>
/// Request to list unspent UTXO outputs.
/// </summary>
public record UtxoListUnspentRequest(NetworkReference NetworkReference, PublicWalletReference Address, int MinConfirmations = 1, int MaxConfirmations = 9999999);

/// <summary>
/// Response containing unspent UTXO outputs.
/// </summary>
public record UtxoListUnspentResponse(List<UtxoUnspentOutput> Outputs);

/// <summary>
/// Represents an unspent UTXO output.
/// </summary>
public record UtxoUnspentOutput(string TransactionId, uint OutputIndex, BlockchainAmount Amount, PublicWalletReference Address, uint Confirmations, byte[]? ScriptPubKey, byte[]? PublicKey);

/// <summary>
/// Represents a UTXO transaction output.
/// </summary>
public record UtxoOutput(PublicWalletReference Address, BlockchainAmount Amount);

/// <summary>
/// Represents a UTXO transaction input.
/// </summary>
public record UtxoInput(string TransactionId, uint OutputIndex, BlockchainAmount Amount, PublicWalletReference Address, byte[]? ScriptPubKey, byte[]? PublicKey, byte[]? Signature);

/// <summary>
/// Request to sign a raw UTXO transaction.
/// </summary>
public record UtxoNativeTransferSignRequest(NetworkReference NetworkReference, WalletReference SignerWallet, string TransactionHex);

/// <summary>
/// Response containing signed UTXO transaction hex.
/// </summary>
public record UtxoNativeTransferSignResponse(string SignedTransactionHex);

/// <summary>
/// Request to broadcast a signed UTXO transaction.
/// </summary>
public record UtxoNativeTransferBroadcastRequest(NetworkReference NetworkReference, string SignedTransactionHex);

/// <summary>
/// Request to query native balance for account-based blockchains.
/// </summary>
public record NativeBalanceRequest(NetworkReference NetworkReference, PublicWalletReference Address);

/// <summary>
/// Request to query transaction status by hash.
/// </summary>
public record TransactionStatusRequest(NetworkReference NetworkReference, string TransactionHash);

/// <summary>
/// Request to broadcast signed transaction payloads that are represented as a single string.
/// </summary>
public record SignedPayloadRequest(NetworkReference NetworkReference, string SignedPayload);

/// <summary>
/// Request for querying Cardano native balance.
/// </summary>
public record CardanoGetNativeBalanceRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Response with Cardano native balance.</summary>
public record CardanoGetNativeBalanceResponse(BlockchainAmount Balance);
/// <summary>Request for querying Cardano address details.</summary>
public record CardanoGetAccountInfoRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Cardano address details response.</summary>
public record CardanoAccountInfoResponse(string Address, string? StakeAddress, string? AddressType, bool IsScript, int TransactionCount, BlockchainAmount Balance);
/// <summary>Request for Cardano transaction fee estimation.</summary>
public record CardanoEstimateFeeRequest(NetworkReference NetworkReference, int TransactionSizeBytes);
/// <summary>Response for Cardano transaction fee estimation.</summary>
public record CardanoEstimateFeeResponse(BlockchainAmount EstimatedFee);
/// <summary>Request for broadcasting a signed Cardano transaction.</summary>
public record CardanoTransferRequest(NetworkReference NetworkReference, string SignedTransactionCborHex);
/// <summary>Cardano transaction submission response.</summary>
public record CardanoTransactionResponse(string TransactionHash);
/// <summary>Request for querying Cardano transaction status.</summary>
public record CardanoGetTransactionStatusRequest(NetworkReference NetworkReference, string TransactionHash);
/// <summary>Cardano transaction status response.</summary>
public record CardanoTransactionStatusResponse(string TransactionHash, bool IsFound, bool IsPending, string? BlockHash, long? BlockHeight, BlockchainAmount? Fee);

/// <summary>Request for querying NEAR native balance.</summary>
public record NearGetNativeBalanceRequest(NetworkReference NetworkReference, string AccountId);
/// <summary>Response with NEAR native balance.</summary>
public record NearGetNativeBalanceResponse(BlockchainAmount Balance);
/// <summary>Request for querying NEAR account details.</summary>
public record NearGetAccountInfoRequest(NetworkReference NetworkReference, string AccountId);
/// <summary>NEAR account information response.</summary>
public record NearAccountInfoResponse(string AccountId, BlockchainAmount Amount, BlockchainAmount Locked, string CodeHash, long StorageUsage, long StoragePaidAt, long BlockHeight, string BlockHash);
/// <summary>Request for broadcasting a signed NEAR native transfer.</summary>
public record NearNativeTransferRequest(NetworkReference NetworkReference, string SignedTransactionBase64);
/// <summary>Request for querying NEAR transaction status.</summary>
public record NearGetTransactionStatusRequest(NetworkReference NetworkReference, string TransactionHash, string SignerAccountId);
/// <summary>NEAR transaction status response.</summary>
public record NearTransactionStatusResponse(string TransactionHash, string SignerAccountId, string FinalExecutionStatus, string? BlockHash);
/// <summary>Request for NEAR fee estimation.</summary>
public record NearEstimateFeeRequest(NetworkReference NetworkReference, long GasUnits);
/// <summary>NEAR fee estimation response.</summary>
public record NearEstimateFeeResponse(BlockchainAmount EstimatedFee, BlockchainAmount GasPrice);
/// <summary>Request for listing NEAR access keys.</summary>
public record NearGetAccessKeysRequest(NetworkReference NetworkReference, string AccountId);
/// <summary>NEAR access key list response.</summary>
public record NearAccessKeysResponse(string AccountId, IReadOnlyList<NearAccessKeyItemDto> Keys, long BlockHeight, string BlockHash);
/// <summary>NEAR access key item.</summary>
public record NearAccessKeyItemDto(string PublicKey, long Nonce, string PermissionType, string? Allowance, string? ReceiverId, IReadOnlyList<string>? MethodNames);
/// <summary>Request for broadcasting a signed NEAR create-account transaction.</summary>
public record NearCreateAccountRequest(NetworkReference NetworkReference, string SignedTransactionBase64);
/// <summary>Request for broadcasting a signed NEAR delete-account transaction.</summary>
public record NearDeleteAccountRequest(NetworkReference NetworkReference, string SignedTransactionBase64);
/// <summary>NEAR transaction submission response.</summary>
public record NearTransactionResponse(string TransactionHash, string SignerAccountId, string ReceiverAccountId, string FinalExecutionStatus);

/// <summary>Request DTO to retrieve the native balance for a Polkadot account.</summary>
public record PolkadotGetNativeBalanceRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Response DTO containing the free native balance of a Polkadot account.</summary>
public record PolkadotGetNativeBalanceResponse(BlockchainAmount Balance);
/// <summary>Request DTO to retrieve detailed Polkadot account information.</summary>
public record PolkadotGetAccountInfoRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Response DTO containing detailed Polkadot account information.</summary>
public record PolkadotAccountInfoResponse(string Nonce, BlockchainAmount Free, BlockchainAmount Reserved, BlockchainAmount MiscFrozen, BlockchainAmount FeeFrozen, string Consumers, string Providers, string Sufficients);
/// <summary>Request DTO for Polkadot fee estimation.</summary>
public record PolkadotEstimateFeeRequest(NetworkReference NetworkReference, string SignedExtrinsicHex);
/// <summary>Response DTO containing estimated Polkadot transaction fee.</summary>
public record PolkadotEstimateFeeResponse(BlockchainAmount EstimatedFee);
/// <summary>Request DTO for broadcasting a signed Polkadot transfer extrinsic.</summary>
public record PolkadotTransferRequest(NetworkReference NetworkReference, string SignedExtrinsicHex);
/// <summary>Response DTO containing the submitted Polkadot transaction hash.</summary>
public record PolkadotTransactionResponse(string TransactionHash);
/// <summary>Request DTO for retrieving Polkadot transaction status.</summary>
public record PolkadotGetTransactionStatusRequest(NetworkReference NetworkReference, string TransactionHash);
/// <summary>Response DTO containing Polkadot transaction status.</summary>
public record PolkadotTransactionStatusResponse(string TransactionHash, bool IsFound, bool IsPending, string? BlockHash, long? BlockNumber);
