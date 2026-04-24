# Polareum.Waas.Sdk

`Polareum.Waas.Sdk` is the .NET client library for Polareum WAAS Server. It exposes a typed C# API that follows the server API path structure, so code can call wallets, admin, network, EVM, UTXO, and supported blockchain endpoints without manually building HTTP requests.

## Installation

```bash
dotnet add package Polareum.Waas.Sdk
```

## Basic Usage

```csharp
using Polareum.Waas.Sdk;

var client = new WaasClient(
	url: "https://waas.example.com",
	apiKey: "your-api-key");

var cancellationToken = CancellationToken.None;

var wallets = await client.Wallets.ListAsync(
	new OwnerWalletSearchModel(
		Page: 1,
		PageSize: 20,
		Name: null,
		PartialName: null,
		OrderBy: null),
	cancellationToken);

var wallet = await client.Wallets.Generate.RandomKeyWalletAsync(
	new GenerateRandomKeyWalletRequest(
		Name: "main-wallet",
		Exportable: false),
	cancellationToken);
```

## API Groups

The root client is organized by WAAS API path:

```csharp
client.Admin.Wallets
client.Admin.Networks
client.Wallets
client.Wallets.Generate
client.Wallets.Import
client.Networks
client.Evm
client.Evm.Erc20
client.Evm.Erc721
client.Evm.Erc1155
client.Evm.Burnable
client.Evm.Pausable
client.Utxo
client.Cardano
client.Near
client.Polkadot
client.Ripple
client.Solana
client.Stellar
client.Sui
client.Ton
client.Tron
```

## Admin Examples

```csharp
var adminWallets = await client.Admin.Wallets.ListAsync(
	new AdminWalletSearchModel(
		Page: 1,
		PageSize: 50,
		ApiKeyId: null,
		Name: null,
		PartialName: null,
		OrderBy: null),
	cancellationToken);

var networks = await client.Admin.Networks.ListAsync(
	new BlockchainNetworkSearchModel(
		Page: 1,
		PageSize: 50,
		Name: null,
		PartialName: null,
		BlockchainTypes: null,
		OrderBy: null),
	cancellationToken);
```

## Wallet Examples

```csharp
var importedWallet = await client.Wallets.Import.PrivateKeyAsync(
	new ImportWalletByPrivateKeyRequest(
		Name: "imported-wallet",
		PrivateKeyHex: "0x...",
		ChainCodeHex: null,
		Exportable: false),
	cancellationToken);

var address = await client.Wallets.GetOrGenerateAddressAsync(
	new GetOrGenerateAddressForBlockchainByOwnerRequest(
		WalletReference: "main-wallet",
		NetworkReference: "ethereum-mainnet",
		StoreAddress: true),
	cancellationToken);

var exported = await client.Wallets.ExportAsync(
	walletReference: "main-wallet",
	cancellationToken);
```

## EVM Examples

```csharp
var nativeBalance = await client.Evm.GetBalanceOfAsync(
	new EvmGetNativeBalanceRequest(
		NetworkReference: "ethereum-mainnet",
		Address: "0x1234..."),
	cancellationToken);

var transfer = await client.Evm.TransferAsync(
	new EvmNativeTransferRequest(
		NetworkReference: "ethereum-mainnet",
		From: "main-wallet",
		ToAddress: "0xabcd...",
		Amount: 0.1m,
		Nonce: null,
		GasPolicy: null),
	cancellationToken);

var erc20Balance = await client.Evm.Erc20.GetBalanceOfAsync(
	new Erc20BalanceOfRequest(
		NetworkReference: "ethereum-mainnet",
		TokenAddress: "0xtoken...",
		Address: "0x1234..."),
	cancellationToken);
```

## UTXO Example

```csharp
var utxoBalance = await client.Utxo.GetBalanceOfAsync(
	new UtxoGetNativeBalanceRequest(
		NetworkReference: "bitcoin-mainnet",
		Address: "bc1..."),
	cancellationToken);

var tx = await client.Utxo.TransferAsync(
	new UtxoNativeTransferSimpleRequest(
		NetworkReference: "bitcoin-mainnet",
		From: "main-wallet",
		ToAddress: "bc1receiver...",
		Amount: 0.001m,
		FeePolicy: null,
		ChangeAddress: null),
	cancellationToken);
```

## Notes

- `WaasClient` implements `IDisposable`; dispose it when the application no longer needs it.
- References such as `WalletReference`, `PublicWalletReference`, `NetworkReference`, and `BlockchainAddress` can be created directly from strings.
- Amounts use `BlockchainAmount`, which can be created from `decimal` values. 1 means 1 bitcoin, 1 ether, ...
