using Polareum.Waas.Sdk.Internals;

namespace Polareum.Waas.Sdk;

/// <summary>
/// Provides EVM native and token APIs.
/// </summary>


internal sealed class EvmClient(WaasRequestExecutor executor) : IEvmClient
{
	public IErc20Client Erc20 { get; } = new Erc20Client(executor);
	public IErc721Client Erc721 { get; } = new Erc721Client(executor);
	public IErc1155Client Erc1155 { get; } = new Erc1155Client(executor);
	public IEvmBurnableClient Burnable { get; } = new EvmBurnableClient(executor, "api/evm/burnable");
	public IEvmPausableClient Pausable { get; } = new EvmPausableClient(executor, "api/evm/pausable");
	public Task<EvmGetNativeBalanceResponse> GetBalanceOfAsync(EvmGetNativeBalanceRequest request, CancellationToken cancellationToken = default)
		=> executor.PostAsync<EvmGetNativeBalanceResponse>("api/evm/balance-of", request, null, cancellationToken);
	public Task<EvmTransactionResponse> TransferAsync(EvmNativeTransferRequest request, CancellationToken cancellationToken = default)
		=> executor.PostAsync<EvmTransactionResponse>("api/evm/transfer", null, request, cancellationToken);
	public Task<EvmDeployResponse> DeployAsync(EvmDeployRequest request, CancellationToken cancellationToken = default)
		=> executor.PostAsync<EvmDeployResponse>("api/evm/deploy", null, request, cancellationToken);
}

/// <summary>Provides ERC20 token APIs.</summary>


internal sealed class Erc20Client(WaasRequestExecutor executor) : IErc20Client
{
	private readonly EvmBurnableClient burnable = new(executor, "api/evm/erc20");
	private readonly EvmPausableClient pausable = new(executor, "api/evm/erc20");
	public Task<EvmGetNativeBalanceResponse> GetBalanceOfAsync(Erc20BalanceOfRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<EvmGetNativeBalanceResponse>("api/evm/erc20/balance-of", request, cancellationToken);
	public Task<Erc20AllowanceResponse> AllowanceAsync(Erc20AllowanceRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<Erc20AllowanceResponse>("api/evm/erc20/allowance", request, cancellationToken);
	public Task<EvmTransactionResponse> ApproveAsync(Erc20ApproveRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<EvmTransactionResponse>("api/evm/erc20/approve", null, request, cancellationToken);
	public Task<EvmTransactionResponse> MintAsync(Erc20MintRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<EvmTransactionResponse>("api/evm/erc20/mint", null, request, cancellationToken);
	public Task<Erc20TotalSupplyResponse> GetTotalSupplyAsync(Erc20TotalSupplyRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<Erc20TotalSupplyResponse>("api/evm/erc20/total-supply", request, cancellationToken);
	public Task<EvmTransactionResponse> TransferAsync(Erc20TransferRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<EvmTransactionResponse>("api/evm/erc20/transfer", null, request, cancellationToken);
	public Task<EvmTransactionResponse> TransferFromAsync(Erc20TransferFromRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<EvmTransactionResponse>("api/evm/erc20/transfer-from", null, request, cancellationToken);
	public Task<EvmTransactionResponse> BurnAsync(EvmBurnRequest request, CancellationToken cancellationToken = default) => burnable.BurnAsync(request, cancellationToken);
	public Task<EvmTransactionResponse> PauseAsync(EvmPauseRequest request, CancellationToken cancellationToken = default) => pausable.PauseAsync(request, cancellationToken);
	public Task<EvmTransactionResponse> UnpauseAsync(EvmUnpauseRequest request, CancellationToken cancellationToken = default) => pausable.UnpauseAsync(request, cancellationToken);
}

/// <summary>Provides ERC721 token APIs.</summary>


internal sealed class Erc721Client(WaasRequestExecutor executor) : IErc721Client
{
	private readonly EvmBurnableClient burnable = new(executor, "api/evm/erc721");
	private readonly EvmPausableClient pausable = new(executor, "api/evm/erc721");
	public Task<Erc721BalanceOfResponse> GetBalanceOfAsync(Erc721BalanceOfRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<Erc721BalanceOfResponse>("api/evm/erc721/balance-of", request, cancellationToken);
	public Task<Erc721OwnerOfResponse> GetOwnerOfAsync(Erc721OwnerOfRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<Erc721OwnerOfResponse>("api/evm/erc721/owner-of", request, cancellationToken);
	public Task<EvmTransactionResponse> GetApprovedAsync(Erc721ApproveRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<EvmTransactionResponse>("api/evm/erc721/get-approved", request, cancellationToken);
	public Task<EvmTransactionResponse> TransferFromAsync(Erc721TransferFromRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<EvmTransactionResponse>("api/evm/erc721/transfer-from", null, request, cancellationToken);
	public Task<EvmTransactionResponse> SafeTransferFromAsync(Erc721SafeTransferFromRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<EvmTransactionResponse>("api/evm/erc721/safe-transfer-from", null, request, cancellationToken);
	public Task<EvmTransactionResponse> SafeMintAsync(Erc721SafeMintRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<EvmTransactionResponse>("api/evm/erc721/safe-mint", null, request, cancellationToken);
	public Task<EvmTransactionResponse> BurnAsync(EvmBurnRequest request, CancellationToken cancellationToken = default) => burnable.BurnAsync(request, cancellationToken);
	public Task<EvmTransactionResponse> PauseAsync(EvmPauseRequest request, CancellationToken cancellationToken = default) => pausable.PauseAsync(request, cancellationToken);
	public Task<EvmTransactionResponse> UnpauseAsync(EvmUnpauseRequest request, CancellationToken cancellationToken = default) => pausable.UnpauseAsync(request, cancellationToken);
}

/// <summary>Provides ERC1155 token APIs.</summary>


internal sealed class Erc1155Client(WaasRequestExecutor executor) : IErc1155Client
{
	private readonly EvmBurnableClient burnable = new(executor, "api/evm/erc1155");
	private readonly EvmPausableClient pausable = new(executor, "api/evm/erc1155");
	public Task<Erc1155BalanceOfResponse> GetBalanceOfAsync(Erc1155BalanceOfRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<Erc1155BalanceOfResponse>("api/evm/erc1155/balance-of", request, cancellationToken);
	public Task<Erc1155BalanceOfBatchResponse> GetBalanceOfBatchAsync(Erc1155BalanceOfBatchRequest request, CancellationToken cancellationToken = default) => executor.GetAsync<Erc1155BalanceOfBatchResponse>("api/evm/erc1155/balance-of-batch", request, cancellationToken);
	public Task<EvmTransactionResponse> MintAsync(Erc1155MintRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<EvmTransactionResponse>("api/evm/erc1155/mint", null, request, cancellationToken);
	public Task<EvmTransactionResponse> MintBatchAsync(Erc1155MintBatchRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<EvmTransactionResponse>("api/evm/erc1155/mint-batch", null, request, cancellationToken);
	public Task<EvmTransactionResponse> SafeTransferFromAsync(Erc1155SafeTransferFromRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<EvmTransactionResponse>("api/evm/erc1155/safe-transfer-from", null, request, cancellationToken);
	public Task<EvmTransactionResponse> BatchSafeTransferFromAsync(Erc1155BatchSafeTransferFromRequest request, CancellationToken cancellationToken = default) => executor.PostAsync<EvmTransactionResponse>("api/evm/erc1155/batch-safe-transfer-from", null, request, cancellationToken);
	public Task<EvmTransactionResponse> BurnAsync(EvmBurnRequest request, CancellationToken cancellationToken = default) => burnable.BurnAsync(request, cancellationToken);
	public Task<EvmTransactionResponse> PauseAsync(EvmPauseRequest request, CancellationToken cancellationToken = default) => pausable.PauseAsync(request, cancellationToken);
	public Task<EvmTransactionResponse> UnpauseAsync(EvmUnpauseRequest request, CancellationToken cancellationToken = default) => pausable.UnpauseAsync(request, cancellationToken);
}

/// <summary>Provides shared EVM burnable contract APIs.</summary>


internal sealed class EvmBurnableClient(WaasRequestExecutor executor, string route) : IEvmBurnableClient
{
	public Task<EvmTransactionResponse> BurnAsync(EvmBurnRequest request, CancellationToken cancellationToken = default)
		=> executor.PostAsync<EvmTransactionResponse>($"{route}/burn", null, request, cancellationToken);
}

/// <summary>Provides shared EVM pausable contract APIs.</summary>


internal sealed class EvmPausableClient(WaasRequestExecutor executor, string route) : IEvmPausableClient
{
	public Task<EvmTransactionResponse> PauseAsync(EvmPauseRequest request, CancellationToken cancellationToken = default)
		=> executor.PostAsync<EvmTransactionResponse>($"{route}/pause", null, request, cancellationToken);
	public Task<EvmTransactionResponse> UnpauseAsync(EvmUnpauseRequest request, CancellationToken cancellationToken = default)
		=> executor.PostAsync<EvmTransactionResponse>($"{route}/unpause", null, request, cancellationToken);
}
