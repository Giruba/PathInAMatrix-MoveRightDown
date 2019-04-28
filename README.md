# PathInAMatrix-MoveRightDown
C# program for reaching destination by moving forward in right or down directions where blockages are present


Logic
1. Start recursive function from starting position 0, 0
2. Check whether the destination is reached, (N-1)(N-1), if yes, retrun true
3. Check whether we can pass through the current position
   3.1 Set this position in solution matrix as 1
   3.2  Recurse forward right -> if this returns true, return true
   3.3 If forward right is not possible, recurse for forward down -> if this returns true, return true
   3.4 If we cannot proceed in both directions, backtrack and reset this position in solution matrix
4. if we cannot pass through this position, return false
5. If final recursion is true, print solution matrix. Else, report solution does not exist for the current maze
