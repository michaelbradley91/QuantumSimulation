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

Multiple qubits are represented as members of the vector space formed by the **tensor product**<sup>1</sup> of vector spaces for individual
qubits.

For example, two qubits together can be represented as <sub><sub>![Complex Tensor Product](LatexImages/TwoQubitSpace.gif)</sub></sub>. The tensor
product here can be computed as the **Kronecker product**<sup>2</sup>, so two qubits can be written as a vector in ![Complex squared squared](LatexImages/ComplexFour.gif).

The computational basis vectors for two qubits are simply:

<sub><sub><sub><sub><sub>![Two qubit basis](LatexImages/TwoQubitBasis.gif)</sub></sub></sub></sub></sub>

If you measured these qubits, you would get `00`, `01`, `10`, or `11` with probabilities corresponding
to the amplitude squared of the components in the vector, so for:

![Two qubit breakdown](LatexImages/TwoQubitBreakdown.gif)

We have that:
* ![Total Probability for two qubits](LatexImages/TotalProbabilityTwoQubits.gif)
* ![Alpha squared magnitude](LatexImages/AlphaSquared.gif) is the probability we measure `00`.
* ![Beta squared magnitude](LatexImages/BetaSquared.gif) is the probability we measure `01`.
* ![Gamma squared magnitude](LatexImages/GammaSquared.gif) is the probability we measure `10`.
* ![Delta squared magnitude](LatexImages/DeltaSquared.gif) is the probability we measure `11`.

This representation extends to `n` qubits as you would expect, but keep in mind the resulting vector space is
![N Qubit Space](LatexImages/NQubitSpace.gif).

<sup>1</sup>Tensors are members of a tensor space which is the tensor product of vector spaces. They are related
to multilinear maps. That might sound scary, but
[this article does a fantastic job of explaining them](https://jeremykun.com/2014/01/17/how-to-conquer-tensorphobia/).<br>
<sup>2</sup>The Kronecker product is a way of calculating the tensor product with traditional matrices (w.r.t a specific basis). Since
tensors can have a rank greater than 2 representing higher dimensions than a matrix, matrices produced via the Kronecker Product
grow exponentially in size! [See this Wikipedia article for details](https://en.wikipedia.org/wiki/Kronecker_product).<br>

## What is a Quantum Algorithm

In looking into this

## Resources

Some useful resources I found while learning about Quantum Computing:
* https://en.wikipedia.org/wiki/Qubit - what is a qubit
* https://www.quantiki.org/wiki/basic-concepts-quantum-computation - basic concepts
* https://jeremykun.com/2014/01/17/how-to-conquer-tensorphobia/ - tensors and tensor products
  * All of Jeremy Kun's articles on quantum computers are a good read too.
* https://en.wikipedia.org/wiki/Kronecker_product - Kronecker product