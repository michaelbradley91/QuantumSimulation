# The Deutsch Jozsa Algorithm

The Deutsch Jozsa algorithm is a really simple Quantum algorithm which can do something faster
than any classical computer can today! This page will try to explain the steps
concretely so you can see exactly **how and why it works**.

This document is similar to the [explanation in Wikipedia here](https://en.wikipedia.org/wiki/Deutsch%E2%80%93Jozsa_algorithm).
I will focus more on details which are assumed there, but you may want to read that article instead - whatever works for you!

#### Caution

Please read [the Maths of Simulating a Quantum Computer](TheMathsOfSimulatingAQuantumComputer) if you
are new to Quantum computing. Quantum algorithms are quite Mathematical so you will want to be
comfortable with the basics before proceeding!

## The Problem

We are given a function
<sub><sub><sub><sub>![n bits to 1 bit function](LatexImages/DeutschJozsaFunction.gif)</sub></sub></sub></sub>
which takes an `n` bit number and returns either a `0` or a `1`. We are told that the function is definitely either:

* **Balanced** - the function returns `1` for half of its inputs, and `0` for the other half.
* **Constant** - the function always returns `1` or always returns `0`.

Our goal is to determine if <sub><sub>![f](LatexImages/f.gif)</sub></sub> is balanced or constant in time polynomial in `n`.

With a classical computer, we would need to check just over
<sub>![2^(n-1) + 1](LatexImages/TwoToTheNMinusOnePlusOne.gif)</sub>
inputs in the **absolute worst case**, as all the values could be the same for the first
![2^(n-1)](LatexImages/TwoToTheNMinusOne.gif) values we test even if the function were balanced
<span style="color:blue"><sup>1</sup></span>.

However, a Quantum computer can solve this problem in polynomial time with certainty! This strongly suggests
that Quantum computers are able to solve more problems efficiently than classical computers
<span style="color:blue"><sup>2</sup></span>.

<span style="color:blue"><sup>1</sup></span>By choosing
<sub><sub><sub><sub>![x < {0,1}^n](LatexImages/xInZeroOneToTheN.gif)</sub></sub></sub></sub> at random it is extremely
likely we will identify that <sub><sub>![f](LatexImages/f.gif)</sub></sub> is balanced, and so could guess it is
constant if we do not see different return values quickly. This problem is actually in **Bounded error Probabilistic
Polynomial Time**, or <a href="https://en.wikipedia.org/wiki/BPP_(complexity)">BPP which you can read about here</a>.<br>
<span style="color:blue"><sup>2</sup></span> Quantum computers have not been **proven** to be more powerful
than classical computers in a complexitly class sense. However, most scientists believe this to be the case. In fact,
a proof might be online since I wrote this!

## Building the Quantum Oracle

The Deutsch Jozsa algorithm relies on a "quantum" version of <sub><sub>![f](LatexImages/f.gif)</sub></sub>
called an **Oracle**, which we will refer to as
<sub><sub><sub><sub><sub><sub>![Uf](LatexImages/Uf.gif)</sub></sub></sub></sub></sub></sub>.
Specifically, the Deutsch Jozsa algorithm requires that:

![Deutsch Jozsa Oracle](LatexImages/DeutschJozsaOracle.gif)

Where <sub><sub><sub><sub>![x in {0,1}^n](LatexImages/xInZeroOneToTheN.gif)</sub></sub></sub></sub>
and <sub><sub><sub><sub>![y in {0,1}](LatexImages/yInZeroOne.gif)</sub></sub></sub></sub>
and <sub>![Addition modulo 2](LatexImages/oplus.gif)</sub> addition modulo two.

So <sub><sub><sub><sub><sub><sub>![Uf](LatexImages/Uf.gif)</sub></sub></sub></sub></sub></sub>
leaves all of the first `n` **input qubits** untouched, and sets its **result** in the `n+1` qubit by adding its return
value to it modulo `2`.

#### Why this Oracle specifically?

Many classical functions **avoid modifying their input**, as this can create **unintended side effects**
if the input is reused in a future call, and in our case would seriously complicate the Maths! We are not trying to
minimise the number of qubits required here, so that decides most of the Oracle already:

![Partial Oracle Definition](LatexImages/PartialOracleDefinition.gif)

So how should we set the result? Any Quantum gate needs to be a **Unitary matrix** and so needs to be **reversible**,
so trying to define it like this:

![Bad Oracle Definition](LatexImages/BadOracleDefinition.gif)

Is not possible, since the value of <sub><sub>![y](LatexImages/y.gif)</sub></sub> is ignored.
Two inputs are mapped to the same output, which cannot be reversed, so this is not a valid Quantum gate.

The next simplest definition is to add the result to <sub><sub>![y](LatexImages/y.gif)</sub></sub>
modulo two. This ensures:
* The result **fits in a single qubit**.
* The operation is **reversible**, since the result is uniquely determined by ![x](LatexImages/x.gif) and
<sub><sub>![y](LatexImages/y.gif)</sub></sub>.

We could imagine calling <sub><sub><sub><sub><sub><sub>![Uf](LatexImages/Uf.gif)</sub></sub></sub></sub></sub></sub>
with <sub><sub>![y](LatexImages/y.gif)</sub></sub> set to zero, and so just see the result returned. This
is roughly why this is a good definition for the Oracle, and you may see this sort of definition in other
Quantum algorithms too.

<sub>This may not reflect the thoughts that went through David Deutsch's and Richard Jozsa's minds but I hope it helped
your understanding!</sub>

#### How is the Oracle represented Mathematically?

From the reasoning above, I hope you feel confident a quantum gate exists for
<sub><sub><sub><sub><sub><sub>![Uf](LatexImages/Uf.gif)</sub></sub></sub></sub></sub></sub>,
but what does this gate look like?

We know that for any qubit state <sub><sub>![q](LatexImages/q.gif)</sub></sub> we can write that state
as a linear combination of basis vectors. So, for `n` qubits, we could write a qubit state like this:

![Qubit decomposed](LatexImages/QubitDecomposed.gif)

Where <sub><sub>![Lambda in complex number space](LatexImages/LambdaInComplex.gif)</sub></sub> and
<sub><sub>![Basis states in complex vector space](LatexImages/BasisStatesInComplexSpace.gif)</sub></sub>
for all ![i](LatexImages/i.gif).<span style="color:blue"><sup>1</sup></span> Therefore, when we apply
<sub><sub><sub><sub><sub><sub>![Uf](LatexImages/Uf.gif)</sub></sub></sub></sub></sub></sub> to
<sub><sub>![q](LatexImages/q.gif)</sub></sub> we can write that as follows:

![Oracle applied to decomposed qubit](LatexImages/OracleOnDecomposedQubit.gif)

What this means is that our Oracle's behaviour is completely defined by how it acts on the basis states, or in other
words, agreeing on the value of
<sub><sub><sub><sub><sub><sub>![Oracle applied to basis state](LatexImages/OracleOnSingleBasisState.gif)</sub></sub></sub></sub></sub></sub>
for all ![i](LatexImages/i.gif) **completely and uniquely defines the Oracle**! This is great news, because we know
exactly how we want our Oracle to behave on the basis states.

For example, with `n` equal to two qubits, and <sub><sub>![f](LatexImages/f.gif)</sub></sub> a constant function
that always returns `1`, our Oracle would be:

![Example Oracle](LatexImages/ExampleDeutschJozsaOracle.gif)

I've labelled the rows and columns to correspond to the basis states. For example, the row labelled `000` will act
on the basis state <sub><sub><sub><sub><sub>![|000>](LatexImages/ZeroZeroZero.gif)</sub></sub></sub></sub></sub>,
and set it to the basis state in the column with a `1`, in this case
<sub><sub><sub><sub><sub>![|001>](LatexImages/ZeroZeroOne.gif)</sub></sub></sub></sub></sub>. This is correct,
since we have <sub><sub><sub><sub><sub>![x is |00>](LatexImages/xIsZeroZero.gif)</sub></sub></sub></sub></sub>
and <sub><sub><sub><sub><sub>![y is |0>](LatexImages/yIsZero.gif)</sub></sub></sub></sub></sub> so:

![Example Oracle calculation](LatexImages/ExampleOracleCalculation.gif)

You can verify some other values if you like; they should all work!

In general, any Oracle can be constructed from a classical function
in this way, where each row contains the scalars
<sub><sub>![Lambda in complex number space](LatexImages/LambdaInComplex.gif)</sub></sub>
corresponding to the **basis state decomposition of the result**. In our case,
each result is exactly a single basis state so the rows are very simple.

<span style="color:blue"><sup>1</sup></span>This is specifically for our matrix representation, but we could
also write this in Dirac notation. This law is not specific to matrices or vectors.

## Resources

Some useful resources I found while learning about Quantum Computing:
* https://en.wikipedia.org/wiki/Deutsch%E2%80%93Jozsa_algorithm - Deutsch Jozsa algorithm.
* https://en.wikipedia.org/wiki/BPP_(complexity) - Bounded error Probabilistic Polynomial time or BPP.