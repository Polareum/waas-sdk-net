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



/// <summary>
/// Provides wallet generation APIs.
/// </summary>
public interface IWalletGenerateClient
{
	/// <summary>Generates a wallet using random key material.</summary>
	Task<WalletDto> RandomKeyWalletAsync(GenerateRandomKeyWalletRequest request, CancellationToken cancellationToken = default);
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

