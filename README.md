# Green Game

Ecological game for kids written in Unity version 2021.3.15f1 (as for 08/12/2022 the most recent LTS version) for Software Engineering classes.
 
## Naming conventions

This section describes general naming conventions:

| Entity kinds                          | Preview            |
| :------------------------------------ | :----------------- |
| Interfaces                            | `IPascalCase`      |
| Type parameters                       | `TPascalCase`      |
| Types and Namespaces                  | `PascalCase`       |
| Methods                               | `PascalCase`       |
| Public fields                         | `PascalCase`       |
| Protected fields                      | `PascalCase`       |
| Private fields                        | `_camelCase`       |
| Constant fields                       | `PascalCase`       |
| Static readonly fields                | `PascalCase`       |
| Events                                | `PascalCase`       |
| Local variables & constants           | `camelCase`        |
| Parameters                            | `camelCase`        |
| Properties                            | `PascalCase`       |
| Enum members                          | `PascalCase`       |
| Fields with [SerializeField] attribute| `_camelCase`       |

### Naming of events
For the sake of naming events use `PascalCase` in the past tense. Do not use the "On-" prefix. For example:

- `ButtonClicked` -> Good
- `EnemyKilled` -> Good
- `buttonClicked` -> Bad
- `OnButtonClicked` -> Bad

For the sake of naming handlers use `PascalCase` with prefix "On-". For example:

- `OnButtonClicked` -> Good
- `OnEnemyKilled` -> Good
- `EnemyKilledHandler` -> Bad
- `OnEnemyKilledHandler` -> Bad

Matters not discussed in this section are described in the [Microsoft Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions).


## Ordering 
Use the declaration order described below:

1. `[SerializeField] private`
2. `const`-y i `static`-i
3. Properties
4. Fields
5. Methods

## Branches
Each component should have its own branch named `component_{component name}`. Please create a pull request after being done with your branch.

## Additional notes
- Test your components in your scenes. **DO NOT MODIFY OTHER SCENES!** The merging of scene files is a nightmare and we don't want to do that.
- Please **don't use threading** in your application since WebGL doesn't support it!!
