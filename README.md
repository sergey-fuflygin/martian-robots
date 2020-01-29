# Martian Robots Design Overview

Solution consists of 3 projects

  - `Robots` - project which solves the described problem
  - `Robots.Tests` - unit tests
  - `Robots.ConsoleApp` - simple user interface to demonstrate the solution

### Classes Diagram

![](https://github.com/sergey-fuflygin/martian-robots/blob/master/ClassesDiagram.png)

### Console App commands

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

### List of assumptions that you made

Dillinger uses a number of open source projects to work properly:

### ETA

An estimate of how long this would take if you were asked to build the entire solution for a customer
