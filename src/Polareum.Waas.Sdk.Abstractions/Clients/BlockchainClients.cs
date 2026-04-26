
namespace Polareum.Waas.Sdk;

/// <summary>Provides UTXO blockchain APIs.</summary>
public interface IUtxoClient
{
	/// <summary>Gets native balance.</summary>
	Task<UtxoGetNativeBalanceResponse> GetBalanceOfAsync(UtxoGetNativeBalanceRequest request, CancellationToken cancellationToken = default);
	/// <summary>Lists unspent outputs.</summary>
	Task<UtxoListUnspentResponse> ListUnspentAsync(UtxoListUnspentRequest request, CancellationToken cancellationToken = default);
	/// <summary>Estimates a fee rate.</summary>
	Task<BlockchainAmount> EstimateFeeAsync(UtxoEstimateFeeRequest request, CancellationToken cancellationToken = default);
	/// <summary>Transfers native assets.</summary>
	Task<UtxoTransactionResponse> TransferAsync(UtxoNativeTransferSimpleRequest request, CancellationToken cancellationToken = default);
	/// <summary>Signs a raw transaction.</summary>
	Task<UtxoNativeTransferSignResponse> SignAsync(UtxoNativeTransferSignRequest request, CancellationToken cancellationToken = default);
	/// <summary>Broadcasts a signed transaction.</summary>
	Task<UtxoTransactionResponse> BroadcastAsync(UtxoNativeTransferBroadcastRequest request, CancellationToken cancellationToken = default);
}



/// <summary>Provides Cardano APIs.</summary>
public interface ICardanoClient
{
	/// <summary>Gets native balance.</summary>
	Task<CardanoGetNativeBalanceResponse> GetNativeBalanceAsync(CardanoGetNativeBalanceRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets account information.</summary>
	Task<CardanoAccountInfoResponse> GetAccountInfoAsync(CardanoGetAccountInfoRequest request, CancellationToken cancellationToken = default);
	/// <summary>Estimates transaction fee.</summary>
	Task<CardanoEstimateFeeResponse> EstimateFeeAsync(CardanoEstimateFeeRequest request, CancellationToken cancellationToken = default);
	/// <summary>Broadcasts a signed transaction.</summary>
	Task<CardanoTransactionResponse> TransferAsync(CardanoTransferRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets transaction status.</summary>
	Task<CardanoTransactionStatusResponse> GetTransactionStatusAsync(CardanoGetTransactionStatusRequest request, CancellationToken cancellationToken = default);
}



/// <summary>Provides NEAR APIs.</summary>
public interface INearClient
{
	/// <summary>Gets native balance.</summary>
	Task<NearGetNativeBalanceResponse> GetNativeBalanceAsync(NearGetNativeBalanceRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets account information.</summary>
	Task<NearAccountInfoResponse> GetAccountInfoAsync(NearGetAccountInfoRequest request, CancellationToken cancellationToken = default);
	/// <summary>Transfers native assets.</summary>
	Task<NearTransactionResponse> NativeTransferAsync(NearNativeTransferRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets transaction status.</summary>
	Task<NearTransactionStatusResponse> GetTransactionStatusAsync(NearGetTransactionStatusRequest request, CancellationToken cancellationToken = default);
	/// <summary>Estimates fee.</summary>
	Task<NearEstimateFeeResponse> EstimateFeeAsync(NearEstimateFeeRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets access keys.</summary>
	Task<NearAccessKeysResponse> GetAccessKeysAsync(NearGetAccessKeysRequest request, CancellationToken cancellationToken = default);
	/// <summary>Creates an account.</summary>
	Task<NearTransactionResponse> CreateAccountAsync(NearCreateAccountRequest request, CancellationToken cancellationToken = default);
	/// <summary>Deletes an account.</summary>
	Task<NearTransactionResponse> DeleteAccountAsync(NearDeleteAccountRequest request, CancellationToken cancellationToken = default);
}



/// <summary>Provides Polkadot APIs.</summary>
public interface IPolkadotClient
{
	/// <summary>Gets native balance.</summary>
	Task<PolkadotGetNativeBalanceResponse> GetBalanceOfAsync(PolkadotGetNativeBalanceRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets account information.</summary>
	Task<PolkadotAccountInfoResponse> GetAccountInfoAsync(PolkadotGetAccountInfoRequest request, CancellationToken cancellationToken = default);
	/// <summary>Estimates fee.</summary>
	Task<PolkadotEstimateFeeResponse> EstimateFeeAsync(PolkadotEstimateFeeRequest request, CancellationToken cancellationToken = default);
	/// <summary>Transfers native assets.</summary>
	Task<PolkadotTransactionResponse> TransferAsync(PolkadotTransferRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets transaction status.</summary>
	Task<PolkadotTransactionStatusResponse> GetTransactionStatusAsync(PolkadotGetTransactionStatusRequest request, CancellationToken cancellationToken = default);
}


