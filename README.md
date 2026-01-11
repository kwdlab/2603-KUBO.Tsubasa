# 2603-KUBO.Tsubasa
2026年3月卒業  久保翼

# Profiling ML-KEM Implementation in C#

## Overview
This repository contains an undergraduate research project that analyzes
the performance characteristics of **ML-KEM (Module-Lattice-Based Key Encapsulation Mechanism)**
implemented in C# using the Bouncy Castle library.

The study focuses on profiling **Key Generation, Encapsulation, and Decapsulation**
to identify computational bottlenecks in a software implementation.

---

## Description
ML-KEM is a post-quantum key encapsulation mechanism standardized by NIST.
Although its theoretical cost is often considered to be dominated by NTT,
actual software performance depends on implementation details.

In this research, function-level profiling is performed using Visual Studio
to evaluate the relative cost of NTT, polynomial arithmetic, and
Keccak-based hash functions in a C# implementation.

---

## Requirements
- IDE: Visual Studio 2026
- .NET: .NET 10.0
- C#: C# 14.0

### Libraries
- **BouncyCastle.Cryptography 2.6.2**
  - Distributed via NuGet as a precompiled library
  - https://www.nuget.org/packages/BouncyCastle.Cryptography

---

## Install / Usage

### Installation
1. Clone Bouncy Castle repository:

   ```bash
   git clone https://github.com/bcgit/bc-csharp.git
   ```
2. Open the solution in Visual Studio.
3. Install the Bouncy Castle library via NuGet:

   ```bash
   dotnet add package BouncyCastle.Cryptography
   ```

### Usage

Each ML-KEM phase (**Key Generation, Encapsulation, Decapsulation**) is implemented as a
minimal standalone program designed specifically for profiling.

To reproduce the measurements:

1. Select the target program as the startup project.
2. Launch **Visual Studio Performance Profiler**.
3. Enable **CPU Usage** and focus on **Self CPU** Time.
4. Run the program and analyze the function-level time distribution.

---

## Author
**Tsubasa Kubo**

## References

- NIST,  
  *Module-Lattice-Based Key-Encapsulation Mechanism Standard (FIPS 203)*.  
  https://csrc.nist.gov/pubs/fips/203/final

- Bouncy Castle,  
  *Bouncy Castle Open-Source Cryptographic APIs*.  
  https://www.bouncycastle.org/

## License
MIT License

