# Quantum Simulation

This project was going to just try and simulate a quantum computer for a limited number of qubits.

However, having learnt* the basics of Quantum computing in terms of complex numbers, tensor products and unitary
matrices, it seems like trying to provide a way to write quantum algorithms with these traditional constructs
might be confusing...

So I'm looking for a way to express Quantum algorithms more intuitively.
<br><sub>*Something anyway!!</sub>

Throughout this README please forgive me for my haphazard method of showing equations in Markdown!

## The Maths of simulating a Quantum Computer

I believe the executive summary of simulating a quantum computer is this.

### Representing a Qubit

A single qubit can be represented as <sub><sub>![Complex numbers squared](LatexImages/QubitDefinition.gif)</sub></sub>, where 
![Complex numbers](LatexImages/ComplexNumbers.gif) is the set of all complex numbers. However, there is a restriction:

![Total Probability must be one](LatexImages/TotalProbabilityLaw.gif)

Where <sub><sub>![Conjugate Transpose](LatexImages/ConjugateTranspose.gif)</sub></sub> is the conjugate transpose. Why does this restriction
exist? It corresponds to the **sum of the probability** of the qubit being measured in each state with respect
to a basis. Since it must be in one state after measurement, the probabilities should sum to one.

Measurement usually corresponds to getting some classical<sup>1</sup> bit from a qubit. That is, looking at the qubit and
deciding if it is 0 or 1. But a qubit can be in a **superposition** between the states 0 and 1, or in other words
somewhere inbetween 0 and 1.

In our space for a qubit ![Complex Squared](LatexImages/ComplexSquared.gif), we define the **computational basis** vectors
as <sub><sub><sub><sub><sub>![Ket Zero](LatexImages/KetZero.gif)</sub></sub></sub></sub></sub> and
<sub><sub><sub><sub><sub>![Ket One](LatexImages/KetOne.gif)</sub></sub></sub></sub></sub>.<sup>2</sup>
These correspond to the classical bits 0 and 1. Since these are basis vectors, any other vector in ![Complex Squared](LatexImages/ComplexSquared.gif)
can be written as a linear combination of these vectors, so:

<sub><sub><sub>![Computational Basis Decomposition](LatexImages/ComputationalBasisDecomposition.gif)</sub></sub></sub>
with <sub><sub>![Alpha Beta Complex](LatexImages/AlphaBetaComplex.gif)</sub></sub>

Our previous restriction on our qubit requires that
<sub><sub><sub>![Component Amplitudes sum to one](LatexImages/ComputationalBasisRestriction.gif)</sub></sub></sub>.
As you might guess, these correspond to probabilities!

* ![Alpha squared magnitude](LatexImages/AlphaSquared.gif) is the probability the qubit is 0 when measured.
* ![Beta squared magnitude](LatexImages/BetaSquared.gif) is the probability the qubit is 1 when measured.

Something odd happens after measurement; the qubit actually **becomes the state measured**! If you measured it again,
it would still be in the same state with 100% probability. The superposition is lost or in technical jargon,
the **wave function collapsed**. This is a problem, as it means you can only look at your qubit once in some sense
before having to start the algorithm again.

<sup>1</sup>Classical throughout this document just refers to the computers we use today - normal computers.<br>
<sup>2</sup>The angular brackets is called Dirac or Bra-Ket notation.

### Representing lots of Qubits


## What is a Quantum Algorithm

In looking into this

## Resources

Some useful resources I found while learning about Quantum Computing:
* https://en.wikipedia.org/wiki/Qubit
* https://www.quantiki.org/wiki/basic-concepts-quantum-computation