using Polareum.Waas.Sdk.Internals;

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

internal sealed class UtxoClient(WaasRequestExecutor executor) : IUtxoClient
{
	public Task<UtxoGetNativeBalanceResponse> GetBalanceOfAsync(UtxoGetNativeBalanceRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<UtxoGetNativeBalanceResponse>("api/utxo/balance-of", request, null, cancellationToken);
	public Task<UtxoListUnspentResponse> ListUnspentAsync(UtxoListUnspentRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<UtxoListUnspentResponse>("api/utxo/list-unspent", request, null, cancellationToken);
	public Task<BlockchainAmount> EstimateFeeAsync(UtxoEstimateFeeRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<BlockchainAmount>("api/utxo/estimate-fee", request, null, cancellationToken);
	public Task<UtxoTransactionResponse> TransferAsync(UtxoNativeTransferSimpleRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<UtxoTransactionResponse>("api/utxo/transfer", null, request, cancellationToken);
	public Task<UtxoNativeTransferSignResponse> SignAsync(UtxoNativeTransferSignRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<UtxoNativeTransferSignResponse>("api/utxo/sign", null, request, cancellationToken);
	public Task<UtxoTransactionResponse> BroadcastAsync(UtxoNativeTransferBroadcastRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<UtxoTransactionResponse>("api/utxo/broadcast", null, request, cancellationToken);
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

internal sealed class CardanoClient(WaasRequestExecutor executor) : ICardanoClient
{
	public Task<CardanoGetNativeBalanceResponse> GetNativeBalanceAsync(CardanoGetNativeBalanceRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<CardanoGetNativeBalanceResponse>("api/cardano/native-balance", request, cancellationToken);
	public Task<CardanoAccountInfoResponse> GetAccountInfoAsync(CardanoGetAccountInfoRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<CardanoAccountInfoResponse>("api/cardano/account-info", request, cancellationToken);
	public Task<CardanoEstimateFeeResponse> EstimateFeeAsync(CardanoEstimateFeeRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<CardanoEstimateFeeResponse>("api/cardano/estimate-fee", null, request, cancellationToken);
	public Task<CardanoTransactionResponse> TransferAsync(CardanoTransferRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<CardanoTransactionResponse>("api/cardano/transfer", null, request, cancellationToken);
	public Task<CardanoTransactionStatusResponse> GetTransactionStatusAsync(CardanoGetTransactionStatusRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<CardanoTransactionStatusResponse>("api/cardano/transaction-status", request, cancellationToken);
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

internal sealed class NearClient(WaasRequestExecutor executor) : INearClient
{
	public Task<NearGetNativeBalanceResponse> GetNativeBalanceAsync(NearGetNativeBalanceRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<NearGetNativeBalanceResponse>("api/near/native-balance", request, cancellationToken);
	public Task<NearAccountInfoResponse> GetAccountInfoAsync(NearGetAccountInfoRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<NearAccountInfoResponse>("api/near/account-info", request, cancellationToken);
	public Task<NearTransactionResponse> NativeTransferAsync(NearNativeTransferRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<NearTransactionResponse>("api/near/native-transfer", null, request, cancellationToken);
	public Task<NearTransactionStatusResponse> GetTransactionStatusAsync(NearGetTransactionStatusRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<NearTransactionStatusResponse>("api/near/transaction-status", request, cancellationToken);
	public Task<NearEstimateFeeResponse> EstimateFeeAsync(NearEstimateFeeRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<NearEstimateFeeResponse>("api/near/estimate-fee", null, request, cancellationToken);
	public Task<NearAccessKeysResponse> GetAccessKeysAsync(NearGetAccessKeysRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<NearAccessKeysResponse>("api/near/access-keys", request, cancellationToken);
	public Task<NearTransactionResponse> CreateAccountAsync(NearCreateAccountRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<NearTransactionResponse>("api/near/create-account", null, request, cancellationToken);
	public Task<NearTransactionResponse> DeleteAccountAsync(NearDeleteAccountRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<NearTransactionResponse>("api/near/delete-account", null, request, cancellationToken);
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

internal sealed class PolkadotClient(WaasRequestExecutor executor) : IPolkadotClient
{
	public Task<PolkadotGetNativeBalanceResponse> GetBalanceOfAsync(PolkadotGetNativeBalanceRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<PolkadotGetNativeBalanceResponse>("api/polkadot/balance-of", request, null, cancellationToken);
	public Task<PolkadotAccountInfoResponse> GetAccountInfoAsync(PolkadotGetAccountInfoRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<PolkadotAccountInfoResponse>("api/polkadot/account-info", request, null, cancellationToken);
	public Task<PolkadotEstimateFeeResponse> EstimateFeeAsync(PolkadotEstimateFeeRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<PolkadotEstimateFeeResponse>("api/polkadot/estimate-fee", null, request, cancellationToken);
	public Task<PolkadotTransactionResponse> TransferAsync(PolkadotTransferRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<PolkadotTransactionResponse>("api/polkadot/transfer", null, request, cancellationToken);
	public Task<PolkadotTransactionStatusResponse> GetTransactionStatusAsync(PolkadotGetTransactionStatusRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<PolkadotTransactionStatusResponse>("api/polkadot/transaction-status", request, null, cancellationToken);
}
