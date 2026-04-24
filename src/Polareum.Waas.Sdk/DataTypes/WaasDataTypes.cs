using System.Globalization;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Polareum.Waas.Sdk;

/// <summary>
/// Identifies a blockchain family or a concrete UTXO network supported by WAAS.
/// </summary>
[Flags]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BlockchainType
{
	/// <summary>No blockchain type.</summary>
	None = 0,
	/// <summary>EVM-compatible blockchain type.</summary>
	Evm = 1 << 0,
	/// <summary>UTXO blockchain type.</summary>
	Utxo = 1 << 1,
	/// <summary>Solana blockchain type.</summary>
	Solana = 1 << 2,
	/// <summary>Cardano blockchain type.</summary>
	Cardano = 1 << 3,
	/// <summary>Polkadot blockchain type.</summary>
	Polkadot = 1 << 4,
	/// <summary>NEAR blockchain type.</summary>
	Near = 1 << 5,
	/// <summary>Stellar blockchain type.</summary>
	Stellar = 1 << 6,
	/// <summary>TON blockchain type.</summary>
	Ton = 1 << 7,
	/// <summary>Ripple blockchain type.</summary>
	Ripple = 1 << 16,
	/// <summary>Sui blockchain type.</summary>
	Sui = 1 << 17,
	/// <summary>TRON blockchain type.</summary>
	Tron = 1 << 18,
	/// <summary>Bitcoin mainnet UTXO network.</summary>
	UtxoBitcoinMainnet = Utxo | (1 << 8),
	/// <summary>Bitcoin testnet UTXO network.</summary>
	UtxoBitcoinTestnet = Utxo | (1 << 9),
	/// <summary>Litecoin mainnet UTXO network.</summary>
	UtxoLitecoinMainnet = Utxo | (1 << 10),
	/// <summary>Litecoin testnet UTXO network.</summary>
	UtxoLitecoinTestnet = Utxo | (1 << 11),
	/// <summary>Bitcoin Cash mainnet UTXO network.</summary>
	UtxoBitcoinCashMainnet = Utxo | (1 << 12),
	/// <summary>Bitcoin Cash testnet UTXO network.</summary>
	UtxoBitcoinCashTestnet = Utxo | (1 << 13),
	/// <summary>Dogecoin mainnet UTXO network.</summary>
	UtxoDogecoinMainnet = Utxo | (1 << 14),
	/// <summary>Dogecoin testnet UTXO network.</summary>
	UtxoDogecoinTestnet = Utxo | (1 << 15),
}

/// <summary>
/// Represents a WAAS network reference by id or name.
/// </summary>
[JsonConverter(typeof(StringValueJsonConverter<NetworkReference>))]
public sealed class NetworkReference(string value)
{
	/// <summary>Returns the network reference string.</summary>
	public override string ToString() => value;

	/// <summary>Creates a network reference from a string.</summary>
	public static implicit operator NetworkReference(string value) => new(value);
}

/// <summary>
/// Represents a private wallet reference by id, name, or generated address.
/// </summary>
[JsonConverter(typeof(StringValueJsonConverter<WalletReference>))]
public sealed class WalletReference(string value)
{
	/// <summary>Returns the wallet reference string.</summary>
	public override string ToString() => value;

	/// <summary>Creates a wallet reference from a string.</summary>
	public static implicit operator WalletReference(string value) => new(value);
}

/// <summary>
/// Represents a public wallet reference by id, name, or address.
/// </summary>
[JsonConverter(typeof(StringValueJsonConverter<PublicWalletReference>))]
public sealed class PublicWalletReference(string value)
{
	/// <summary>Returns the public wallet reference string.</summary>
	public override string ToString() => value;

	/// <summary>Creates a public wallet reference from a string.</summary>
	public static implicit operator PublicWalletReference(string value) => new(value);
}

/// <summary>
/// Represents a blockchain address.
/// </summary>
[JsonConverter(typeof(StringValueJsonConverter<BlockchainAddress>))]
public sealed class BlockchainAddress(string value)
{
	/// <summary>Gets the address value.</summary>
	public string Value { get; } = value;

	/// <summary>Returns the address string.</summary>
	public override string ToString() => Value;

	/// <summary>Creates a blockchain address from a string.</summary>
	public static implicit operator BlockchainAddress(string value) => new(value);
}

/// <summary>
/// Represents an amount in native coin units.
/// </summary>
[JsonConverter(typeof(BlockchainAmountJsonConverter))]
public sealed class BlockchainAmount(decimal value)
{
	/// <summary>Gets the amount value in native coin units.</summary>
	public decimal Value { get; } = value;

	/// <summary>Returns the amount using invariant culture.</summary>
	public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

	/// <summary>Creates a blockchain amount from a decimal value.</summary>
	public static implicit operator BlockchainAmount(decimal value) => new(value);
}

internal sealed class StringValueJsonConverter<T> : JsonConverter<T> where T : class
{
	public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var value = reader.GetString() ?? throw new JsonException($"Cannot read {typeToConvert.Name} from null.");
		return (T)Activator.CreateInstance(typeToConvert, value)!;
	}

	public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
		=> writer.WriteStringValue(value.ToString());
}

internal sealed class BlockchainAmountJsonConverter : JsonConverter<BlockchainAmount>
{
	public override BlockchainAmount Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		=> reader.TokenType switch
		{
			JsonTokenType.Number => new BlockchainAmount(reader.GetDecimal()),
			JsonTokenType.String => new BlockchainAmount(decimal.Parse(reader.GetString()!, CultureInfo.InvariantCulture)),
			_ => throw new JsonException($"Cannot read {nameof(BlockchainAmount)} from {reader.TokenType}."),
		};

	public override void Write(Utf8JsonWriter writer, BlockchainAmount value, JsonSerializerOptions options)
		=> writer.WriteNumberValue(value.Value);
}

/// <summary>
/// Converts <see cref="BigInteger"/> values to and from JSON strings.
/// </summary>
internal sealed class BigIntegerJsonConverter : JsonConverter<BigInteger>
{
	public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		=> reader.TokenType switch
		{
			JsonTokenType.Number => BigInteger.Parse(reader.GetDecimal().ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture),
			JsonTokenType.String => BigInteger.Parse(reader.GetString()!, CultureInfo.InvariantCulture),
			_ => throw new JsonException($"Cannot read {nameof(BigInteger)} from {reader.TokenType}."),
		};

	public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
		=> writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
}
