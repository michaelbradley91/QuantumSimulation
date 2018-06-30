# The Deutsch Jozsa Algorithm

The Deutsch Jozsa algorithm is a really simple Quantum algorithm which can do something faster
than any classical computer can today! This page will try to explain the steps
concretely so you can see exactly **how and why it works**.

This document is similar to the [explanation in Wikipedia here](https://en.wikipedia.org/wiki/Deutsch%E2%80%93Jozsa_algorithm).
I will focus more on details which are assumed there, but you may want to read that article instead - whatever works for you!

#### Caution

Please read [the Maths of Simulating a Quantum Computer](TheMathsOfSimulatingAQuantumComputer.md) if you
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
than classical computers in a complexity class sense. However, most scientists believe this to be the case. In fact,
a proof might be online since I wrote this!

## Building the Quantum Oracle

The Deutsch Jozsa algorithm relies on a "quantum" version of <sub><sub>![f](LatexImages/f.gif)</sub></sub>
called an **Oracle**, which we will refer to as
<sub><sub><sub><sub><sub><sub>![Uf](LatexImages/Uf.gif)</sub></sub></sub></sub></sub></sub>.
Specifically, the Deutsch Jozsa algorithm requires that:

![Deutsch Jozsa Oracle](LatexImages/DeutschJozsaOracle.gif)

Where <sub><sub><sub><sub>![x in {0,1}^n](LatexImages/xInZeroOneToTheN.gif)</sub></sub></sub></sub>
and <sub><sub><sub><sub>![y in {0,1}](LatexImages/yInZeroOne.gif)</sub></sub></sub></sub>
and <sub>![Addition modulo 2](LatexImages/oplus.gif)</sub> is addition modulo two.

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

I've labelled the rows and columns to correspond to the basis states. For example, the column labelled `000` will act
on the basis state <sub><sub><sub><sub><sub>![|000>](LatexImages/ZeroZeroZero.gif)</sub></sub></sub></sub></sub>,
and set it to the basis state in the row with a `1`, in this case
<sub><sub><sub><sub><sub>![|001>](LatexImages/ZeroZeroOne.gif)</sub></sub></sub></sub></sub>. This is correct,
since we have <sub><sub><sub><sub><sub>![x is |00>](LatexImages/xIsZeroZero.gif)</sub></sub></sub></sub></sub>
and <sub><sub><sub><sub><sub>![y is |0>](LatexImages/yIsZero.gif)</sub></sub></sub></sub></sub> so:

![Example Oracle calculation](LatexImages/ExampleOracleCalculation.gif)

You can verify some other values if you like; they should all work!

In general, any Oracle can be constructed from a classical function
in this way, where each column contains the scalars
<sub><sub>![Lambda in complex number space](LatexImages/LambdaInComplex.gif)</sub></sub>
corresponding to the **basis state decomposition of the result**. In our case,
each result is exactly a single basis state so the rows are very simple.

<span style="color:blue"><sup>1</sup></span>This is specifically for our matrix representation, but we could
also write this in Dirac notation. This law is not specific to matrices or vectors.

## The Solution

Now we have the quantum Oracle <sub><sub><sub><sub><sub><sub>![Uf](LatexImages/Uf.gif)</sub></sub></sub></sub></sub></sub>,
we can implement the full sequence of quantum gates for the Deutsch Jozse algorithm:

![Deutsch Jozse algorithm](LatexImages/DeutschJozseEquation.gif)

Or as a diagram copied from [Wikipedia](https://en.wikipedia.org/wiki/Deutsch%E2%80%93Jozsa_algorithm):

![Deutsch Jozse diagram](Diagrams/DeutschJozseAlgorithm.png)

Measurement is performed after this in the computational basis:
* If the first `n` qubits are all zero, then <sub><sub>![f](LatexImages/f.gif)</sub></sub> is constant.
* Otherwise, <sub><sub>![f](LatexImages/f.gif)</sub></sub> is balanced.

To understand why this works we need to step through the algorithm.

### Step 1 - Create the Superposition

The algorithm begins with qubits initialised to
<sub><sub><sub><sub><sub><sub>![Initial state](LatexImages/DeutschJozseInitialState.gif)</sub></sub></sub></sub></sub></sub>
. The final qubit is <sub><sub><sub><sub><sub><sub>![One](LatexImages/One.gif)</sub></sub></sub></sub></sub></sub>
because it avoids an extra quantum gate. Of course, it could also be
<sub><sub><sub><sub><sub><sub>![Zero](LatexImages/Zero.gif)</sub></sub></sub></sub></sub></sub> and then we could apply
a `NOT` gate just to that qubit.

We then need to apply ![H^(n+1)](LatexImages/nPlusOneHadamardGates.gif) to this state. The Hadamard gate
turns a <sub><sub><sub><sub><sub><sub>![Zero](LatexImages/Zero.gif)</sub></sub></sub></sub></sub></sub>
or <sub><sub><sub><sub><sub><sub>![One](LatexImages/One.gif)</sub></sub></sub></sub></sub></sub>
qubit into a qubit that has an equal chance of being a `0` or `1` when measured, or specifically:

<img src="LatexImages/HadamardZeroMap.gif" style="vertical-align: middle;"></img>&nbsp;
and &nbsp; <img src="LatexImages/HadamardOneMap.gif" style="vertical-align: middle;"></img>

By doing this, we are preparing to apply
<sub><sub><sub><sub><sub><sub>![Uf](LatexImages/Uf.gif)</sub></sub></sub></sub></sub></sub>
to all possible ![x](LatexImages/x.gif) at once<span style="color:blue"><sup>1</sup></span>.

This gives us the state:

![First step](LatexImages/DeutschJozseFirstStep.gif)

The sum on the right hand side of the equation just says that we have every possible `n` qubit basis
state included, so it relies on this equation:

![Hadamard equation](LatexImages/HadamardEquation.gif)

You can prove this by induction if you like, but just to confirm the intuition, let's check this for two qubits:

![Hadamard equation for two qubits](LatexImages/HadamardEquationTwoQubits.gif)

Above I have omitted <sub>![times](LatexImages/otimes.gif) </sub> for brevity. You will see the tensor product symbol
omitted in many equations in other documents online. Essentially, if two quantum states are next to each other,
just imagine <sub>![otimes](LatexImages/otimes.gif)</sub> between them. It is very much like how we often write multiplication without the multiply symbol, so
<sub>![omit multiply](LatexImages/OmitMultiplication.gif)</sub>.


Now we have the superposition prepared, we are ready to...

<span style="color:blue"><sup>1</sup></span>With a bit of imagination anyway!

### Step 2 - Apply the Oracle

All we do here is apply <sub><sub><sub><sub><sub><sub>z![Uf](LatexImages/Uf.gif)</sub></sub></sub></sub></sub></sub>
to the state we had above and simplify. Remember that:

![Deutsch Jozsa Oracle](LatexImages/DeutschJozsaOracle.gif)

So applying this Quantum gate yields:

![Application of Oracle](LatexImages/DeutschJozseApplyingOracle.gif)

This is a good start, but we'd like to have an equation where all the qubit states are written as
<sub><sub><sub><sub><sub><sub>![Zero](LatexImages/Zero.gif)</sub></sub></sub></sub></sub></sub> or
<sub><sub><sub><sub><sub><sub>![One](LatexImages/One.gif)</sub></sub></sub></sub></sub></sub>. Otherwise,
if we try to apply a gate to <sub><sub><sub><sub><sub><sub>![f(x)](LatexImages/fOfX.gif)</sub></sub></sub></sub></sub></sub>
we will need to consider what happens when the function returns `1` and when it returns `0` which doubles
the size of the equation.

Thankfully, we can simplify this further by considering the two cases right now:

![Difficult Part](LatexImages/DifficultPartOfDeutschJozseAlgorithm.gif)<br>
<sub>If you are struggling to follow line 4, note that many of the terms of each sum are zero.</sub>

Phew! That was the difficult part of the Deutsch Jozse algorithm!

### Step 3 - Prepare for Measurement

If we try to measure in the computational basis right now, we will get a random result since our equation
roughly says any state is possible! Intuitively, this is because we are still in our **superposition
from Step 1**.

We can undo this by reapplying the Hadamard gate since ![Hadamard self inverse](LatexImages/HadamardSelfInverse.gif). You will
see in other explanations that we can ignore the `n+1` qubit, which is true, but to avoid confusion I will apply
the Hadamard gate to this qubit as well. This results in:

![Preparing for measurement](LatexImages/DeutschJozsePrepareForMeasurement.gif)

Where <sub><sub><sub>![Sum of bitwise product](LatexImages/SumOfBitwiseProduct.gif)</sub></sub></sub>
is the sum of the bitwise product (modulo two). To clarify, the above relies on this being true:

![Hadamard equation generalised](LatexImages/HadamardEquationGeneralised.gif)

For every <sub><sub><sub>![x in {0,1}^n](LatexImages/xInZeroOneToTheN.gif)</sub></sub></sub>. This is a generalisation
of the earlier equation for the Hadamard gate where ![x](LatexImages/x.gif) was all zeroes. The only difference
now is that some of the states will have a negative sign, but exactly when? Let us take a look
at a 3 qubit example:

![Hadaamrd equation on 3 qubits](LatexImages/HadamardEquation3Qubits.gif)

With this example in mind, we can see that:
* All <sub><sub><sub>![Zero](LatexImages/Zero.gif)</sub></sub></sub>s are positive, so if
<sub><sub>![y_i](LatexImages/yi.gif)</sub></sub> is zero, this part of <sub><sub>![y](LatexImages/y.gif)</sub></sub>
definitely did not flip the sign.
* If <sub><sub>![y_i](LatexImages/yi.gif)</sub></sub> is <sub><sub><sub>![One](LatexImages/One.gif)</sub></sub></sub>
either:
  * This came from a <sub><sub><sub>![|0> + |1>](LatexImages/ZeroPlusOne.gif)</sub></sub></sub> component
, which is exactly when the corresponding <sub><sub>![x_i](LatexImages/xi.gif)</sub></sub> is
<sub><sub><sub>![Zero](LatexImages/Zero.gif)</sub></sub></sub> and so does not flip the sign.
  * This came from a <sub><sub><sub>![|0> - |1>](LatexImages/ZeroMinusOne.gif)</sub></sub></sub> component
, which is exactly when the corresponding <sub><sub>![x_i](LatexImages/xi.gif)</sub></sub> is
<sub><sub><sub>![One](LatexImages/One.gif)</sub></sub></sub> and so **does flip the sign**.

So we only need to flip the sign of the state when both <sub><sub>![x_i](LatexImages/xi.gif)</sub></sub>
and <sub><sub>![y_i](LatexImages/yi.gif)</sub></sub> are `1`. This corresponds to adding `1` modulo two in
our sum of the bitwise product. If the sum is odd, the equation makes the state negative, and if it is even
the state will be positive, which is exactly what we want.

Hopefully that explains why we have the final state before measurement of:

![Deutsch Jozse State Before Measurement](LatexImages/DeutschJozseStateBeforeMeasurement.gif)

But go ahead and rigourously prove the equation if you like!

### Step 4 - Measurement

We are going to measure in the computational basis <sub><sub><sub>![Zero](LatexImages/Zero.gif)</sub></sub></sub>,
<sub><sub><sub>![One](LatexImages/One.gif)</sub></sub></sub> as normal, but what will we find?

We could apply projection matrices<span style="color:blue"><sup>1</sup></span> to the equation from Step 3,
but that would be needlessly complicated.
We can rewrite the equation in a particularly useful form as follows:

![Deutsch Jozse Basis Decomposition](LatexImages/DeutschJozseConvenientMeasurement.gif)

This equation tells us exactly the **basis decomposition of our state**. This means the terms of the outer sum
tell us how much each basis state contributes to the whole state, telling us our probabilities. In other words,
given a two qubit state written in this form:

![Labelled Two Qubit Decomposition](LatexImages/LabelledTwoQubitDecomposition.gif)

The probabilitiy of measuring
<sub><sub><sub><sub><sub>![|00>](LatexImages/ZeroZero.gif)</sub></sub></sub></sub></sub>
is exactly <sub><sub>![|lambda_1|^2](LatexImages/Lambda1Squared.gif)</sub></sub>, the
probabilitiy of measuring
<sub><sub><sub><sub><sub>![|01>](LatexImages/ZeroOne.gif)</sub></sub></sub></sub></sub>
is exactly <sub><sub>![|lambda_2|^2](LatexImages/Lambda2Squared.gif)</sub></sub>, and so on.

The final step in the Deutsch Jozse algorithm is to determine if the first `n` qubits, when measured, are all zero. Noting that
the final qubit is always one, the probability is:

![Deutsch Josze Probability of Zeroes](LatexImages/DeutschJoszeProbabilityOfZeroes.gif)

Which comes from the term where <sub><sub><sub>![y](LatexImages/y.gif)</sub></sub></sub> is all zeroes
in our state. Considering our function, we know that:
* If the function is constant, then this will be one, since all ![2^n](LatexImages/2ToTheN.gif)
terms will be one or minus one. This means the first `n` qubits **will definitely be zero**. This is
known as **constructive interference**.
* If the function is balanced, all the terms will cancel out and so the probability will be zero.
Therefore, at least one of the `n` qubits **will not be zero**. This is known as **destructive interference**.

And that is it; we have proven that the Deutsch Josze algorithm works! Congratulations if you followed
all of that - you know the ins and outs of a real Quantum algorithm<span style="color:blue"><sup>2</sup></span>! :+1:


<span style="color:blue"><sup>1</sup></span>See [the Maths of Simulating a Quantum Computer](TheMathsOfSimulatingAQuantumComputer.md)
for more details on how to model measurement as a set of matrices.<br>
<span style="color:blue"><sup>2</sup></span>As much as I do anyway!

## Resources

Some useful resources I found while learning about Quantum Computing:
* https://en.wikipedia.org/wiki/Deutsch%E2%80%93Jozsa_algorithm - Deutsch Jozsa algorithm.
* https://en.wikipedia.org/wiki/BPP_(complexity) - Bounded error Probabilistic Polynomial time or BPP.