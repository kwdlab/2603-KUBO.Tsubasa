# 2603-KUBO.Tsubasa
2026年3月卒業  久保翼
# Profiling ML-KEM Implementation in C#

## Overview
This repository contains the results of an undergraduate research project that analyzes  
**computational bottlenecks in a C# implementation of ML-KEM (Module-Lattice-Based Key-Encapsulation Mechanism)**.

The study focuses on profiling the **Key Generation, Encapsulation, and Decapsulation** phases  
of ML-KEM as implemented in the Bouncy Castle cryptographic library, using the Visual Studio profiler.

The goal of this project is not to optimize the implementation directly, but to **identify dominant
operations at the function level** and derive practical optimization guidelines for software
implementations of post-quantum cryptography.

---

## Description
With the advancement of quantum computing, traditional public-key cryptosystems such as RSA and ECC
are expected to become insecure. As a result, **Post-Quantum Cryptography (PQC)** has attracted
significant attention, and ML-KEM (formerly Kyber) has been standardized by NIST as a next-generation
key encapsulation mechanism.

While theoretical complexity analyses of ML-KEM are well studied, actual performance characteristics
depend heavily on software implementations and runtime environments.
In this research, we perform a **profiling-based performance analysis** of ML-KEM implemented in C#.

Key features of this study include:
- Function-level profiling using **Self CPU Time**
- Separate analysis of **Key Generation, Encapsulation, and Decapsulation**
- Identification of the relative impact of **NTT, polynomial arithmetic, and Keccak-based hash functions**
- Repeated execution (100,000 iterations) to stabilize profiling results

---

## Requirements
- OS: Windows 10 / 11
- IDE: **Visual Studio 2026**
- .NET: .NET 6.0 or later (recommended)
- CPU: x86-64 architecture  
  (Measurements were conducted on Intel Core i5-10210U)

### Libraries
- **BouncyCastle.Cryptography 2.6.2**
  - Distributed via NuGet as a precompiled library
  - https://www.bouncycastle.org/

---

## Install / Usage

### Installation
1. Clone this repository:
   ```bash
   git clone https://github.com/your-username/ml-kem-profiling.git


