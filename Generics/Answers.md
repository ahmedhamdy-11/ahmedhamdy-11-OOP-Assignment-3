# Part 03 - Generics & Delegates Answers

## Task 3.1 - Research: Generics Constraints & Query Interfaces

### 1. Generic Constraints (`where T : ...`)
Generic constraints restrict the types that can be passed as type arguments to a generic class or method, enabling type safety and allowing compiler optimizations:

* **`where T : class`**: Constrains `T` to be a reference type (e.g., class, interface, delegate). Prevents passing value types like `int` or `struct`.
* **`where T : struct`**: Constrains `T` to be a non-nullable value type (e.g., `int`, `decimal`, `bool`, `DateTime`).
* **`where T : new()`**: Ensures `T` has a public parameterless constructor. This allows creating new instances inside the generic method or class using `new T()`.
* **`where T : BaseClass`**: Constrains `T` to derive from or be a specific base class, allowing access to members of that base class.
* **`where T : ISomeInterface`**: Constrains `T` to implement a specific interface, ensuring `T` guarantees that interface's contract.

---

### 2. Difference between `IEnumerable<T>` and `IQueryable<T>`

| Aspect | `IEnumerable<T>` | `IQueryable<T>` |
|---|---|---|
| **Execution Environment** | In-Memory (LINQ to Objects). | Out-of-Memory / Server-side (LINQ to Entities/SQL). |
| **Query Evaluation** | Evaluates and filters data locally after loading into memory. | Translates LINQ expressions into raw SQL and executes filtering on the database server. |
| **Best Used For** | Local collections like `List<T>`, `Array`, or data already in memory. | External data sources like databases using Entity Framework Core. |
| **Performance Impact** | Can cause memory issues if fetching large datasets before filtering. | Optimized network usage by fetching only filtered rows from the database. |