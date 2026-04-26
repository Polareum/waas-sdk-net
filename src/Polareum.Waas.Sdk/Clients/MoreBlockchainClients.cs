using Polareum.Waas.Sdk.Internals;

namespace Polareum.Waas.Sdk;

/// <summary>Provides Ripple APIs.</summary>


internal sealed class RippleClient(WaasRequestExecutor executor) : IRippleClient
{
	public Task<RippleGetNativeBalanceResponse> GetBalanceOfAsync(RippleGetNativeBalanceRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<RippleGetNativeBalanceResponse>("api/ripple/balance-of", request, null, cancellationToken);
	public Task<RippleAccountInfoResponse> GetAccountInfoAsync(RippleGetAccountInfoRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<RippleAccountInfoResponse>("api/ripple/account-info", request, null, cancellationToken);
	public Task<RippleEstimateFeeResponse> EstimateFeeAsync(RippleEstimateFeeRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<RippleEstimateFeeResponse>("api/ripple/estimate-fee", null, request, cancellationToken);
	public Task<RippleTransactionResponse> TransferAsync(RippleTransferRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<RippleTransactionResponse>("api/ripple/transfer", null, request, cancellationToken);
	public Task<RippleTransactionStatusResponse> GetTransactionStatusAsync(RippleGetTransactionStatusRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<RippleTransactionStatusResponse>("api/ripple/transaction-status", request, null, cancellationToken);
}

/// <summary>Provides Solana APIs.</summary>


internal sealed class SolanaClient(WaasRequestExecutor executor) : ISolanaClient
{
	public Task<SolanaGetNativeBalanceResponse> GetNativeBalanceAsync(SolanaGetNativeBalanceRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<SolanaGetNativeBalanceResponse>("api/solana/native-balance", request, cancellationToken);
	public Task<SolanaAccountInfoResponse> GetAccountInfoAsync(SolanaGetAccountInfoRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<SolanaAccountInfoResponse>("api/solana/account-info", request, cancellationToken);
	public Task<SolanaTransactionResponse> NativeTransferAsync(SolanaNativeTransferRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<SolanaTransactionResponse>("api/solana/native-transfer", null, request, cancellationToken);
	public Task<SolanaEstimateFeeResponse> EstimateFeeAsync(SolanaEstimateFeeRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<SolanaEstimateFeeResponse>("api/solana/estimate-fee", null, request, cancellationToken);
	public Task<SolanaTransactionStatusResponse> GetTransactionStatusAsync(SolanaGetTransactionStatusRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<SolanaTransactionStatusResponse>("api/solana/transaction-status", request, cancellationToken);
}

/// <summary>Provides Stellar APIs.</summary>


internal sealed class StellarClient(WaasRequestExecutor executor) : IStellarClient
{
	public Task<StellarGetNativeBalanceResponse> GetNativeBalanceAsync(StellarGetNativeBalanceRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<StellarGetNativeBalanceResponse>("api/stellar/native-balance", request, cancellationToken);
	public Task<StellarAccountInfoResponse> GetAccountInfoAsync(StellarGetAccountInfoRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<StellarAccountInfoResponse>("api/stellar/account-info", request, cancellationToken);
	public Task<StellarTransactionResponse> NativeTransferAsync(StellarNativeTransferRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<StellarTransactionResponse>("api/stellar/native-transfer", null, request, cancellationToken);
	public Task<StellarEstimateFeeResponse> EstimateFeeAsync(StellarEstimateFeeRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<StellarEstimateFeeResponse>("api/stellar/estimate-fee", request, cancellationToken);
	public Task<StellarTransactionStatusResponse> GetTransactionStatusAsync(StellarGetTransactionStatusRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<StellarTransactionStatusResponse>("api/stellar/transaction-status", request, cancellationToken);
}

/// <summary>Provides Sui APIs.</summary>


internal sealed class SuiClient(WaasRequestExecutor executor) : ISuiClient
{
	public Task<SuiGetNativeBalanceResponse> GetNativeBalanceAsync(SuiGetNativeBalanceRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<SuiGetNativeBalanceResponse>("api/sui/native-balance", request, cancellationToken);
	public Task<SuiAccountInfoResponse> GetAccountInfoAsync(SuiGetAccountInfoRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<SuiAccountInfoResponse>("api/sui/account-info", request, cancellationToken);
	public Task<SuiTransactionResponse> NativeTransferAsync(SuiNativeTransferRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<SuiTransactionResponse>("api/sui/native-transfer", null, request, cancellationToken);
	public Task<SuiEstimateFeeResponse> EstimateFeeAsync(SuiEstimateFeeRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<SuiEstimateFeeResponse>("api/sui/estimate-fee", null, request, cancellationToken);
	public Task<SuiTransactionStatusResponse> GetTransactionStatusAsync(SuiGetTransactionStatusRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<SuiTransactionStatusResponse>("api/sui/transaction-status", request, cancellationToken);
}

/// <summary>Provides TON APIs.</summary>


internal sealed class TonClient(WaasRequestExecutor executor) : ITonClient
{
	public Task<TonGetNativeBalanceResponse> GetNativeBalanceAsync(TonGetNativeBalanceRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<TonGetNativeBalanceResponse>("api/ton/native-balance", request, cancellationToken);
	public Task<TonAccountInfoResponse> GetAccountInfoAsync(TonGetAccountInfoRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<TonAccountInfoResponse>("api/ton/account-info", request, cancellationToken);
	public Task<TonTransactionResponse> NativeTransferAsync(TonNativeTransferRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<TonTransactionResponse>("api/ton/native-transfer", null, request, cancellationToken);
	public Task<TonEstimateFeeResponse> EstimateFeeAsync(TonEstimateFeeRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<TonEstimateFeeResponse>("api/ton/estimate-fee", null, request, cancellationToken);
	public Task<TonTransactionStatusResponse> GetTransactionStatusAsync(TonGetTransactionStatusRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<TonTransactionStatusResponse>("api/ton/transaction-status", request, cancellationToken);
}

/// <summary>Provides TRON APIs.</summary>


internal sealed class TronClient(WaasRequestExecutor executor) : ITronClient
{
	public Task<TronGetNativeBalanceResponse> GetNativeBalanceAsync(TronGetNativeBalanceRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<TronGetNativeBalanceResponse>("api/tron/native-balance", request, cancellationToken);
	public Task<TronAccountInfoResponse> GetAccountInfoAsync(TronGetAccountInfoRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<TronAccountInfoResponse>("api/tron/account-info", request, cancellationToken);
	public Task<TronTransactionResponse> NativeTransferAsync(TronNativeTransferRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<TronTransactionResponse>("api/tron/native-transfer", null, request, cancellationToken);
	public Task<TronEstimateFeeResponse> EstimateFeeAsync(TronEstimateFeeRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<TronEstimateFeeResponse>("api/tron/estimate-fee", null, request, cancellationToken);
	public Task<TronTransactionStatusResponse> GetTransactionStatusAsync(TronGetTransactionStatusRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<TronTransactionStatusResponse>("api/tron/transaction-status", request, cancellationToken);
}
