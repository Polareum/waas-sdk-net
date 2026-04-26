using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Polareum.Waas.Sdk;

/// <summary>
/// Defines gas options for EVM transactions.
/// </summary>
public record GasPolicyDto([property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger? Legacy_GasPriceGwei, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger? Legacy_GasLimit, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger? EIP1599_MaxFeePerGas, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger? EIP1599_MaxPriorityFeePerGas);

/// <summary>
/// Request to get an EVM native balance.
/// </summary>
public record EvmGetNativeBalanceRequest(NetworkReference NetworkReference, PublicWalletReference Address);

/// <summary>
/// Response containing an EVM native balance.
/// </summary>
public record EvmGetNativeBalanceResponse(BlockchainAmount Balance);

/// <summary>
/// Response containing an EVM transaction hash.
/// </summary>
public record EvmTransactionResponse(string TransactionHash);

/// <summary>
/// Request to transfer native EVM assets.
/// </summary>
public record EvmNativeTransferRequest(NetworkReference NetworkReference, WalletReference From, PublicWalletReference ToAddress, BlockchainAmount Amount, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger? Nonce, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to deploy an EVM contract.
/// </summary>
public record EvmDeployRequest(NetworkReference NetworkReference, WalletReference WalletReference, string Bytecode, string AbiJson, JsonElement ConstructorArguments, GasPolicyDto? GasPolicy = null, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger? Nonce = null, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger? ValueWei = null);

/// <summary>
/// Response returned after deploying an EVM contract.
/// </summary>
public record EvmDeployResponse(string TransactionHash, string ContractAddress);

/// <summary>
/// Request to get an ERC20 balance.
/// </summary>
public record Erc20BalanceOfRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, PublicWalletReference Address);

/// <summary>
/// Response containing an ERC20 balance.
/// </summary>
public record Erc20BalanceOfResponse([property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger Balance);

/// <summary>
/// Request to get an ERC20 total supply.
/// </summary>
public record Erc20TotalSupplyRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress);

/// <summary>
/// Response containing an ERC20 total supply.
/// </summary>
public record Erc20TotalSupplyResponse([property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger TotalSupply);

/// <summary>
/// Request to get ERC20 allowance.
/// </summary>
public record Erc20AllowanceRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, PublicWalletReference OwnerAddress, PublicWalletReference SpenderAddress);

/// <summary>
/// Response containing ERC20 allowance.
/// </summary>
public record Erc20AllowanceResponse([property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger Allowance);

/// <summary>
/// Request to approve ERC20 spending.
/// </summary>
public record Erc20ApproveRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference WalletReference, PublicWalletReference SpenderAddress, BlockchainAmount Amount, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to mint ERC20 tokens.
/// </summary>
public record Erc20MintRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference WalletReference, PublicWalletReference ToAddress, BlockchainAmount BlockchainAmount, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to transfer ERC20 tokens.
/// </summary>
public record Erc20TransferRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference FromAddress, PublicWalletReference ToAddress, BlockchainAmount Amount, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to transfer ERC20 tokens using allowance.
/// </summary>
public record Erc20TransferFromRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference Caller, PublicWalletReference FromAddress, PublicWalletReference ToAddress, BlockchainAmount Amount, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to get an ERC721 balance.
/// </summary>
public record Erc721BalanceOfRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, PublicWalletReference Address);

/// <summary>
/// Response containing an ERC721 balance.
/// </summary>
public record Erc721BalanceOfResponse([property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger Balance);

/// <summary>
/// Request to approve an ERC721 token.
/// </summary>
public record Erc721ApproveRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference WalletReference, PublicWalletReference ToAddress, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger TokenId, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to mint an ERC721 token.
/// </summary>
public record Erc721SafeMintRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference WalletReference, PublicWalletReference ToAddress, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger TokenId, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to get the owner of an ERC721 token.
/// </summary>
public record Erc721OwnerOfRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger TokenId);

/// <summary>
/// Response containing the owner of an ERC721 token.
/// </summary>
public record Erc721OwnerOfResponse(BlockchainAddress OwnerAddress);

/// <summary>
/// Request to transfer an ERC721 token.
/// </summary>
public record Erc721TransferFromRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference WalletReference, PublicWalletReference FromAddress, PublicWalletReference ToAddress, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger TokenId, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to safely transfer an ERC721 token.
/// </summary>
public record Erc721SafeTransferFromRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference WalletReference, PublicWalletReference FromAddress, PublicWalletReference ToAddress, string? DataHex, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger TokenId, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to get an ERC1155 balance.
/// </summary>
public record Erc1155BalanceOfRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, PublicWalletReference Account, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger TokenId);

/// <summary>
/// Response containing an ERC1155 balance.
/// </summary>
public record Erc1155BalanceOfResponse([property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger Balance);

/// <summary>
/// Request to get ERC1155 balances in batch.
/// </summary>
public record Erc1155BalanceOfBatchRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, PublicWalletReference[] Accounts, BigInteger[] TokenIds);

/// <summary>
/// Response containing ERC1155 balances in batch.
/// </summary>
public record Erc1155BalanceOfBatchResponse(BigInteger[] Balances);

/// <summary>
/// Request to mint ERC1155 tokens.
/// </summary>
public record Erc1155MintRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference WalletReference, PublicWalletReference Account, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger TokenId, BlockchainAmount Amount, string DataHex, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to mint ERC1155 tokens in batch.
/// </summary>
public record Erc1155MintBatchRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference WalletReference, PublicWalletReference ToAddress, BigInteger[] TokenIds, BlockchainAmount[] Amounts, string DataHex, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to safely transfer ERC1155 tokens.
/// </summary>
public record Erc1155SafeTransferFromRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference WalletReference, PublicWalletReference FromAddress, PublicWalletReference ToAddress, [property: JsonConverter(typeof(BigIntegerJsonConverter))] BigInteger TokenId, BlockchainAmount Amount, string DataHex, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to safely transfer ERC1155 tokens in batch.
/// </summary>
public record Erc1155BatchSafeTransferFromRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference WalletReference, PublicWalletReference FromAddress, PublicWalletReference ToAddress, BigInteger[] TokenIds, BlockchainAmount[] Amounts, string DataHex, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to burn tokens from an EVM contract.
/// </summary>
public record EvmBurnRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference WalletReference, BlockchainAmount BlockchainAmount, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to pause an EVM contract.
/// </summary>
public record EvmPauseRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference WalletReference, GasPolicyDto? GasPolicy);

/// <summary>
/// Request to unpause an EVM contract.
/// </summary>
public record EvmUnpauseRequest(NetworkReference NetworkReference, BlockchainAddress TokenAddress, WalletReference WalletReference, GasPolicyDto? GasPolicy);
