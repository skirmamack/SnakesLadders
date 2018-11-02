Some comments..

* Solution was done using TDD and is minimalistic, just doing what Feature 1 is asking.
* Functionality implemented only for 1 token what Feature 1 is asking. Supporting more tokens would need slight refactoring (that would be further Features)
* Was considering to separate Game and Board classes (where Board would be basically doing just moving token), but thought that could confuse what's the purpose of each of those classes. And such as MoveToken would be nearly duplicating.
* Assumed that the game library expects dice number rolled as a parameter. If automatic dice was used, that would look like pure as all computers' game.
* Dice number is validated. The exercise does not say anything about validation, but assumed that if for some reason invalid dice number is passed, exception is thrown.
* Automatic dice assumed to be needed in further Features, explicitly involving computer players. Dice class would still be available and could be used to get a rolled dice number if needed.
* GetTokenSquareNumber method currently returns just the only token's position. For complete game all token positions would need to be exposed. But again, that looks like as further 
* Assumed that could be couple of winners (if theoretically players finish at the same round), so method GetWinnerTokens returns list of winning tokens.

Hope the solution does not look like over engineered. It's always hard to find balance in small exercises, follow TDD and not to do too much. As well as it's nice to leave some space for it's extention.
