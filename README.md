# Steganography and Cryptanalysis Project

This project aims to provide hands-on experience with steganography, cryptanalysis, and random number generators. You'll work with file manipulation at the byte level to hide messages within bitmap images and analyze encryption weaknesses by exploiting random number generation.

## Table of Contents

- [Purpose](#purpose)
- [Objectives](#objectives)
- [Technology Requirements](#technology-requirements)
- [Project Structure](#project-structure)
  - [Part 1 - Steganography](#part-1---steganography)
  - [Part 2 - Cryptanalysis](#part-2---cryptanalysis)

## Purpose

The goal of this project is to apply cryptographic concepts in practical ways, including:
- Understanding and implementing steganography.
- Learning to find weaknesses in random number generation.
- Developing cryptanalysis skills by discovering keys used in encryption through known weaknesses.

## Objectives

The objectives of this project are as follows:
- Apply number theory to solve real-world security problems.
- Utilize algorithms for random number generation, hashing, and encryption.
- Analyze encryption and hash algorithms to identify potential weaknesses and design attacks.

## Technology Requirements

- .NET Core 8.0
- Basic knowledge of C#

## Project Structure

### Part 1 - Steganography

1. **Create a 4x4 Bitmap Image**: Manually construct a 4x4-pixel bitmap image by writing the appropriate bytes.
2. **Hide a Message**: Modify specific color bytes to hide a 12-byte message within the image using XOR.
3. **Verify Changes**: The image should visually remain the same but contain hidden information, simulating steganographic data hiding.

### Part 2 - Cryptanalysis

1. **Analyze PRNG Seed Weakness**: Use a known range of possible seeds based on a timestamp to determine the key used for encryption.
2. **Decrypt Encrypted Messages**: Discover the PRNG seed value used to generate the encryption key by matching known plaintext and ciphertext.

- For **Part 1**, run the program using a 12 byte input like the example below:
  ```
  dotnet run "B1 FF FF CC 98 80 09 EA 04 48 7E C9"
  ```
    - Example Output
  ![](https://github.com/zgiovane/Steganography-Cryptanalysis/blob/main/ExampleOutput/ExampleOutput.png)
  
- For **Part 2**, run the program using a plaintext and ciphertext as command line arguments:
  ```
  dotnet run “Hello World” “RgdIKNgHn2Wg7jXwAykTlA==”
  ```
