# 2603-KUBO.Tsubasa
2026年3月卒業  久保翼
# Overview
This repository contains the results of an undergraduate research project that analyzes computational bottlenecks in a C# implementation of ML-KEM (Module-Lattice-Based Key-Encapsulation Mechanism).
 
The study focuses on profiling the Key Generation, Encapsulation, and Decapsulation phases  of ML-KEM as implemented in the Bouncy Castle cryptographic library, using the Visual Studio profiler.

The goal of this project is not to optimize the implementation directly, but to identify dominant operations at the function level and derive practical optimization guidelines for software implementations of post-quantum cryptography.
# Description
With the advancement of quantum computing, traditional public-key cryptosystems such as RSA and ECC are expected to become insecure. As a result, Post-Quantum Cryptography (PQC) has attracted significant attention, and ML-KEM has been standardized by NIST as a next-generation key encapsulation mechanism.

While theoretical complexity analyses of ML-KEM are well studied, actual performance characteristics depend heavily on software implementations and runtime environments.
In this research, we perform a profiling-based performance analysis of ML-KEM implemented in C#.

Key features of this study include:
- Separate analysis of Key Generation, Encapsulation, and Decapsulation
- Identification of the relative impact of NTT, polynomial arithmetic, and Keccak-based hash functions
- Repeated execution (100,000 iterations) to stabilize profiling results

