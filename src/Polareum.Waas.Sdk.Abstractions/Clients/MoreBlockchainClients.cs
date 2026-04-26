
namespace Polareum.Waas.Sdk;

/// <summary>Provides Ripple APIs.</summary>
public interface IRippleClient
{
	/// <summary>Gets native balance.</summary>
	Task<RippleGetNativeBalanceResponse> GetBalanceOfAsync(RippleGetNativeBalanceRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets account information.</summary>
	Task<RippleAccountInfoResponse> GetAccountInfoAsync(RippleGetAccountInfoRequest request, CancellationToken cancellationToken = default);
	/// <summary>Estimates fee.</summary>
	Task<RippleEstimateFeeResponse> EstimateFeeAsync(RippleEstimateFeeRequest request, CancellationToken cancellationToken = default);
	/// <summary>Transfers native assets.</summary>
	Task<RippleTransactionResponse> TransferAsync(RippleTransferRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets transaction status.</summary>
	Task<RippleTransactionStatusResponse> GetTransactionStatusAsync(RippleGetTransactionStatusRequest request, CancellationToken cancellationToken = default);
}



/// <summary>Provides Solana APIs.</summary>
public interface ISolanaClient
{
	/// <summary>Gets native balance.</summary>
	Task<SolanaGetNativeBalanceResponse> GetNativeBalanceAsync(SolanaGetNativeBalanceRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets account information.</summary>
	Task<SolanaAccountInfoResponse> GetAccountInfoAsync(SolanaGetAccountInfoRequest request, CancellationToken cancellationToken = default);
	/// <summary>Transfers native assets.</summary>
	Task<SolanaTransactionResponse> NativeTransferAsync(SolanaNativeTransferRequest request, CancellationToken cancellationToken = default);
	/// <summary>Estimates fee.</summary>
	Task<SolanaEstimateFeeResponse> EstimateFeeAsync(SolanaEstimateFeeRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets transaction status.</summary>
	Task<SolanaTransactionStatusResponse> GetTransactionStatusAsync(SolanaGetTransactionStatusRequest request, CancellationToken cancellationToken = default);
}



/// <summary>Provides Stellar APIs.</summary>
public interface IStellarClient
{
	/// <summary>Gets native balance.</summary>
	Task<StellarGetNativeBalanceResponse> GetNativeBalanceAsync(StellarGetNativeBalanceRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets account information.</summary>
	Task<StellarAccountInfoResponse> GetAccountInfoAsync(StellarGetAccountInfoRequest request, CancellationToken cancellationToken = default);
	/// <summary>Transfers native assets.</summary>
	Task<StellarTransactionResponse> NativeTransferAsync(StellarNativeTransferRequest request, CancellationToken cancellationToken = default);
	/// <summary>Estimates fee.</summary>
	Task<StellarEstimateFeeResponse> EstimateFeeAsync(StellarEstimateFeeRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets transaction status.</summary>
	Task<StellarTransactionStatusResponse> GetTransactionStatusAsync(StellarGetTransactionStatusRequest request, CancellationToken cancellationToken = default);
}



/// <summary>Provides Sui APIs.</summary>
public interface ISuiClient
{
	/// <summary>Gets native balance.</summary>
	Task<SuiGetNativeBalanceResponse> GetNativeBalanceAsync(SuiGetNativeBalanceRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets account information.</summary>
	Task<SuiAccountInfoResponse> GetAccountInfoAsync(SuiGetAccountInfoRequest request, CancellationToken cancellationToken = default);
	/// <summary>Transfers native assets.</summary>
	Task<SuiTransactionResponse> NativeTransferAsync(SuiNativeTransferRequest request, CancellationToken cancellationToken = default);
	/// <summary>Estimates fee.</summary>
	Task<SuiEstimateFeeResponse> EstimateFeeAsync(SuiEstimateFeeRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets transaction status.</summary>
	Task<SuiTransactionStatusResponse> GetTransactionStatusAsync(SuiGetTransactionStatusRequest request, CancellationToken cancellationToken = default);
}



/// <summary>Provides TON APIs.</summary>
public interface ITonClient
{
	/// <summary>Gets native balance.</summary>
	Task<TonGetNativeBalanceResponse> GetNativeBalanceAsync(TonGetNativeBalanceRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets account information.</summary>
	Task<TonAccountInfoResponse> GetAccountInfoAsync(TonGetAccountInfoRequest request, CancellationToken cancellationToken = default);
	/// <summary>Transfers native assets.</summary>
	Task<TonTransactionResponse> NativeTransferAsync(TonNativeTransferRequest request, CancellationToken cancellationToken = default);
	/// <summary>Estimates fee.</summary>
	Task<TonEstimateFeeResponse> EstimateFeeAsync(TonEstimateFeeRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets transaction status.</summary>
	Task<TonTransactionStatusResponse> GetTransactionStatusAsync(TonGetTransactionStatusRequest request, CancellationToken cancellationToken = default);
}



/// <summary>Provides TRON APIs.</summary>
public interface ITronClient
{
	/// <summary>Gets native balance.</summary>
	Task<TronGetNativeBalanceResponse> GetNativeBalanceAsync(TronGetNativeBalanceRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets account information.</summary>
	Task<TronAccountInfoResponse> GetAccountInfoAsync(TronGetAccountInfoRequest request, CancellationToken cancellationToken = default);
	/// <summary>Transfers native assets.</summary>
	Task<TronTransactionResponse> NativeTransferAsync(TronNativeTransferRequest request, CancellationToken cancellationToken = default);
	/// <summary>Estimates fee.</summary>
	Task<TronEstimateFeeResponse> EstimateFeeAsync(TronEstimateFeeRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets transaction status.</summary>
	Task<TronTransactionStatusResponse> GetTransactionStatusAsync(TronGetTransactionStatusRequest request, CancellationToken cancellationToken = default);
}


