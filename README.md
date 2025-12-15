# Bulls & Cows (Mastermind) — WinForms (C#)

A Windows Forms implementation of the classic code-breaking game (“Bulls & Cows” / “Mastermind”).  
Pick the number of guesses, choose colors for each slot, submit your guess, and get feedback until you crack the secret code or run out of attempts.

---

## Features
- Configurable number of attempts (chosen before the game starts).
- Color picker per slot with an 8-color palette.
- Per-row feedback after each guess (exact match vs. color-only match).
- Secret code row stays hidden until win/lose.
- Clear separation between UI and logic:
  - `GameLogic.cs` handles rules, target generation and feedback.
  - `GuessRow.cs` encapsulates a single guess row UI and state.

---

## Project structure
Ex05/
├─ Program.cs // Application entry point
├─ GameConstants.cs // Allowed colors (8-color palette)
├─ GameLogic.cs // Core rules: target generation, feedback, win check
├─ GuessRow.cs // UI for a single guess row (4 slots + 2×2 feedback + Submit)
├─ GameForm.cs // Main board: rows lifecycle, reveal, win/lose flow
├─ GameForm.Designer.cs // Designer-generated layout for GameForm
├─ NumberOfChancesForm.cs // Dialog to choose number of guesses
├─ NumberOfChancesForm.Designer.cs // Designer-generated layout
├─ Bool Pgia.cs // Host/startup form
├─ Bool Pgia.Designer.cs // Designer-generated layout
├─ ColorPickerForm.cs // Color selection dialog (blocks duplicates in a row)
├─ ColorPickerForm.Designer.cs // 8 color buttons wired to return the chosen color

---

## Gameplay
1. On start, pick the number of allowed attempts.
2. For the active row, click each of the 4 slots to choose a color from the picker.
3. When all 4 slots are selected, click **Submit** to receive feedback:
   - Exact color in exact place → strong match.
   - Correct color in wrong place → partial match.
4. Continue row by row until you guess the full sequence or run out of attempts.
5. On win or loss, the secret code row is revealed.

---

## Implementation notes

### `GameLogic.cs`
- Randomly generates a 4-color secret from the allowed palette (typically without duplicates).
- `GetFeedback(...)` compares a guess to the secret and returns the counts used to fill the 2×2 feedback panel.
- `IsWin(...)` checks if all four positions match.

### `GuessRow.cs`
- Self-contained user control for a single attempt:
  - Four color buttons, a **Submit** button, and a compact 2×2 feedback area.
  - `Enable()` / `Disable()` to control interaction flow.
  - Guards submission until the row is complete.

### `GameForm.cs`
- Creates the hidden secret row (covered buttons), builds the list of `GuessRow` instances, opens the color picker for slot selection, calls `GameLogic` for feedback, advances to the next row, and reveals the secret on end.

### `GameConstants.cs`
- Centralized 8-color palette used across UI and logic.

### `ColorPickerForm.cs`
- Simple dialog with 8 fixed buttons mapped to the palette; returns the chosen color to the calling row.

---

## screenshots
<img width="407" height="208" alt="Screenshot 2025-12-15 102424" src="https://github.com/user-attachments/assets/b8828c7c-f7ab-430b-8fbc-1e74ef08cf2e" />
<img width="417" height="689" alt="Screenshot 2025-12-15 102502" src="https://github.com/user-attachments/assets/e96a44c7-0aa1-48a2-b197-068b222aa813" />
<img width="426" height="685" alt="Screenshot 2025-12-15 102603" src="https://github.com/user-attachments/assets/cde330bf-fa5a-4202-be5e-fa33a6360cf5" />


## Future improvements
- Optional “duplicates allowed” mode and difficulty presets.
- Keyboard navigation and accessibility tweaks.
- Persist last settings (attempts).
- Sounds/animations and a simple stats screen.
