# Newborn DNA

This project simulates DNA sequence operations for a fictional organism, BLOB. It allows users to load, generate, and manipulate DNA sequences through a variety of operations.

## Project Overview

The project consists of a single C# program that performs various DNA sequence operations, including loading DNA from a file or string, generating random DNA, and performing a series of predefined operations on the DNA sequence.

### Features

The program includes the following operations:
1. Load a DNA sequence from a file.
2. Load a DNA sequence from a string.
3. Generate a random DNA sequence for a BLOB.
4. Check DNA gene structure.
5. Check DNA of BLOB organism.
6. Produce complement of a DNA sequence.
7. Determine amino acids.
8. Delete codons starting from a specified codon.
9. Insert codons starting from a specified codon.
10. Find a codon sequence starting from a specified codon.
11. Reverse codons starting from a specified codon.
12. Find the number of genes in a DNA strand.
13. Find the shortest gene in a DNA strand.
14. Find the longest gene in a DNA strand.
15. Find the most repeated nucleotide sequence in a DNA strand.
16. Hydrogen bond statistics for a DNA strand.
17. Simulate BLOB generations using DNA strands.

## Requirements

The project requires .NET Core SDK to compile and run the C# files.

## Usage

1. Clone the repository:

    ```bash
    git clone https://github.com/barissolcay/Newborn-dna.git
    cd Newborn-dna
    ```

2. Compile the C# files:

    ```bash
    dotnet build
    ```

3. Run the program:

    ```bash
    dotnet run
    ```

## Operations

### Loading DNA

The program offers three options to load a DNA sequence:
1. Load from a file.
2. Load from a user-provided string.
3. Generate a random DNA sequence for a BLOB.

### DNA Manipulation

Once the DNA sequence is loaded, the user can perform various operations such as checking gene structure, producing complement sequences, determining amino acids, deleting or inserting codons, finding codon sequences, and more.

### BLOB Simulation

The program can simulate BLOB generations using DNA strands, allowing the user to observe how DNA sequences evolve over generations.

## Output

The program outputs the results of the selected operations, including the manipulated DNA sequences, gene structure checks, and BLOB simulation results.

## Contributing

Feel free to open issues or submit pull requests if you have suggestions for improvements or find any bugs.

## License

MIT License

```markdown
MIT License

Copyright (c) 2025 Baris Solcay

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
