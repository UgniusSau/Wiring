# Wiring

Simple Blazor WASM application to generate Shassi(complect of harrnesses with wires which contains ports and pins).

Most important part is validation of shassi because a set of harnesses wires can connect to same port and pin.
Validation is done by comparing each harness to other harnesses in pairs (excluding same pairs in different order) by checking their wires housing ports and pins.

IMPORTANT! 
When first time clicking on button "Generuoti"(Generate) wait for few seconds because of data loading. Afterwards each button click and data retrieval is normal.
