# Martian Robots

Solution consists of 3 projects

  - `Robots` - project which solves the described problem
  - `Robots.Tests` - unit tests
  - `Robots.ConsoleApp` - simple user interface to demonstrate the solution

### Classes Diagram

![](https://github.com/sergey-fuflygin/martian-robots/blob/master/ClassesDiagram.png)

### Console App Input and Output

```cmd
5 3
1 1 E
RFRFRFRF
1 1 E <-- output
3 2 N
FRRFLLFFRRFLL
3 3 N LOST <-- output
0 3 W
LLFFFLFLFL
2 3 S <-- output
exit
```

### List of assumptions

- commands are sent from Earth to Mars without any delay
- the final positions for all robots are not kept, that's why the it is printed right after robot instruction in console app
- robot orientation (north, south, east, and west) can be expanded with north-east, south-east, etc.
- robot instructions can be expanded with the following commands: about turn, backward, etc.

### ETA

An estimate of how long this would take if you were asked to build the entire solution for a customer
