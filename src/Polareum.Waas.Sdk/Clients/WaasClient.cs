using Polareum.Waas.Sdk.Clients;
using Polareum.Waas.Sdk.Internals;

namespace Polareum.Waas.Sdk;

/// <summary>
/// Provides the root entry point for calling WAAS Server APIs.
/// </summary>
public interface IWaasClient
{
	/// <summary>Gets administrative WAAS APIs.</summary>
	IWaasAdminClient Admin { get; }
	/// <summary>Gets wallet APIs for the current API key owner.</summary>
	IWaasWalletsClient Wallets { get; }
	/// <summary>Gets blockchain network APIs for the current API key owner.</summary>
	IWaasNetworksClient Networks { get; }
	/// <summary>Gets EVM APIs.</summary>
	IEvmClient Evm { get; }
	/// <summary>Gets UTXO APIs.</summary>
	IUtxoClient Utxo { get; }
	/// <summary>Gets Cardano APIs.</summary>
	ICardanoClient Cardano { get; }
	/// <summary>Gets NEAR APIs.</summary>
	INearClient Near { get; }
	/// <summary>Gets Polkadot APIs.</summary>
	IPolkadotClient Polkadot { get; }
	/// <summary>Gets Ripple APIs.</summary>
	IRippleClient Ripple { get; }
	/// <summary>Gets Solana APIs.</summary>
	ISolanaClient Solana { get; }
	/// <summary>Gets Stellar APIs.</summary>
	IStellarClient Stellar { get; }
	/// <summary>Gets Sui APIs.</summary>
	ISuiClient Sui { get; }
	/// <summary>Gets TON APIs.</summary>
	ITonClient Ton { get; }
	/// <summary>Gets TRON APIs.</summary>
	ITronClient Tron { get; }
}

/// <summary>
/// Concrete WAAS client that authenticates requests with an API key.
/// </summary>
public sealed class WaasClient : IWaasClient
{
	private readonly WaasRequestExecutor executor;

	/// <summary>
	/// Creates a WAAS client for the given server URL and API key.
	/// </summary>
	public WaasClient(IRestBuilder restBuilder, WaasClientOptions options)
	{
		executor = new WaasRequestExecutor(restBuilder, options);
		Admin = new WaasAdminClient(executor);
		Wallets = new WaasWalletsClient(executor);
		Networks = new WaasNetworksClient(executor);
		Evm = new EvmClient(executor);
		Utxo = new UtxoClient(executor);
		Cardano = new CardanoClient(executor);
		Near = new NearClient(executor);
		Polkadot = new PolkadotClient(executor);
		Ripple = new RippleClient(executor);
		Solana = new SolanaClient(executor);
		Stellar = new StellarClient(executor);
		Sui = new SuiClient(executor);
		Ton = new TonClient(executor);
		Tron = new TronClient(executor);
	}

	/// <inheritdoc />
	public IWaasAdminClient Admin { get; }
	/// <inheritdoc />
	public IWaasWalletsClient Wallets { get; }
	/// <inheritdoc />
	public IWaasNetworksClient Networks { get; }
	/// <inheritdoc />
	public IEvmClient Evm { get; }
	/// <inheritdoc />
	public IUtxoClient Utxo { get; }
	/// <inheritdoc />
	public ICardanoClient Cardano { get; }
	/// <inheritdoc />
	public INearClient Near { get; }
	/// <inheritdoc />
	public IPolkadotClient Polkadot { get; }
	/// <inheritdoc />
	public IRippleClient Ripple { get; }
	/// <inheritdoc />
	public ISolanaClient Solana { get; }
	/// <inheritdoc />
	public IStellarClient Stellar { get; }
	/// <inheritdoc />
	public ISuiClient Sui { get; }
	/// <inheritdoc />
	public ITonClient Ton { get; }
	/// <inheritdoc />
	public ITronClient Tron { get; }
}

/// <summary>
/// Provides administrative WAAS APIs.
/// </summary>
public interface IWaasAdminClient
{
	/// <summary>Gets administrative wallet APIs.</summary>
	IAdminWalletsClient Wallets { get; }
	/// <summary>Gets administrative blockchain network APIs.</summary>
	IAdminNetworksClient Networks { get; }
}

internal sealed class WaasAdminClient(WaasRequestExecutor executor) : IWaasAdminClient
{
	public IAdminWalletsClient Wallets { get; } = new AdminWalletsClient(executor);
	public IAdminNetworksClient Networks { get; } = new AdminNetworksClient(executor);
}

/// <summary>
/// Provides administrative wallet APIs.
/// </summary>
public interface IAdminWalletsClient
{
	/// <summary>Lists all wallets.</summary>
	Task<PagedResult<WalletListItemDto>> ListAsync(AdminWalletSearchModel searchModel, CancellationToken cancellationToken = default);
	/// <summary>Deletes a wallet by id.</summary>
	Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

internal sealed class AdminWalletsClient(WaasRequestExecutor executor) : IAdminWalletsClient
{
	public Task<PagedResult<WalletListItemDto>> ListAsync(AdminWalletSearchModel searchModel, CancellationToken cancellationToken = default)
		=> executor.GetAsync<PagedResult<WalletListItemDto>>("api/admin/wallets", searchModel, cancellationToken);

	public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
		=> executor.DeleteAsync("api/admin/wallets", new { id }, cancellationToken);
}

/// <summary>
/// Provides administrative blockchain network APIs.
/// </summary>
public interface IAdminNetworksClient
{
	/// <summary>Lists blockchain networks.</summary>
	Task<PagedResult<BlockchainNetworkListItemForAdminDto>> ListAsync(BlockchainNetworkSearchModel searchModel, CancellationToken cancellationToken = default);
	/// <summary>Adds a blockchain network.</summary>
	Task<BlockchainNetworkForAdminDto> AddAsync(AddBlockchainNetworkRequest request, CancellationToken cancellationToken = default);
	/// <summary>Updates a blockchain network.</summary>
	Task UpdateAsync(NetworkReference reference, UpdateBlockchainNetworkRequest request, CancellationToken cancellationToken = default);
	/// <summary>Deletes a blockchain network.</summary>
	Task DeleteAsync(NetworkReference reference, CancellationToken cancellationToken = default);
	/// <summary>Finds a blockchain network by reference.</summary>
	Task<BlockchainNetworkForAdminDto> FindAsync(NetworkReference reference, CancellationToken cancellationToken = default);
}

internal sealed class AdminNetworksClient(WaasRequestExecutor executor) : IAdminNetworksClient
{
	public Task<PagedResult<BlockchainNetworkListItemForAdminDto>> ListAsync(BlockchainNetworkSearchModel searchModel, CancellationToken cancellationToken = default)
		=> executor.GetAsync<PagedResult<BlockchainNetworkListItemForAdminDto>>("api/admin/networks", searchModel, cancellationToken);
	public Task<BlockchainNetworkForAdminDto> AddAsync(AddBlockchainNetworkRequest request, CancellationToken cancellationToken = default)
		=> executor.PutAsync<BlockchainNetworkForAdminDto>("api/admin/networks", request, cancellationToken);
	public Task UpdateAsync(NetworkReference reference, UpdateBlockchainNetworkRequest request, CancellationToken cancellationToken = default)
		=> executor.PatchAsync("api/admin/networks", new { referemce = reference }, request, cancellationToken);
	public Task DeleteAsync(NetworkReference reference, CancellationToken cancellationToken = default)
		=> executor.DeleteAsync("api/admin/networks", new { reference }, cancellationToken);
	public Task<BlockchainNetworkForAdminDto> FindAsync(NetworkReference reference, CancellationToken cancellationToken = default)
		=> executor.GetAsync<BlockchainNetworkForAdminDto>("api/admin/networks/find", new { reference }, cancellationToken);
}

/// <summary>
/// Provides wallet APIs for the current API key owner.
/// </summary>
public interface IWaasWalletsClient
{
	/// <summary>Gets wallet generation APIs.</summary>
	IWalletGenerateClient Generate { get; }
	/// <summary>Gets wallet import APIs.</summary>
	IWalletImportClient Import { get; }
	/// <summary>Lists owner wallets.</summary>
	Task<PagedResult<WalletListItemDto>> ListAsync(OwnerWalletSearchModel searchModel, CancellationToken cancellationToken = default);
	/// <summary>Deletes an owner wallet by reference.</summary>
	Task DeleteAsync(WalletReference walletReference, CancellationToken cancellationToken = default);
	/// <summary>Lists generated wallet addresses.</summary>
	Task<WalletAddressDto[]> ListAddressesAsync(WalletReference walletReference, CancellationToken cancellationToken = default);
	/// <summary>Gets or generates an address for a blockchain network.</summary>
	Task<WalletAddressDto> GetOrGenerateAddressAsync(GetOrGenerateAddressForBlockchainByOwnerRequest request, CancellationToken cancellationToken = default);
	/// <summary>Exports wallet key material.</summary>
	Task<ExportedWalletDto> ExportAsync(WalletReference walletReference, CancellationToken cancellationToken = default);
}

internal sealed class WaasWalletsClient(WaasRequestExecutor executor) : IWaasWalletsClient
{
	public IWalletGenerateClient Generate { get; } = new WalletGenerateClient(executor);
	public IWalletImportClient Import { get; } = new WalletImportClient(executor);
	public Task<PagedResult<WalletListItemDto>> ListAsync(OwnerWalletSearchModel searchModel, CancellationToken cancellationToken = default)
		=> executor.GetAsync<PagedResult<WalletListItemDto>>("api/wallets", searchModel, cancellationToken);
	public Task DeleteAsync(WalletReference walletReference, CancellationToken cancellationToken = default)
		=> executor.DeleteAsync("api/wallets", new { @ref = walletReference }, cancellationToken);
	public Task<WalletAddressDto[]> ListAddressesAsync(WalletReference walletReference, CancellationToken cancellationToken = default)
		=> executor.GetAsync<WalletAddressDto[]>("api/wallets/addresses", new { @ref = walletReference }, cancellationToken);
	public Task<WalletAddressDto> GetOrGenerateAddressAsync(GetOrGenerateAddressForBlockchainByOwnerRequest request, CancellationToken cancellationToken = default)
		=> executor.GetAsync<WalletAddressDto>("api/wallets/get-address", request, cancellationToken);
	public Task<ExportedWalletDto> ExportAsync(WalletReference walletReference, CancellationToken cancellationToken = default)
		=> executor.GetAsync<ExportedWalletDto>("api/wallets/export", new { @ref = walletReference }, cancellationToken);
}

/// <summary>
/// Provides wallet generation APIs.
/// </summary>
public interface IWalletGenerateClient
{
	/// <summary>Generates a wallet using random key material.</summary>
	Task<WalletDto> RandomKeyWalletAsync(GenerateRandomKeyWalletRequest request, CancellationToken cancellationToken = default);
}

internal sealed class WalletGenerateClient(WaasRequestExecutor executor) : IWalletGenerateClient
{
	public Task<WalletDto> RandomKeyWalletAsync(GenerateRandomKeyWalletRequest request, CancellationToken cancellationToken = default)
		=> executor.PutAsync<WalletDto>("api/wallets/generate/randome-key", request, cancellationToken);
}

/// <summary>
/// Provides wallet import APIs.
/// </summary>
public interface IWalletImportClient
{
	/// <summary>Imports a wallet from mnemonic words.</summary>
	Task<WalletDto> MnemonicsAsync(ImportWalletByMnemonicsRequest request, CancellationToken cancellationToken = default);
	/// <summary>Imports a wallet from a private key.</summary>
	Task<WalletDto> PrivateKeyAsync(ImportWalletByPrivateKeyRequest request, CancellationToken cancellationToken = default);
}

internal sealed class WalletImportClient(WaasRequestExecutor executor) : IWalletImportClient
{
	public Task<WalletDto> MnemonicsAsync(ImportWalletByMnemonicsRequest request, CancellationToken cancellationToken = default)
		=> executor.PutAsync<WalletDto>("api/wallets/import/mnemonics", request, cancellationToken);
	public Task<WalletDto> PrivateKeyAsync(ImportWalletByPrivateKeyRequest request, CancellationToken cancellationToken = default)
		=> executor.PutAsync<WalletDto>("api/wallets/import/private-key", request, cancellationToken);
}

/// <summary>
/// Provides blockchain network APIs for the current API key owner.
/// </summary>
public interface IWaasNetworksClient
{
	/// <summary>Lists blockchain networks.</summary>
	Task<PagedResult<BlockchainNetworkListItemForUsersDto>> ListAsync(BlockchainNetworkSearchModel searchModel, CancellationToken cancellationToken = default);
	/// <summary>Finds a blockchain network by reference.</summary>
	Task<BlockchainNetworkForUsersDto> FindAsync(NetworkReference reference, CancellationToken cancellationToken = default);
}

internal sealed class WaasNetworksClient(WaasRequestExecutor executor) : IWaasNetworksClient
{
	public Task<PagedResult<BlockchainNetworkListItemForUsersDto>> ListAsync(BlockchainNetworkSearchModel searchModel, CancellationToken cancellationToken = default)
		=> executor.GetAsync<PagedResult<BlockchainNetworkListItemForUsersDto>>("api/networks", searchModel, cancellationToken);
	public Task<BlockchainNetworkForUsersDto> FindAsync(NetworkReference reference, CancellationToken cancellationToken = default)
		=> executor.GetAsync<BlockchainNetworkForUsersDto>("api/networks/find", new { reference }, cancellationToken);
}
