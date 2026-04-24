using Polareum.Waas.Sdk.Internals;

namespace Polareum.Waas.Sdk;

/// <summary>
/// Provides EVM native and token APIs.
/// </summary>
public interface IEvmClient
{
	/// <summary>Gets ERC20 APIs.</summary>
	IErc20Client Erc20 { get; }
	/// <summary>Gets ERC721 APIs.</summary>
	IErc721Client Erc721 { get; }
	/// <summary>Gets ERC1155 APIs.</summary>
	IErc1155Client Erc1155 { get; }
	/// <summary>Gets shared burnable contract APIs.</summary>
	IEvmBurnableClient Burnable { get; }
	/// <summary>Gets shared pausable contract APIs.</summary>
	IEvmPausableClient Pausable { get; }
	/// <summary>Gets a native balance.</summary>
	Task<EvmGetNativeBalanceResponse> GetBalanceOfAsync(EvmGetNativeBalanceRequest request, CancellationToken cancellationToken = default);
	/// <summary>Transfers native EVM assets.</summary>
	Task<EvmTransactionResponse> TransferAsync(EvmNativeTransferRequest request, CancellationToken cancellationToken = default);
	/// <summary>Deploys an EVM contract.</summary>
	Task<EvmDeployResponse> DeployAsync(EvmDeployRequest request, CancellationToken cancellationToken = default);
}

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
public interface IErc20Client : IEvmBurnableClient, IEvmPausableClient
{
	/// <summary>Gets an ERC20 token balance.</summary>
	Task<EvmGetNativeBalanceResponse> GetBalanceOfAsync(Erc20BalanceOfRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets ERC20 allowance.</summary>
	Task<Erc20AllowanceResponse> AllowanceAsync(Erc20AllowanceRequest request, CancellationToken cancellationToken = default);
	/// <summary>Approves ERC20 spending.</summary>
	Task<EvmTransactionResponse> ApproveAsync(Erc20ApproveRequest request, CancellationToken cancellationToken = default);
	/// <summary>Mints ERC20 tokens.</summary>
	Task<EvmTransactionResponse> MintAsync(Erc20MintRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets ERC20 total supply.</summary>
	Task<Erc20TotalSupplyResponse> GetTotalSupplyAsync(Erc20TotalSupplyRequest request, CancellationToken cancellationToken = default);
	/// <summary>Transfers ERC20 tokens.</summary>
	Task<EvmTransactionResponse> TransferAsync(Erc20TransferRequest request, CancellationToken cancellationToken = default);
	/// <summary>Transfers ERC20 tokens using allowance.</summary>
	Task<EvmTransactionResponse> TransferFromAsync(Erc20TransferFromRequest request, CancellationToken cancellationToken = default);
}

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
public interface IErc721Client : IEvmBurnableClient, IEvmPausableClient
{
	/// <summary>Gets an ERC721 balance.</summary>
	Task<Erc721BalanceOfResponse> GetBalanceOfAsync(Erc721BalanceOfRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets the owner of an ERC721 token.</summary>
	Task<Erc721OwnerOfResponse> GetOwnerOfAsync(Erc721OwnerOfRequest request, CancellationToken cancellationToken = default);
	/// <summary>Calls the server's ERC721 get-approved endpoint.</summary>
	Task<EvmTransactionResponse> GetApprovedAsync(Erc721ApproveRequest request, CancellationToken cancellationToken = default);
	/// <summary>Transfers an ERC721 token.</summary>
	Task<EvmTransactionResponse> TransferFromAsync(Erc721TransferFromRequest request, CancellationToken cancellationToken = default);
	/// <summary>Safely transfers an ERC721 token.</summary>
	Task<EvmTransactionResponse> SafeTransferFromAsync(Erc721SafeTransferFromRequest request, CancellationToken cancellationToken = default);
	/// <summary>Safely mints an ERC721 token.</summary>
	Task<EvmTransactionResponse> SafeMintAsync(Erc721SafeMintRequest request, CancellationToken cancellationToken = default);
}

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
public interface IErc1155Client : IEvmBurnableClient, IEvmPausableClient
{
	/// <summary>Gets an ERC1155 balance.</summary>
	Task<Erc1155BalanceOfResponse> GetBalanceOfAsync(Erc1155BalanceOfRequest request, CancellationToken cancellationToken = default);
	/// <summary>Gets ERC1155 balances in batch.</summary>
	Task<Erc1155BalanceOfBatchResponse> GetBalanceOfBatchAsync(Erc1155BalanceOfBatchRequest request, CancellationToken cancellationToken = default);
	/// <summary>Mints ERC1155 tokens.</summary>
	Task<EvmTransactionResponse> MintAsync(Erc1155MintRequest request, CancellationToken cancellationToken = default);
	/// <summary>Mints ERC1155 tokens in batch.</summary>
	Task<EvmTransactionResponse> MintBatchAsync(Erc1155MintBatchRequest request, CancellationToken cancellationToken = default);
	/// <summary>Safely transfers ERC1155 tokens.</summary>
	Task<EvmTransactionResponse> SafeTransferFromAsync(Erc1155SafeTransferFromRequest request, CancellationToken cancellationToken = default);
	/// <summary>Safely transfers ERC1155 tokens in batch.</summary>
	Task<EvmTransactionResponse> BatchSafeTransferFromAsync(Erc1155BatchSafeTransferFromRequest request, CancellationToken cancellationToken = default);
}

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
public interface IEvmBurnableClient
{
	/// <summary>Burns tokens.</summary>
	Task<EvmTransactionResponse> BurnAsync(EvmBurnRequest request, CancellationToken cancellationToken = default);
}

internal sealed class EvmBurnableClient(WaasRequestExecutor executor, string route) : IEvmBurnableClient
{
	public Task<EvmTransactionResponse> BurnAsync(EvmBurnRequest request, CancellationToken cancellationToken = default)
		=> executor.PostAsync<EvmTransactionResponse>($"{route}/burn", null, request, cancellationToken);
}

/// <summary>Provides shared EVM pausable contract APIs.</summary>
public interface IEvmPausableClient
{
	/// <summary>Pauses a contract.</summary>
	Task<EvmTransactionResponse> PauseAsync(EvmPauseRequest request, CancellationToken cancellationToken = default);
	/// <summary>Unpauses a contract.</summary>
	Task<EvmTransactionResponse> UnpauseAsync(EvmUnpauseRequest request, CancellationToken cancellationToken = default);
}

internal sealed class EvmPausableClient(WaasRequestExecutor executor, string route) : IEvmPausableClient
{
	public Task<EvmTransactionResponse> PauseAsync(EvmPauseRequest request, CancellationToken cancellationToken = default)
		=> executor.PostAsync<EvmTransactionResponse>($"{route}/pause", null, request, cancellationToken);
	public Task<EvmTransactionResponse> UnpauseAsync(EvmUnpauseRequest request, CancellationToken cancellationToken = default)
		=> executor.PostAsync<EvmTransactionResponse>($"{route}/unpause", null, request, cancellationToken);
}
