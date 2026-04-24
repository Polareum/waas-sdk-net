namespace Polareum.Waas.Sdk;

/// <summary>Request for querying Ripple native balance.</summary>
public record RippleGetNativeBalanceRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Response with XRP native balance.</summary>
public record RippleGetNativeBalanceResponse(BlockchainAmount Balance);
/// <summary>Request for querying Ripple account details.</summary>
public record RippleGetAccountInfoRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Ripple account information response.</summary>
public record RippleAccountInfoResponse(string Account, BlockchainAmount Balance, long Sequence, long OwnerCount, long? PreviousTransactionLedger, string? PreviousTransactionId, bool Validated);
/// <summary>Request for Ripple fee estimation.</summary>
public record RippleEstimateFeeRequest(NetworkReference NetworkReference);
/// <summary>Ripple fee estimation response.</summary>
public record RippleEstimateFeeResponse(BlockchainAmount OpenLedgerFee, BlockchainAmount MinimumFee, BlockchainAmount MedianFee);
/// <summary>Request for broadcasting signed Ripple transaction blob.</summary>
public record RippleTransferRequest(NetworkReference NetworkReference, string SignedTransactionBlobHex);
/// <summary>Ripple transaction submission response.</summary>
public record RippleTransactionResponse(string TransactionHash, string EngineResult, string EngineResultMessage, bool Accepted);
/// <summary>Request for querying Ripple transaction status.</summary>
public record RippleGetTransactionStatusRequest(NetworkReference NetworkReference, string TransactionHash);
/// <summary>Ripple transaction status response.</summary>
public record RippleTransactionStatusResponse(string TransactionHash, bool IsFound, bool IsPending, bool IsValidated, int? LedgerIndex, string? LedgerHash, string? TransactionResultCode, string? TransactionResultMessage);

/// <summary>Request for querying Solana native balance.</summary>
public record SolanaGetNativeBalanceRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Response with current Solana native balance.</summary>
public record SolanaGetNativeBalanceResponse(BlockchainAmount Balance);
/// <summary>Request for querying Solana account information.</summary>
public record SolanaGetAccountInfoRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Solana account information.</summary>
public record SolanaAccountInfoResponse(string Address, BlockchainAmount Lamports, string Owner, bool Executable, long RentEpoch, long? Space);
/// <summary>Request for broadcasting signed Solana native transfer transaction.</summary>
public record SolanaNativeTransferRequest(NetworkReference NetworkReference, string SignedTransactionBase64);
/// <summary>Solana transaction submission response.</summary>
public record SolanaTransactionResponse(string Signature);
/// <summary>Request for querying Solana transaction status.</summary>
public record SolanaGetTransactionStatusRequest(NetworkReference NetworkReference, string Signature);
/// <summary>Solana transaction status response.</summary>
public record SolanaTransactionStatusResponse(string Signature, bool IsFound, string? ConfirmationStatus, long? Slot, bool HasError, string? ErrorMessage);
/// <summary>Request for Solana fee estimation.</summary>
public record SolanaEstimateFeeRequest(NetworkReference NetworkReference, string MessageBase64);
/// <summary>Solana fee estimation response.</summary>
public record SolanaEstimateFeeResponse(BlockchainAmount EstimatedFee);

/// <summary>Request for querying Stellar native balance.</summary>
public record StellarGetNativeBalanceRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Response with current Stellar native balance.</summary>
public record StellarGetNativeBalanceResponse(BlockchainAmount Balance);
/// <summary>Request for querying Stellar account information.</summary>
public record StellarGetAccountInfoRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Stellar account information.</summary>
public record StellarAccountInfoResponse(string Address, long Sequence, BlockchainAmount NativeBalance, IReadOnlyList<StellarAssetBalanceDto> Balances);
/// <summary>Stellar account asset balance.</summary>
public record StellarAssetBalanceDto(string AssetType, string? AssetCode, string? AssetIssuer, string Balance);
/// <summary>Request for broadcasting signed Stellar native transfer transaction.</summary>
public record StellarNativeTransferRequest(NetworkReference NetworkReference, string SignedTransactionXdrBase64);
/// <summary>Stellar transaction submission response.</summary>
public record StellarTransactionResponse(string TransactionHash, bool IsSuccessful, string? Ledger);
/// <summary>Request for querying Stellar transaction status.</summary>
public record StellarGetTransactionStatusRequest(NetworkReference NetworkReference, string TransactionHash);
/// <summary>Stellar transaction status response.</summary>
public record StellarTransactionStatusResponse(string TransactionHash, bool IsFound, bool IsSuccessful, string? Ledger, string? ResultXdr);
/// <summary>Request for Stellar fee estimation.</summary>
public record StellarEstimateFeeRequest(NetworkReference NetworkReference);
/// <summary>Stellar fee estimation response.</summary>
public record StellarEstimateFeeResponse(BlockchainAmount BaseFee, BlockchainAmount P10Fee, BlockchainAmount P50Fee, BlockchainAmount P95Fee);

/// <summary>Request for querying Sui native balance.</summary>
public record SuiGetNativeBalanceRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Response with current Sui native balance.</summary>
public record SuiGetNativeBalanceResponse(BlockchainAmount Balance);
/// <summary>Request for querying Sui account information.</summary>
public record SuiGetAccountInfoRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Sui account information.</summary>
public record SuiAccountInfoResponse(string Address, BlockchainAmount TotalBalance, int CoinObjectCount, bool HasLockedBalance);
/// <summary>Request for broadcasting signed Sui native transfer transaction.</summary>
public record SuiNativeTransferRequest(NetworkReference NetworkReference, string TransactionBlockBase64, string[] SignaturesBase64, string RequestType = "WaitForLocalExecution");
/// <summary>Sui transaction submission response.</summary>
public record SuiTransactionResponse(string Digest);
/// <summary>Request for querying Sui transaction status.</summary>
public record SuiGetTransactionStatusRequest(NetworkReference NetworkReference, string Digest);
/// <summary>Sui transaction status response.</summary>
public record SuiTransactionStatusResponse(string Digest, bool IsFound, bool IsSuccess, string? Status, string? ErrorMessage, string? Checkpoint, long? TimestampMs);
/// <summary>Request for Sui fee estimation.</summary>
public record SuiEstimateFeeRequest(NetworkReference NetworkReference);
/// <summary>Sui fee estimation response.</summary>
public record SuiEstimateFeeResponse(BlockchainAmount ReferenceGasPrice);

/// <summary>Request for querying TON native balance.</summary>
public record TonGetNativeBalanceRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Response with current TON native balance.</summary>
public record TonGetNativeBalanceResponse(BlockchainAmount Balance);
/// <summary>Request for querying TON account information.</summary>
public record TonGetAccountInfoRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>TON account information response.</summary>
public record TonAccountInfoResponse(string Address, string State, BlockchainAmount NativeBalance, string? LastTransactionHash, string? LastTransactionLt);
/// <summary>Request for broadcasting signed TON native transfer transaction.</summary>
public record TonNativeTransferRequest(NetworkReference NetworkReference, string SignedTransactionBocBase64);
/// <summary>TON transaction submission response.</summary>
public record TonTransactionResponse(string TransactionHash, bool IsAccepted);
/// <summary>Request for querying TON transaction status.</summary>
public record TonGetTransactionStatusRequest(NetworkReference NetworkReference, PublicWalletReference Address, string TransactionHash, int MaxTransactions = 20);
/// <summary>TON transaction status response.</summary>
public record TonTransactionStatusResponse(string TransactionHash, bool IsFound, string? MatchedHash, string? Lt, long? UnixTime);
/// <summary>Request for TON fee estimation.</summary>
public record TonEstimateFeeRequest(NetworkReference NetworkReference, PublicWalletReference Address, string BodyBoc, string? InitCodeBoc, string? InitDataBoc, bool IgnoreCheckSignature = true);
/// <summary>TON fee estimation response.</summary>
public record TonEstimateFeeResponse(BlockchainAmount EstimatedFee, BlockchainAmount InForwardFee, BlockchainAmount StorageFee, BlockchainAmount GasFee, BlockchainAmount ForwardFee);

/// <summary>Request for querying TRON native balance.</summary>
public record TronGetNativeBalanceRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>Response for TRON native balance.</summary>
public record TronGetNativeBalanceResponse(BlockchainAmount Balance);
/// <summary>Request for querying TRON account information.</summary>
public record TronGetAccountInfoRequest(NetworkReference NetworkReference, PublicWalletReference Address);
/// <summary>TRON account information response.</summary>
public record TronAccountInfoResponse(string Address, string State, BlockchainAmount NativeBalance, long? LastOperationUnixTime);
/// <summary>Request for broadcasting a signed TRON native transfer.</summary>
public record TronNativeTransferRequest(NetworkReference NetworkReference, string SignedTransactionHex);
/// <summary>Broadcast result for a TRON transaction.</summary>
public record TronTransactionResponse(string TransactionHash, bool IsAccepted, string? ResultCode, string? ResultMessage);
/// <summary>Request for TRON transaction status.</summary>
public record TronGetTransactionStatusRequest(NetworkReference NetworkReference, string TransactionHash);
/// <summary>TRON transaction status response.</summary>
public record TronTransactionStatusResponse(string TransactionHash, bool IsFound, bool IsPending, bool IsSucceeded, long? BlockNumber, long? BlockTimestamp, string? ResultCode, string? ResultMessage);
/// <summary>Request for TRON fee estimation.</summary>
public record TronEstimateFeeRequest(NetworkReference NetworkReference);
/// <summary>TRON fee estimation response.</summary>
public record TronEstimateFeeResponse(BlockchainAmount TransactionFee, BlockchainAmount EnergyFee);
